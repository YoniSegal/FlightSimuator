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
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for setting.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingHandler sh;
        public Settings()
        {
            InitializeComponent();
            sh = new SettingHandler();
            DataContext = sh;
        }

        private void CancelCommand(object sender, RoutedEventArgs e)
        {
            sh.load();
            this.Close();
        }

        private void OkCommand(object sender, RoutedEventArgs e)
        {
            sh.save();
            this.Close();
        }
    }
}
