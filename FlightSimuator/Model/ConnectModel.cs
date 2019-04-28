using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ConnectModel
    {
        Client client;
        Server server;
        public ConnectModel()
        {
            client = Client.getInstance();
            server = Server.getInstance();
        }

        public void connect()
        {
            server.connect_server();
            StartRead();
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = value;
            }
        }

        private double lon;
        public double Lon
        {
            get { return lon; }

            set
            {
                lon = value;
            }
        }

        // read input in a new thread, notify view model about the new data
        void StartRead()
        {
            new Task(delegate ()
            {
                while (true)
                {
                    string[] args = server.Read();
                    FlightBoardViewModel.Instance.Lon = Convert.ToDouble(args[0]);
                    FlightBoardViewModel.Instance.Lat = Convert.ToDouble(args[1]);
                }
            }).Start();
        }
    }
}