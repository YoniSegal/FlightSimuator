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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FlightSimulator.ViewModels;


namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MyJoystick.xaml
    /// </summary>
    public partial class MyJoystick : INotifyPropertyChanged
    {
  
        
       private JoystickViewModel joystickVM;
        
        public MyJoystick()
        {
            DataContext = this;
            InitializeComponent();
            joystickVM = new JoystickViewModel();

            Console.WriteLine(rudderSlider.Value);
            
            rudder.DataContext = this;
            elevator.DataContext = this;
            throttle.DataContext = this;
            aileron.DataContext = this;
            joystickVM.BoundRudderValue = rudderSlider.Value;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Console.WriteLine("Something changed!");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}