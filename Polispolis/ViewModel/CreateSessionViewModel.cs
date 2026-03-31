using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Polispolis.ViewModel
{
    public class CreateSessionViewModel
    {
        public ICommand RemoveExerciseOptionCommand { get; }
        public ICommand AddExerciseOptionCommand { get;  }
        public async Task InitializeAsync()
        {
            
        }
    }
}
