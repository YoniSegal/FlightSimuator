using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        public double Aileron { get; set; }
        public double Elevator { get; set; }
        public double Rudder { get; internal set; }
        public double Throttle { get; internal set; }
        static VirtualJoystickEventArgs instance = null;


        internal static VirtualJoystickEventArgs getInstance()
        {
            if (instance == null)
            {
                instance = new VirtualJoystickEventArgs();
                return instance;
            }
            else return instance;
        }
    }
}
