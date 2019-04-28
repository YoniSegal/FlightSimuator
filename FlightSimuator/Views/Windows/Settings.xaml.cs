using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using FlightSimulator.ViewModels.Windows;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for setting.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsWindowViewModel sh;
        public Settings()
        {
            InitializeComponent();
            sh = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
            DataContext = sh;
        }

        private void CancelCommand(object sender, RoutedEventArgs e)
        {
            sh.ReloadSettings();
            this.Close();
        }

        private void OkCommand(object sender, RoutedEventArgs e)
        {
            sh.SaveSettings();
             this.Close();
        }
    }
}
