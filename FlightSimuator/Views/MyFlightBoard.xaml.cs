using System.Windows;
using System.Windows.Controls;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MyFlightBoard.xaml
    /// </summary>
    public partial class MyFlightBoard : UserControl
    {
        FlightBoardViewModel flightBoardViewModel;

        public MyFlightBoard()
        {
            InitializeComponent();
            flightBoardViewModel = new FlightBoardViewModel();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {

            flightBoardViewModel.Settings_Click();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            flightBoardViewModel.connect();            
        }
    }
}
