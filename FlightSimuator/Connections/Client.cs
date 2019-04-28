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
    class Client
    {
        private TcpClient tcpClient; // client
        Int32 port;
        string server;
        static Client instance = null;
        private string clientIp;
        public bool isConnected { get; set; } = false; // is the clinet connected?

        public string ClientIp { get; set; }


        public int ClientPort { get; set; }
        private Client() { }
        public static Client getInstance()
        {
            if (instance == null)
            {
                instance = new Client();
                return instance;
            }
            else return instance;
        }
        public void Connect_client()
        {
            port = ApplicationSettingsModel.Instance.FlightCommandPort;
            server = ApplicationSettingsModel.Instance.FlightServerIP;
            tcpClient = new TcpClient(server, port);

            isConnected = true;

        }


        public void Send(string input)
        {
            using (NetworkStream stream = tcpClient.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {

                if (string.IsNullOrEmpty(input)) return; // in case where user pressed ok and text is empty
                string[] commands = input.Split('\n');
                foreach (string command in commands)
                {
                    string tmp = command + "\r\n";
                    writer.Write(Encoding.ASCII.GetBytes(tmp));

                    Thread.Sleep(2000); // 2 seconds delay
                }
            }
        }
    }
}
