﻿using System;
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
        ClientHandler ch;
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

        public void listenAndRead()
        {

        }

        public void connect_server()
        {

            port = ApplicationSettingsModel.Instance.FlightInfoPort;
            ip = IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP);
            IPEndPoint ep = new IPEndPoint(ip, port);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("waiting for client connection...");
            Console.WriteLine("info channel: client connected");
            //Thread thread = new Thread(() => ServisClient());
            //thread.Start();

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
