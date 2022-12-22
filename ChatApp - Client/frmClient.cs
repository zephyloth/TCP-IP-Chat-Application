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

namespace ChatApp___Client
{
    public partial class frmClient : Form
    {
        public class ListBoxObject : object
        {
            public int ID { get; set; }

            public ListBoxObject(int ID)
            {
                this.ID = ID;
            }

            public override string ToString()
            {
                return "Client " + ID;
            }
        }

        public frmClient()
        {
            CheckForIllegalCrossThreadCalls = true;
            InitializeComponent();
        }

        TcpClient TCPClient;
        NetworkStream Stream;
        Thread ReceiverThread;

        int ClientID;
        string ClientName => "Client " + ClientID;

        void InitializeConnection()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TCPClient = new TcpClient();
 
            try
            {
                TCPClient.Connect(ip, 5001);
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
            if(TCPClient.Connected)
            {
                TCPClient.Client.Shutdown(SocketShutdown.Send);
                TCPClient.Close();
            }

            if(ReceiverThread != null)
            ReceiverThread.Join();

            if(Stream != null)
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

                byte[] Buffer = new byte[3 * sizeof(int) + DataSize];
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
                                lbUsers.Items.Add(new ListBoxObject(BitConverter.ToInt32(Data, i * sizeof(int))));
                            }
                            break;
                        case MessageHeader.Text:
                            tbInfo.Text += "Client " + SenderID + ": " + Encoding.UTF8.GetString(Data) + Environment.NewLine;
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
            ListBoxObject SelectedUserData = (ListBoxObject)lbUsers.SelectedItem;
            int ReceiverID = SelectedUserData.ID;

            byte[] Data = Encoding.ASCII.GetBytes(tbSend.Text);

            using (MemoryStream MS = new MemoryStream(4 * sizeof(int) + Data.Length))
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(Data.Length);
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
            if (lbUsers.SelectedIndex < 0) return;
            Send();
        }
    }
}
