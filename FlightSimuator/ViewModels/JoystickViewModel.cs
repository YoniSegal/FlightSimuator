using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimuator.Model;
using FlightSimulator.Model;
using FlightSimulator.Model.EventArgs;


namespace FlightSimulator.ViewModels
{
    class JoystickViewModel
    {
        private MyJoystickModel model = new MyJoystickModel();

        // paths to simulator data, in order to know which set command to send
        private readonly string throttlePath = " /controls/engines/current-engine/throttle ";
        private readonly string rudderePath = " /controls/flight/rudder ";
        private readonly string aileronPath = " /controls/flight/aileron ";
        private readonly string elevatorPath = " /controls/flight/elevator ";

        // always return the same object
        private VirtualJoystickEventArgs vJoystick = VirtualJoystickEventArgs.getInstance();
        // property of rudder value
        public double BoundRudderValue
        {
            set
            {
                vJoystick.Rudder = value;
                model.Send("set" + rudderePath + Convert.ToString(value));
            }
        }
        // property of throttel value
        public double BoundThrottleValue
        {
            set
            {
                vJoystick.Throttle = value;
                model.Send("set" + throttlePath + Convert.ToString(value));
            }
        }
        // property of Ailron value
        public double AilronCommand
        {
            set { model.Send("set" + aileronPath + Convert.ToString(value)); }
        }
        // property of Elevator value
        public double ElevatorCommand
        {
            set { model.Send("set" + elevatorPath + Convert.ToString(value)); }
        }


    }

}