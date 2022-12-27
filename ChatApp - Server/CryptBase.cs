using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

namespace ChatApp___Server
{
    public class CryptBase
    {
        public enum EncryptionMethod
        {
            BlowFish,
            AES128,
            AES256
        }

        public static string CreateMD5(string Input)
        {
            byte[] Bytes = new UTF8Encoding().GetBytes(Input);
            byte[] Hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(Bytes);
            string Encoded = Encoding.UTF8.GetString(Hash).Replace("-", string.Empty).ToLower();
            return Encoded;
        }

        public static byte[] CreateMD5(byte[] Input)
        {
            byte[] Hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(Input);
            string Encoded = BitConverter.ToString(Hash).Replace("-", string.Empty).ToLower();
            return Hash;
        }

        private const int IV_LENGTH = 16;

        public static byte[] AESEncrypt(byte[] BytesToBeEncrypted, string Password, int KeySize)
        {
            //byte[] RawBytes = Encoding.UTF8.GetBytes(Text);
            byte[] PasswordBytes = Encoding.UTF8.GetBytes(Password);
            byte[] EncryptedBytes = null;
            byte[] EncryptedBytesAndIV = null;
            byte[] SaltBytes = CreateMD5(PasswordBytes);

            using (MemoryStream MS = new MemoryStream())
            {
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
                {
                    //AES.KeySize = 256;
                    AES.KeySize = KeySize;

                    var Key = new Rfc2898DeriveBytes(PasswordBytes, SaltBytes, 100);
                    AES.Key = Key.GetBytes(AES.KeySize / 8);
                    AES.IV = AESGenerateIV();

                    AES.Mode = CipherMode.CBC;

                    using (var CS = new CryptoStream(MS, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        CS.Write(BytesToBeEncrypted, 0, BytesToBeEncrypted.Length);
                    }

                    EncryptedBytes = MS.ToArray();
                    EncryptedBytesAndIV = new byte[EncryptedBytes.Length + AES.IV.Length];
                    AES.IV.CopyTo(EncryptedBytesAndIV, 0);
                    EncryptedBytes.CopyTo(EncryptedBytesAndIV, IV_LENGTH);
                }
            }
            return EncryptedBytesAndIV;
        }

        private static byte[] AESGenerateIV()
        {
            using (RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider())
            {
                byte[] Bytes = new byte[IV_LENGTH];
                RNG.GetBytes(Bytes);
                return Bytes;
            }
        }

        public static byte[] AESDecrypt(byte[] BytesToBeDecrypted, string Password, int KeySize)
        {
            byte[] PasswordBytes = Encoding.UTF8.GetBytes(Password);
            byte[] DecryptedBytes = null;
            byte[] SaltBytes = CreateMD5(PasswordBytes);

            using (MemoryStream MS = new MemoryStream())
            {
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
                {
                    //AES.KeySize = 256;
                    AES.KeySize = KeySize;

                    var key = new Rfc2898DeriveBytes(PasswordBytes, SaltBytes, 100);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = AESReadIV(BytesToBeDecrypted);
                    BytesToBeDecrypted = AESGetData(BytesToBeDecrypted);
                    AES.Mode = CipherMode.CBC;

                    using (var CS = new CryptoStream(MS, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        CS.Write(BytesToBeDecrypted, 0, BytesToBeDecrypted.Length);
                    }
                    DecryptedBytes = MS.ToArray();
                }
            }
            return DecryptedBytes;
        }

        private static byte[] AESGetData(byte[] Array)
        {
            byte[] enc = new byte[Array.Length - IV_LENGTH];
            System.Array.Copy(Array, IV_LENGTH, enc, 0, Array.Length - IV_LENGTH);
            return enc;
        }

        private static byte[] AESReadIV(byte[] Array)
        {
            byte[] IV = new byte[IV_LENGTH];
            System.Array.Copy(Array, 0, IV, 0, IV_LENGTH);
            return IV;
        }
    }
}