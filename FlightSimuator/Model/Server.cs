using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace FlightSimulator.Model
{
    class Server
    {
        static Server instance = null;
        private string serverIp;
        private int serverPort;
        TcpClient client;
        public int ServerPort
        {
            get { return serverPort; }
            set
            {
                serverPort = value;
            }
        }
        public string ServerIp
        {
            get { return serverIp; }
            set { serverIp = value; }
        }
        private Server()
        {
        }
        static public Server getInstance()
        {
            if (instance == null)
            {
                instance = new Server();
                return instance;
            }
            else return instance;
        }
        public void connect_server()
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for client connections...");
            client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
            Task t = new Task(ServisClient);
            t.Start();

            listener.Stop();
        }

        void ServisClient()
        {
            try
            {
                while (true)
                {
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryReader reader = new BinaryReader(stream))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        Console.WriteLine("Waiting for a number");
                        string num = reader.ReadString();
                        Console.WriteLine("Number accepted");
                        writer.Write(num);
                        writer.Flush();
                    }
                    client.Close();
                }
            }
            catch
            {
                Console.WriteLine("Disconnected");
            }
        }
    }
}
