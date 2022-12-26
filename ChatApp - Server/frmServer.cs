using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO;
using Core.Crypto;

namespace ChatApp___Server
{
    public partial class frmServer : Form
    {
        const int PORT = 5001;
        string EncryptionKey = CryptBase.CreateMD5("jumbojetxx123");

        TcpListener ServerSocket;
        ConcurrentDictionary<int, TcpClient> Clients = new ConcurrentDictionary<int, TcpClient>();
        int ClientCount = 0;
 
        long IsClosing = 0;
 
        public frmServer()
        {
            InitializeComponent();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            InitializeConnection();
        }
 
        void InitializeConnection()
        {
            ServerSocket = new TcpListener(IPAddress.Any, PORT);

            try
            {
                ServerSocket.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
            tbInfo.Text += "Server has been initialized" + Environment.NewLine;

            Thread ClientListenerThread = new Thread(() =>
            {
                while (true)
                {
                    if (Interlocked.Read(ref IsClosing) == 1 && Clients.Values.Count == 0)
                        break;

                    try
                    {
                        TcpClient Client = ServerSocket.AcceptTcpClient();

                        ClientCount++;
                        Clients.TryAdd(ClientCount, Client);
                        BeginInvoke(new Action(() => { tbInfo.Text += "Client " + ClientCount + " has connected." + Environment.NewLine; }));

                        Thread t = new Thread(() => { ClientDataReader(ClientCount, Client); });
                        t.Start();
                    }
                    catch (SocketException ex)
                    {
                        if ((ex.SocketErrorCode == SocketError.Interrupted))
                        {
                            Interlocked.Exchange(ref IsClosing, 1);
                            break;
                        }
                    }
                }
            });
            ClientListenerThread.Start();
        }

        void ClientDataReader(int ID, TcpClient Client)
        {   
            SendToClient(0, ID, MessageHeader.Register, ID);

            List<int> OtherClients = new List<int>();
            foreach (var OtherClient in Clients)
            {
                if (OtherClient.Key != ID)
                {
                    OtherClients.Add(OtherClient.Key);
                    SendToClient(0, OtherClient.Key, MessageHeader.AddClient, new List<int>() { ID});
                } 
            }
  
            if(OtherClients.Count > 0)
            SendToClient(0, ID, MessageHeader.AddClient, OtherClients);

            while (Interlocked.Read(ref IsClosing) == 0)
            {
                NetworkStream Stream = Client.GetStream();
  
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

                if (ReceiverID > 0)
                {
                    switch (MessageHeader)
                    {
                        case MessageHeader.Text:
                            SendToClient(SenderID, ReceiverID, MessageHeader, Data);
                            break;
                        default:
                            break;
                    }
                }
            }

            BeginInvoke(new Action(() =>
            {
                tbInfo.Text += "Client " + ID + " has exited." + Environment.NewLine;
            }));
 
            Client.Client.Shutdown(SocketShutdown.Both);
            Client.Close();
 
            TcpClient Removed;
            Clients.TryRemove(ID, out Removed);
        }

        int GetDataSize(NetworkStream Stream)
        {
            byte[] SizeBuffer = new byte[4];
            int Read = Stream.Read(SizeBuffer, 0, SizeBuffer.Length);
            if (Read == 0) return -1;
            int DataSize = BitConverter.ToInt32(SizeBuffer, 0);
            return DataSize;
        }

        void SendToClient(int SenderID, int ReceiverID, MessageHeader Header, object Data)
        {
            TcpClient ReceiverClient;
            if (!Clients.TryGetValue(ReceiverID, out ReceiverClient)) return;
   
            NetworkStream Stream = ReceiverClient.GetStream();

            int DataSize=0;
            switch (Header)
            {
                case MessageHeader.Register:
                    DataSize = sizeof(int);
                    break;
                case MessageHeader.AddClient:
                    List<int> Clients = (List<int>)Data;
                    DataSize = Clients.Count * sizeof(int);
                    break;
                case MessageHeader.Text:
                    DataSize = ((byte[])Data).Length;
                    break;
                default:
                    break;
            }

            using (MemoryStream MS = new MemoryStream(Message.GetFixedSize() + DataSize))
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(DataSize);
                    switch (Header)
                    {
                        case MessageHeader.Register:
                            BW.Write((int)Data);
                            break;
                        case MessageHeader.AddClient:
                            List<int> Clients = (List<int>)Data;
                            foreach (var Client in Clients)
                                BW.Write(Client);
                            break;
                        case MessageHeader.Text:
                            BW.Write( (byte[])Data);
                            break;
                        default:
                            break;
                    }

                    BW.Write(SenderID);
                    BW.Write(ReceiverID);
                    BW.Write((int)Header);
                }

                var Array = MS.ToArray();
                Stream.Write(Array, 0, Array.Length);
            }
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerSocket.Stop();
        }
    }
}
