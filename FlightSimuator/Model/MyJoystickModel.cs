﻿using FlightSimulator.Model;
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
        public void Send(string command)
        {
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
