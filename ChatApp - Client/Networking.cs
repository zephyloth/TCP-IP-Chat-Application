using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp___Client
{
    public enum MessageHeader : int
    {
        Register,
        Login,
        AddClient,
        Text
    }

    public class Date
    {
        public ushort Year;
        public byte Month;
        public byte Day;
        public byte Hour;
        public byte Minute;
        public byte Second;
        public byte Millisecond;

        public Date() { }
        public Date(DateTime DateTime)
        {
            Year = (ushort)DateTime.Year;
            Month = (byte)DateTime.Month;
            Day = (byte)DateTime.Day;
            Hour = (byte)DateTime.Hour;
            Minute = (byte)DateTime.Minute;
            Second = (byte)DateTime.Second;
            Millisecond = (byte)DateTime.Millisecond;
        }

        public DateTime ConvertToDateTime()
        {
            return new DateTime(Year,Month,Day,Hour,Minute,Second,Millisecond, DateTimeKind.Utc);
        }

        public void WriteToStream(BinaryWriter BW)
        {
            BW.Write(Year);
            BW.Write(Month);
            BW.Write(Day);
            BW.Write(Hour);
            BW.Write(Minute);
            BW.Write(Second);
            BW.Write(Millisecond);
        }

        public void ReadFromStream(BinaryReader BR)
        {
            Year = BR.ReadUInt16();
            Month = BR.ReadByte();
            Day = BR.ReadByte();
            Hour = BR.ReadByte();
            Minute = BR.ReadByte();
            Second = BR.ReadByte();
            Millisecond = BR.ReadByte();
        }
    }
 
    public class Message
    {
        public int DataLength;
        public byte[] Data;

        public int SenderID;
        public int ReceiverID;
        public MessageHeader MessageHeader;
 
        public static int GetFixedSize()
        {
            return sizeof(int) * 3 + sizeof(MessageHeader);
        }

        public static int GetFixedSizeWithoutLength()
        {
            return sizeof(int) * 2 + sizeof(MessageHeader);
        }
    }
}
