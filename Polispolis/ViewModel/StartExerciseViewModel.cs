using Polispolis.Factory;
using Polispolis.Factory.Interface;
using Polispolis.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Polispolis.ViewModel
{
    public class StartExerciseViewModel : INotifyPropertyChanged
    {
        
        private readonly ICrudFactory<Category> _categoryCrudFactory;
        private ObservableCollection<Exercise> _exercises;
        public ObservableCollection<Exercise> Exercises { get => _exercises;
            set
            {
                if(_exercises != value)
                {
                    _exercises = value;
                    OnPropertyChanged();
                }
            } 
        }

        private ObservableCollection<Category> _allCategoriesCollection;
        public ObservableCollection<Category> AllCategoriesCollection
        { get => _allCategoriesCollection;
            set 
            {
                if(_allCategoriesCollection != value)
                {
                    _allCategoriesCollection = value;
                    OnPropertyChanged();
                }
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory { get => _selectedCategory;
            set
            {
                if(_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        public StartExerciseViewModel(ICrudFactory<Category> categoryFactory)
        {
            _categoryCrudFactory = categoryFactory;
        }

        public async Task InitializeAsync()
        {
            AllCategoriesCollection = await _categoryCrudFactory.GetAllAsync();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
