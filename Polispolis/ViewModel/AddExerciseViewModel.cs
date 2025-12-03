using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Polispolis.Model;

namespace Polispolis.ViewModel
{
    public class AddExerciseViewModel : INotifyPropertyChanged
    {
        private string _exerciseName { get; set; }
        public string ExerciseName { get => _exerciseName; set 
            {
                if(_exerciseName != value)
                {
                    _exerciseName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _exerciseDescription { get; set; }
        public string ExerciseDescription { get => _exerciseDescription; set 
            {
                if(_exerciseDescription != value)
                {
                    _exerciseDescription = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _exerciseGoal { get; set; }
        public double ExerciseGoal { get => _exerciseGoal; set 
            {
                if(_exerciseGoal != value)
                {
                    _exerciseGoal = value;
                    OnPropertyChanged();
                }
            }
        }
        private Exercise.Units? _exerciseUnit { get; set; }
        public Exercise.Units? ExerciseUnit
        {
            get => _exerciseUnit; set
            {
                if(_exerciseUnit != value)
                {
                    _exerciseUnit = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Exercise.Units> _exerciseUnitList;
        public ObservableCollection<Exercise.Units> ExerciseUnitList
        {
            get => _exerciseUnitList;
            set
            {
                if(_exerciseUnitList != value)
                {
                    _exerciseUnitList = value;
                    OnPropertyChanged();
                }
            }
        }
        public AddExerciseViewModel()
        {
            ExerciseName = string.Empty;
            ExerciseDescription = string.Empty;
            ExerciseUnitList = new ObservableCollection<Exercise.Units>(
            (Exercise.Units[])Enum.GetValues(typeof(Exercise.Units)));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task OnSaveExerciseClicked()
        {
            if(!string.IsNullOrEmpty(ExerciseName) && !string.IsNullOrEmpty(ExerciseDescription)
                && !double.IsNaN(ExerciseGoal))
            {
                //Notify user
                return;
            }
        }

    }
}
