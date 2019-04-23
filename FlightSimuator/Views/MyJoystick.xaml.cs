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
        //private JoystickHandler joystick;
        public MyJoystick()
        {
            DataContext = this;
            InitializeComponent();
        }

        private int boundThrottleValue;
        public int BoundThrottleValue
        {
            get { return boundThrottleValue; }
            set
            {
                if (boundThrottleValue != value)
                {
                    boundThrottleValue = value;
                    OnPropertyChanged();
                }
            }
        }


        private int boundRudderValue;
        public int BoundRudderValue
        {
            get { return boundRudderValue; }
            set
            {
                if (boundRudderValue != value)
                {
                    boundRudderValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private int boundAileronValue;
        public int BoundAileronValue
        {
            get { return boundAileronValue; }
            set
            {
                if (boundAileronValue != value)
                {
                    boundAileronValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private int boundElevatorValue;
        public int BoundElevatorValue
        {
            get { return boundElevatorValue; }
            set
            {
                if (boundElevatorValue != value)
                {
                    boundElevatorValue = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}