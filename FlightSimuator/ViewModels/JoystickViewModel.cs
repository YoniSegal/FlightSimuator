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
        public double Rudder {
            set
            {
                vJoystick.Rudder = value;
                try
                {
                   model.Send("set" + rudderePath + Convert.ToString(value));
                }
                catch(Exception e) { }
            }
        }

        // property of throtte value
        public double Throttle {
            set
            {
                vJoystick.Throttle = value;
                try
                {
                    model.Send("set" + throttlePath + Convert.ToString(value));
                }
                catch(Exception e) { }
            }
        }

        // property of Ailron value
        public double BoundAilronValue
        {
            set
            {
                try
                {
                   model.Send("set" + aileronPath + Convert.ToString(value));
                }
                catch (Exception e) { }
            }
        }

        // property of Elevator value
        public double BoundElevatorValue
        {
            set
            {
                try
                {
                   model.Send("set" + elevatorPath + Convert.ToString(value));
                }
                catch (Exception e) { }
            }
        }
    }
}
