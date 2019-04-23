using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class SettingHandler
    {
        ApplicationSettingsModel asm;
        private string flightServerIP;
        private string flightInfoPort;
        private string flightCommandPort;
        private Server server;
        private Client client;
        public string FlightServerIP
        {
            set
            {
                server.ServerIp = value;
            }
        }
        public string FlightInfoPort {
            set
            {
                server.ServerPort = int.Parse(value);
            }
        }
        public string FlightCommandPort {
            set {
                client.ClientPort = int.Parse(value);
            }
        }
        public SettingHandler()
        {
            server = Server.getInstance();
            client = Client.getInstance();
            asm = new ApplicationSettingsModel();
        }

        public void save()
        {
            asm.SaveSettings();
        }
        public void load()
        {
            asm.ReloadSettings();
        }
    }
}
