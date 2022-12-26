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
using System.Collections.Concurrent;

namespace ChatApp___Client
{
    public partial class frmClient : MaterialForm
    {
        public frmClient()
        {
            InitializeComponent();

            var MaterialSkinMgr = MaterialSkinManager.Instance;
            MaterialSkinMgr.AddFormToManage(this);
            MaterialSkinMgr.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinMgr.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        const int PORT = 5001;
        string EncryptionKey = CryptBase.CreateMD5("jumbojetxx123");

        TcpClient TCPClient;
        NetworkStream Stream;
        Thread ReceiverThread;

        int ClientID;
        string ClientName => "Client " + ClientID;

        ConcurrentDictionary<int, StringBuilder> Chats = new ConcurrentDictionary<int, StringBuilder>();

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

        ListViewItem SelectedItem;
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
                                Chats.TryAdd(UserID, new StringBuilder());
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

                                    string EncryptedText = Encoding.UTF8.GetString(BR.ReadBytes(DataSize - 8));
                                    BlowFish BlowFish = new BlowFish(EncryptionKey, new HexCoding());
                                    string DecryptedText = BlowFish.DecryptECB(EncryptedText, EncryptedText.Length);

                                    /*TimeSpan Span = DateTime.Now - SentDate.ConvertToDateTime();
                                    double ElapsedMS = Span.TotalMilliseconds;*/

                                    string TimeString = "[" + SentDate.Hour + ":" + SentDate.Minute + "]";
                                    string NewMessageLine = TimeString + " Client " + SenderID + " : " + DecryptedText;

                                    if (SelectedItem ==  null)
                                    {
                                        SelectedItem = lvUsers.FindItemWithText("Client " + SenderID.ToString());
                                        if (!SelectedItem.Selected) SelectedItem.Selected = true;
                                    }
                                    else
                                    {
                                        int SelectedUserId = (int)SelectedItem.Tag;
                                        if (SelectedUserId != SenderID)
                                        {
                                            if (!SelectedItem.Selected) SelectedItem.Selected = true;
                                        }
                                    }
                                    
                                    UpdateChat(SenderID, NewMessageLine);
                                    // update tbInfo
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
            string TimeString = "[" + SentDate.Hour + ":" + SentDate.Minute + "]";
            string NewMessageLine = TimeString + " You : " + tbSend.Text;
            UpdateChat(ReceiverID, NewMessageLine);

            //tbInfo.Text = Chats[ReceiverID].ToString();

            BlowFish BlowFish = new BlowFish(EncryptionKey, new HexCoding());
            string EncryptedText = BlowFish.EncryptECB(tbSend.Text);
            byte[] Data = Encoding.UTF8.GetBytes(EncryptedText);

            using (MemoryStream MS = new MemoryStream(Message.GetFixedSize() + Data.Length))
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(Data.Length + 8);
                    SentDate.WriteToStream(BW);
                    BW.Write(Data);
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
                tbInfo.Clear();
                SelectedItem = null;
                return;
            }
            SelectedItem = lvUsers.SelectedItems[0];

            int SelectedUserId = (int)lvUsers.SelectedItems[0].Tag;
           // tbInfo.Text = Chats[SelectedUserId].ToString();
        }

        private void UpdateChat(int friendId, string message)
        {
            if (lvUsers.SelectedIndices.Count == 0) return;
            int SelectedID = (int)lvUsers.SelectedItems[0].Tag;

            Chats[friendId].AppendLine(message);

            //MessageBox.Show("friendId:"+ friendId+ " SelectedID:" + SelectedID);

            BeginInvoke(new MethodInvoker(delegate 
            {
                tbInfo.SuspendLayout();
                if (friendId == SelectedID)
                {
                    tbInfo.Text += message + Environment.NewLine;
                }
                else
                {
                    tbInfo.Text = Chats[friendId].ToString();
                }
                tbInfo.ResumeLayout(true);
            }));
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
    }
}
