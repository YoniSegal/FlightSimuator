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

        #region Singleton
        private static FlightBoardViewModel m_Instance = null;
        public static FlightBoardViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightBoardViewModel();
                }
                return m_Instance;
            }
        }
        #endregion

        private ICommand settingsCommand; // Settings command for settings button
        public ICommand SettingsCommand { get { return settingsCommand ?? (settingsCommand = new CommandHandler(() => Settings_Click())); } }

        public void Settings_Click()
        {
            Settings set = new Settings();
            set.Show();
        }

        private ICommand connectsCommand; // Settings command for settings button
        public ICommand ConnectsCommand { get { return connectsCommand ?? (connectsCommand = new CommandHandler(() => connect())); } }
        private double lon;
        public double Lon
        {
            get { return lon; } set { lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
        private double lat;
        public double Lat
        {
            get { return lat; }
            set { lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        
        public void connect()
        {
            FlightBoardModel fbm = new FlightBoardModel();
            fbm.connect();
        }
        
    }
}
