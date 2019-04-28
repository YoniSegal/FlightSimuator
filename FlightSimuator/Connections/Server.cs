using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using FlightSimuator.Model;

namespace FlightSimulator.Model
{
    class Server
    {
        static Server instance = null;
        private string serverIp = "127.0.0.1";
        private int serverPort = 5400;
        Int32 port=5400;
        IPAddress ip;
        TcpClient client;
        public bool isConnected = false;
        private BinaryReader reader;
        private TcpListener listener;

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
            port = ApplicationSettingsModel.Instance.FlightInfoPort;
            ip = IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP);
            IPEndPoint ep = new IPEndPoint(ip, port);
            listener = new TcpListener(ep);
            listener.Start();
        }

        public string[] Read()
        {
            if (!isConnected)
            {
                client = listener.AcceptTcpClient();
                isConnected = true;
                reader = new BinaryReader(client.GetStream());
            }
            string input = ""; // input will be stored here
            char s;
            while ((s = reader.ReadChar()) != '\n') input += s; // read untill \n
            string[] param = input.Split(','); // split by comma
            string[] ret = { param[0], param[1] }; // lon nad lat only
            return ret;

        }
    }
}
