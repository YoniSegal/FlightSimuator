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
        //private BinaryWriter writer = new BinaryWriter(); // writer
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
            Console.WriteLine("Command channel: you are connected");

            isConnected = true;
            /*
            new Thread(() =>
            {
                using (NetworkStream stream = tcpClient.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    // Send data to server
                    Console.WriteLine("Please enter a number: ");
                    int num = 5;
                    //int.Parse(Console.ReadLine());
                    //writer.Write(num);
                    // Get result from server
                    //int result = reader.ReadInt32();
                   // Console.WriteLine("Result = {0}", result);
                }
                tcpClient.Close();
            }).Start();
            */
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
                    //Console.WriteLine("Command is: " + command);
                    //byte[] data = Encoding.ASCII.GetBytes(command + "\r\n");
                    //Console.WriteLine("Data is: " + data.ToString());
                    //stream.Write(data, 0, data.Length);

                    string tmp = command + "\r\n";
                    writer.Write(Encoding.ASCII.GetBytes(tmp));

                    Thread.Sleep(2000); // 2 seconds delay
                }
            }
        }
    }
}
