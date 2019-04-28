using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimuator.Model
{
    class MyJoystickModel
    {
        private Client client = Client.getInstance();

        public Client Client { get; }

        public void Send(string command)
        {
            client.Connect_client();
            if (Client.getInstance().isConnected)
            {
                new Thread(delegate ()
                {
                    Client.getInstance().Send(command);
                }).Start();
            }
        }
    }
}
