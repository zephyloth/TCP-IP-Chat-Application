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
