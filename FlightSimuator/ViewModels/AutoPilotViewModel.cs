using FlightSimuator.Model;
using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AutoPilotModel model = new AutoPilotModel();

        private Brush background = Brushes.White; // Background color

        private string commands; // Commands to be sent
        public string Commands
        {
            get { return commands; }

            set
            {
                commands = value;
                if (!string.IsNullOrEmpty(Commands) && Background == Brushes.White) Background = Brushes.LightPink; // if background is white and no text
                else if (string.IsNullOrEmpty(Commands)) Background = Brushes.White; // if text is not empty
            }
        }
        public Brush Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                NotifyPropertyChanged("Background");
            }

        }

        #region okCommand
        // Ok command member to clear button
        private ICommand okCommand; 
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() =>
                {
                    string toBeSent = Commands;
                    // Notify view
                    NotifyPropertyChanged(Commands);
                    // put white background  
                    Background = Brushes.White;
                    // update
                    model.SendCommands(toBeSent);

                }));
            }
        }

        #endregion


        #region clearCommand
        // Clear command for clear button
        private ICommand clearCommand; 
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() =>
                {
                    Commands = "";
                    Background = Brushes.White;
                    NotifyPropertyChanged(Commands); // Notify view!
                }));
            }
        }

        #endregion

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}