using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimuator.Model;
using System.Windows.Input;
using FlightSimulator.Views;
using System.Threading;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {


        private ICommand settingsCommand; // Settings command for settings button
        public ICommand SettingsCommand { get { return settingsCommand ?? (settingsCommand = new CommandHandler(() => Settings_Click())); } }

        public void Settings_Click()
        {
            Settings set = new Settings();
            set.Show();
        }

        private ICommand connectsCommand; // Settings command for settings button
        public ICommand ConnectsCommand { get { return connectsCommand ?? (connectsCommand = new CommandHandler(() => connect())); } }
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
