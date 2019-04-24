﻿using FlightSimulator.Model;
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
            if (Client.getInstance().isConnected)
            {
                new Task(delegate ()
                {
                    Client.getInstance().Send(input);
                }).Start();
            } 
        }
    }
}
