using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Core.Crypto;
using System.Collections;

namespace ChatApp___Client
{
    public partial class frmClient : MaterialForm
    {
        public frmClient()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            var MaterialSkinMgr = MaterialSkinManager.Instance;
            MaterialSkinMgr.AddFormToManage(this);
            MaterialSkinMgr.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinMgr.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue200, TextShade.WHITE);
        }

        const int PORT = 5001;
 
        TcpClient TCPClient;
        NetworkStream Stream;
        Thread ReceiverThread;

        Dictionary<int, StringBuilder> Chats = new Dictionary<int, StringBuilder>();

        string EncryptionPass = CryptBase.CreateMD5("jumbojetxx123");
        CryptBase.EncryptionMethod EncryptionMethod;

        bool TestMode { get; set; }

        int ClientID;
        string ClientName => "Client " + ClientID;
 
        void InitializeConnection()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TCPClient = new TcpClient();

            try
            {
                TCPClient.Connect(ip, PORT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            tbInfo.Text += "Client Connected!" + Environment.NewLine;

            Stream = TCPClient.GetStream();
            ReceiverThread = new Thread(() => Receiver());
            ReceiverThread.Start();
        }

        void CloseConnection()
        {
            if (TCPClient.Connected)
            {
                TCPClient.Client.Shutdown(SocketShutdown.Send);
                TCPClient.Close();
            }

            if (ReceiverThread != null)
                ReceiverThread.Join();

            if (Stream != null)
                Stream.Close();

            tbInfo.Text += "Client Disconnected." + Environment.NewLine;
        }
 
        void Receiver()
        {
            NetworkStream Stream = TCPClient.GetStream();

            while (true)
            {
                int DataSize = GetDataSize(Stream);
                if (DataSize == -1) break;

                byte[] Buffer = new byte[Message.GetFixedSizeWithoutLength() + DataSize];
                Stream.Read(Buffer, 0, Buffer.Length);

                byte[] Data;
                int SenderID;
                int ReceiverID;
                MessageHeader MessageHeader;

                using (MemoryStream MS = new MemoryStream(Buffer))
                {
                    using (BinaryReader BR = new BinaryReader(MS))
                    {
                        Data = BR.ReadBytes(DataSize);
                        SenderID = BR.ReadInt32();
                        ReceiverID = BR.ReadInt32();
                        MessageHeader = (MessageHeader)BR.ReadInt32();
                    }
                }

                if (Data.Length == 0)
                    continue;

                BeginInvoke(new Action(() =>
                {
                    switch (MessageHeader)
                    {
                        case MessageHeader.Register:
                            ClientID = BitConverter.ToInt32(Data, 0);
                            Text = "Client " + ReceiverID;
                            tbInfo.Text += "Client ID is " + ReceiverID + Environment.NewLine;
                            break;
                        case MessageHeader.AddClient:
                            for (int i = 0; i < Data.Length / sizeof(int); i++)
                            {
                                int UserID = BitConverter.ToInt32(Data, i * sizeof(int));
                                ListViewItem Item = new ListViewItem("Client " + UserID);
                                Chats.Add(UserID, new StringBuilder());
                                Item.Tag = UserID;
                                lvUsers.Items.Add(Item);
                            }
                            break;
                        case MessageHeader.Text:
                            using (MemoryStream MS = new MemoryStream(Data))
                            {
                                using (BinaryReader BR = new BinaryReader(MS))
                                {
                                    Date SentDate = new Date();
                                    SentDate.ReadFromStream(BR);

                                    string DecryptedText = "";                             
                                    switch (EncryptionMethod)
                                    {
                                        case CryptBase.EncryptionMethod.BlowFish:
                                            string EncryptedText = Encoding.UTF8.GetString(BR.ReadBytes(DataSize - 8));
                                            BlowFish BlowFish = new BlowFish(EncryptionPass, new HexCoding());
                                            DecryptedText = BlowFish.DecryptECB(EncryptedText, EncryptedText.Length);
                                            break;
                                        case CryptBase.EncryptionMethod.AES128:
                                        case CryptBase.EncryptionMethod.AES256:
                                            byte[] EncryptedData = BR.ReadBytes(DataSize - 8);
                                            int KeySize = EncryptionMethod == CryptBase.EncryptionMethod.AES256 ? 256 : 128;
                                            DecryptedText = Encoding.UTF8.GetString(CryptBase.AESDecrypt(EncryptedData, EncryptionPass, KeySize));
                                            break;
                                        default:
                                            break;
                                    }
                                    if (DecryptedText == "") return;
                                    DecryptedText = DecryptedText.TrimEnd();

                                    TimeSpan Span = DateTime.Now - SentDate.ConvertToDateTime();
                                    double ElapsedMS = Math.Round(Span.TotalMilliseconds % 256, 3);
                                    string TimeString = "[" + SentDate.Hour + ":" + SentDate.Minute + ":" + SentDate.Second + "]";

                                    string NewMessageLine = TimeString + " Client " + SenderID + " : " + DecryptedText;

                                    if (TestMode) 
                                        NewMessageLine += " (Took " + ElapsedMS +" MS to send.)";

                                    var LVI = lvUsers.FindItemWithText("Client " + SenderID.ToString());

                                    if(!LVI.Selected)
                                    LVI.Selected = true; 

                                    UpdateChat(SenderID, NewMessageLine);
                                }
                            }

                            break;
                        default:
                            break;
                    }
                }));
            }
        }

        void Send()
        {
            if (!TCPClient.Connected) return;

            if (string.IsNullOrEmpty(tbSend.Text))
                return;

            int SenderID = ClientID;
            int ReceiverID = (int)lvUsers.SelectedItems[0].Tag;

            Date SentDate = new Date(DateTime.Now);
            string TimeString = "[" + SentDate.Hour + ":" + SentDate.Minute + ":" + SentDate.Second + "]";
            string NewMessageLine = TimeString + " You : " + tbSend.Text;
            UpdateChat(ReceiverID, NewMessageLine);

            byte[] EncryptedData = null;
            switch (EncryptionMethod)
            {
                case CryptBase.EncryptionMethod.BlowFish:
                    BlowFish BlowFish = new BlowFish(EncryptionPass, new HexCoding());
                    string EncryptedText = BlowFish.EncryptECB(tbSend.Text);
                    EncryptedData = Encoding.UTF8.GetBytes(EncryptedText);
                    break;
                case CryptBase.EncryptionMethod.AES256:
                case CryptBase.EncryptionMethod.AES128:
                    int KeySize = EncryptionMethod == CryptBase.EncryptionMethod.AES256 ? 256 : 128;
                    EncryptedData = CryptBase.AESEncrypt(Encoding.UTF8.GetBytes(tbSend.Text), EncryptionPass, KeySize);     
                    break;
                default:
                    break;
            }
            if (EncryptedData == null) return;

            using (MemoryStream MS = new MemoryStream(Message.GetFixedSize() + EncryptedData.Length))
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(EncryptedData.Length + 8);
                    SentDate.WriteToStream(BW);
                    BW.Write(EncryptedData);
                    BW.Write(SenderID);
                    BW.Write(ReceiverID);
                    BW.Write((int)MessageHeader.Text);
                }

                byte[] Buffer = MS.ToArray();
                Stream.Write(Buffer, 0, Buffer.Length);
            }
        }

        int GetDataSize(NetworkStream Stream)
        {
            byte[] SizeBuffer = new byte[4];
            int Read = Stream.Read(SizeBuffer, 0, SizeBuffer.Length);
            if (Read == 0) return -1;
            int DataSize = BitConverter.ToInt32(SizeBuffer, 0);
            return DataSize;
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            InitializeConnection();
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedIndices.Count == 0) return;
            Send();
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedIndices.Count == 0)
            {
                lblClientName.Text = "";
                tbInfo.Clear();
                return;
            }
 
            int SelectedID = (int)lvUsers.SelectedItems[0].Tag;
 
            lblClientName.Text = "Text to Client " + SelectedID + " (" + EncryptionMethod.ToString() +")";
            tbInfo.Text = Chats[SelectedID].ToString();
        }

        private void UpdateChat(int FriendID, string Message)
        {
            if (lvUsers.SelectedIndices.Count == 0)
                return;
 
            int SelectedID = (int)lvUsers.SelectedItems[0].Tag;
            Chats[FriendID].AppendLine(Message);

            if (FriendID == SelectedID)
            {
                tbInfo.Text += Message + Environment.NewLine;
            }
            else
            {
                tbInfo.Text = Chats[FriendID].ToString();
            }
        }

        private void btnSend1000x_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedIndices.Count == 0) return;

            new Thread(()=> 
            {
                for (int i = 0; i < 1000; i++)
                    Send();
            }).Start();       
        }

        private void btnApplyProperties_Click(object sender, EventArgs e)
        {
            EncryptionMethod = (CryptBase.EncryptionMethod)cbEncryption.SelectedIndex;
            TabControl.SelectedTab = TabControl.TabPages["tpChat"];
        }

        private void cbTestMode_CheckedChanged(object sender, EventArgs e)
        {
            TestMode = cbTestMode.Checked;
        }
    }
}
