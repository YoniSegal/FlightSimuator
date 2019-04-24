//using FlightSimulator.Views.windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using FlightSimulator.Views;
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
