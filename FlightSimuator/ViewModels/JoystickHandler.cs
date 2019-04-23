using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Model.EventArgs;


namespace FlightSimulator.ViewModels
{
    class JoystickHandler
    {
        // always return the same object
        private VirtualJoystickEventArgs vJoystick = VirtualJoystickEventArgs.getInstance();
       // property of rudder value
        public double BoundRudderValue {
            set { vJoystick.Rudder =value; }
        }
        // property of throttel value
        public double BoundThrottleValue {
            set { vJoystick.Throttle = value; }
        }
        // property of Ailron value
        public double AilronCommand
        {
            get;set;
        }
        // property of Elevator value
        public double ElevatorCommand
        {
            get;set;
        }
    }

}
