using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimuator.Model;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }

        
        public void connect()
        {
            ConnectModel c = new ConnectModel();
            c.connect();
        }
        
    }
}
