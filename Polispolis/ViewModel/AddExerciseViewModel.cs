using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Polispolis.Model;
using Polispolis.Factory;
using Polispolis.Factory.Interface;
using System.Windows.Input;

namespace Polispolis.ViewModel
{
    public class AddExerciseViewModel : INotifyPropertyChanged
    {
        private readonly ICrudFactory<Exercise> _exerciseCrudFactory;
        private readonly ICrudFactory<Category> _categoryCrudFactory;

        private string _exerciseName;
        public string ExerciseName
        {
            get => _exerciseName;
            set
            {
                if (_exerciseName != value)
                {
                    _exerciseName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _exerciseDescription;
        public string ExerciseDescription
        {
            get => _exerciseDescription;
            set
            {
                if (_exerciseDescription != value)
                {
                    _exerciseDescription = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _exerciseGoal;
        public double ExerciseGoal
        {
            get => _exerciseGoal;
            set
            {
                if (_exerciseGoal != value)
                {
                    _exerciseGoal = value;
                    OnPropertyChanged();
                }
            }
        }
        private Exercise.Units? _exerciseUnit;
        public Exercise.Units? ExerciseUnit
        {
            get => _exerciseUnit;
            set
            {
                if (_exerciseUnit != value)
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
                if (_exerciseUnitList != value)
                {
                    _exerciseUnitList = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Category> _exerciseCatergoriesList;
        public ObservableCollection<Category> ExerciseCategoriesList
        {
            get => _exerciseCatergoriesList;
            set
            {
                if (_exerciseCatergoriesList != value)
                {
                    _exerciseCatergoriesList = value;
                    OnPropertyChanged();
                }
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory { get => _selectedCategory; 
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                }
            } 
        }
        private List<Exercise> _existingExercisesList;
        public List<Exercise> ExistingExercisesList { get => _existingExercisesList;
            set
            {
                if(_existingExercisesList != value)
                {
                    _existingExercisesList = value;
                    OnPropertyChanged();
                }
            }
        }
        //Command from view to trigger saving exercise
        public ICommand SaveExerciseCommand { get; }
        public AddExerciseViewModel(ICrudFactory<Exercise> exerciseCrudFactory,
                                    ICrudFactory<Category> categoryCrudFactory)
        {
            _exerciseCrudFactory = exerciseCrudFactory ?? throw new ArgumentNullException(nameof(exerciseCrudFactory));
            _categoryCrudFactory = categoryCrudFactory ?? throw new ArgumentNullException(nameof(categoryCrudFactory));
            _exerciseName = string.Empty;
            _exerciseDescription = string.Empty;
            _exerciseUnitList = new ObservableCollection<Exercise.Units>((Exercise.Units[])Enum.GetValues(typeof(Exercise.Units)));
            _exerciseCatergoriesList = new ObservableCollection<Category>();
            SaveExerciseCommand = new Command(async () => await OnSaveExerciseClickedAsync());
            // Do not start async work from constructor. Call InitializeAsync() after DI/page creation.
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Public initialization method that callers (page, app startup, or factory) should await.
        public async Task InitializeAsync()
        {
            await LoadCategoriesAsync().ConfigureAwait(false);
            await LoadExistingExercisesAsync().ConfigureAwait(false);
        }
        private async Task LoadExistingExercisesAsync()
        {
            var exercises = await _exerciseCrudFactory.GetAllAsync().ConfigureAwait(false);
            ExistingExercisesList = exercises;
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _categoryCrudFactory.GetAllAsync().ConfigureAwait(false);
            //Add one default category if none exist
            if (categories.Count == 0)
            {
                Category defaultCategory = new Category
                {
                    Name = "Default"
                };
                await _categoryCrudFactory.CreateAsync(defaultCategory).ConfigureAwait(false);
                categories = await _categoryCrudFactory.GetAllAsync().ConfigureAwait(false);
            }
            ExerciseCategoriesList = new ObservableCollection<Category>(categories);
        }

        public async Task OnSaveExerciseClickedAsync()
        {
            Console.WriteLine("Save Exercise Clicked");
            if (!string.IsNullOrEmpty(ExerciseName) && !string.IsNullOrEmpty(ExerciseDescription)
                && !double.IsNaN(ExerciseGoal))
            {
                Exercise exercise = new Exercise
                {
                    CategoryId = SelectedCategory.Id,
                    Name = ExerciseName,
                    Description = ExerciseDescription,
                    Goal = ExerciseGoal,
                    Unit = ExerciseUnit
                };
                await _exerciseCrudFactory.CreateAsync(exercise);
            }
        }
    }
}
