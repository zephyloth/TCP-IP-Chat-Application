using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp___Server
{
    public enum MessageHeader : int
    {
        Register,
        Login,
        AddClient,
        Text
    }

    public class Message
    {
        public int DataLength;
        public byte[] Data;

        public int SenderID;
        public int ReceiverID;
        public MessageHeader MessageHeader;
    }
}
