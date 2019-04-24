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

            Int32 port = ApplicationSettingsModel.Instance.FlightCommandPort;
            string server = ApplicationSettingsModel.Instance.FlightServerIP;
            TcpClient tcpClient = new TcpClient(server, port);
            Console.WriteLine("Comman channel: you are connected");
            isConnected = true;
            
            new Thread(() =>
            {
                using (NetworkStream stream = tcpClient.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    // Send data to server
                    Console.Write("Please enter a number: ");
                    int num = 5;
                    //int.Parse(Console.ReadLine());
                    writer.Write(num);
                    // Get result from server
                    int result = reader.ReadInt32();
                    Console.WriteLine("Result = {0}", result);
                }
                tcpClient.Close();
            }).Start();
            
        }
    }
}
