using System.Windows;
using FlightSimulator.Model;
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
