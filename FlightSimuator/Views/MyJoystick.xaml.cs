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
        public MyJoystick()
        {
            InitializeComponent();
            DataContext = new JoystickViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}