using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Polispolis.ViewModel
{
    public class AddExerciseViewModel : INotifyPropertyChanged
    {
        public string ExerciseName { get => _exerciseName; set 
            {
                if(_exerciseName != value)
                {
                    _exerciseName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _exerciseName { get; set; }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
