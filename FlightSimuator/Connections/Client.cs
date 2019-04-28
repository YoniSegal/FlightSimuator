using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimulator.Model
{
    // Client class
    class Client
    {
        private TcpClient tcpClient; // client
        Int32 port;
        string server;
        //private BinaryWriter writer = new BinaryWriter(); // writer
        static Client instance = null;
        private string clientIp;
        public bool isConnected { get; set; } = false; // is the clinet connected?

        public string ClientIp { get; set; }
        
        public int ClientPort { get; set; }

        private Client() { }
        
        // return client 
        public static Client getInstance()
        {
            if (instance == null)
            {
                instance = new Client();
                return instance;
            }
            else return instance;
        }

        // client connection
        public void Connect_client()
        {
            port = ApplicationSettingsModel.Instance.FlightCommandPort;
            server = ApplicationSettingsModel.Instance.FlightServerIP;
            tcpClient = new TcpClient(server, port);
            isConnected = true;
        }

        // insert commands - update values 
        public void Send(string input)
        {
            using (NetworkStream stream = tcpClient.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                // in case where user pressed ok and text is empty
                if (string.IsNullOrEmpty(input)) return; 
                string[] commands = input.Split('\n');
                foreach (string command in commands)
                {
                    string tmp = command + "\r\n";
                    writer.Write(Encoding.ASCII.GetBytes(tmp));
                    // wait 2 seconds
                    Thread.Sleep(2000); 
                }
            }
        }
    }
}
