using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimuator.Model
{
    class AutoPilotModel
    {
        // send commands to the simulator
        public void SendCommands(string input)
        {
            Client client = Client.getInstance();
            client.Connect_client();
            if (client.isConnected)
            {
                new Task(delegate ()
                {
                    Client.getInstance().Send(input);
                }).Start();
            } 
        }
    }
}
