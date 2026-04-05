using Polispolis.Factory.Interface;
using Polispolis.Model;
using Polispolis.Services.Interfaces;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Polispolis.ViewModel
{
    public class CreateSessionViewModel : INotifyPropertyChanged
    {
        private ICrudFactory<Category> _categoryCrudFactory;
        private ICrudFactory<Exercise> _exerciseCrudFactory;
        private ICrudFactory<SessionTemplate> _sessionTemplateCrudFactory;
        private IExerciseService _exerciseService;
       
        public CreateSessionViewModel(ICrudFactory<Category> categoryCrudFactory, 
            ICrudFactory<Exercise> exerciseCrudFactory, 
            IExerciseService exerciseService,
            ICrudFactory<SessionTemplate> sessionTemplateCrudFactory)
        {
            _categoryCrudFactory = categoryCrudFactory;
            _exerciseCrudFactory = exerciseCrudFactory;
            _sessionTemplateCrudFactory = sessionTemplateCrudFactory;
            _exerciseService = exerciseService;
            RemoveExerciseOptionCommand = new Command(async () => await OnRemoveExerciseOption());
            AddExerciseOptionCommand = new Command(async () => await OnAddExerciseOption());
            SaveSessionTemplateCommand = new Command(async () => await OnSaveSessionTemplateAsync());
        }
        public ICommand RemoveExerciseOptionCommand { get; }
        public ICommand AddExerciseOptionCommand { get;  }
        public ICommand SaveSessionTemplateCommand { get; }
        private string _sessionName;
        public string SessionName { get => _sessionName; 
            set
            {
                if(_sessionName != value)
                {
                    _sessionName = value;
                    OnPropertyChanged();
                }
            }
        }

        
        private ObservableCollection<Exercise> _addExerciseCollection = new();
        public ObservableCollection<Exercise> AddExerciseCollection { get => _addExerciseCollection;
            set
            {
                if(_addExerciseCollection != value)
                {
                    _addExerciseCollection = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Category> _categoryList = new();
        public ObservableCollection<Category> CategoryList { get => _categoryList;
            set
            {
                if(_categoryList != value)
                {
                   _categoryList = value;
                    OnPropertyChanged();
                    OnChangeExerciseList();
                }
            } 
        }

        private ObservableCollection<Exercise> _categoryExerciseList = new();
        public ObservableCollection<Exercise> CategoryExerciseList { get => _categoryExerciseList;
            set
            {
                if(_categoryExerciseList != value)
                {
                    _categoryExerciseList = value;
                    OnPropertyChanged();
                }    
            }
        }
        private Exercise _selectedExercise;
        public Exercise SelectedExercise { get => _selectedExercise;
        set
            {
                if(_selectedExercise != value)
                {
                    _selectedExercise = value;
                    OnPropertyChanged();
                }
            }
        }


        private async Task OnChangeExerciseList()
        {
            CategoryExerciseList.Clear();
            CategoryExerciseList = await _exerciseCrudFactory.GetAllAsync();
        }


        private async Task OnRemoveExerciseOption()
        {
            if(AddExerciseCollection.Count > 0)
            {
                AddExerciseCollection.RemoveAt(AddExerciseCollection.Count - 1);
            }
        }
        private async Task OnAddExerciseOption()
        {
            AddExerciseCollection.Add(new Exercise());
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task InitializeAsync()
        {
            CategoryList = await _categoryCrudFactory.GetAllAsync();
        }
        public async Task OnSaveSessionTemplateAsync()
        {
            if (string.IsNullOrEmpty(SessionName))
            {
                await Shell.Current.DisplayAlertAsync("Please enter a session name", "Session name cannot be empty", "OK");
                return;
            }
            else
            {
                var newSessionTemplate = new SessionTemplate
                {
                    Name = SessionName
                };
                await _sessionTemplateCrudFactory.CreateAsync(newSessionTemplate);
                

                foreach (var item in AddExerciseCollection)
                {
                    var sessionExercise = new SessionExercise
                    {
                        ExerciseId = item.Id,
                        SessionTemplateId = newSessionTemplate.Id
                    };
                }





                
            }
        }
    }
}
