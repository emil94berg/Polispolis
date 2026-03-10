using Polispolis.Factory.Interface;
using Polispolis.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Polispolis.ViewModel
{
    public class AddCategoryViewModel : INotifyPropertyChanged
    {
        private readonly ICrudFactory<Category> _categoryCrudFactory;

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                if(_categoryName != value)
                {
                    _categoryName = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Category> _myCategories;
        public ObservableCollection<Category> MyCategories
        {
            get => _myCategories;
            set
            {
                if(_myCategories != value)
                {
                    _myCategories = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCategoryCommand { get; }
        public ICommand UpdateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }
        public AddCategoryViewModel(ICrudFactory<Category> categoryCrudFactory)
        {
            _categoryCrudFactory = categoryCrudFactory ?? throw new ArgumentNullException(nameof(categoryCrudFactory));
            SaveCategoryCommand = new Command(async () => await OnSaveCategoryClickedAsync());
            UpdateCategoryCommand = new Command<Category>(async (category) => await OnClickUpdateCategory(category));
            DeleteCategoryCommand = new Command<Category>(async (category) => await OnClickDeleteCategory(category));

        }

        public async Task InitializeAsync()
        {
            MyCategories = await _categoryCrudFactory.GetAllAsync();
        }

        public async Task OnSaveCategoryClickedAsync()
        {
            Console.WriteLine("SaveCategoryCommand executed.");
            if (string.IsNullOrWhiteSpace(CategoryName))
            {
                await Shell.Current.DisplayAlertAsync("Error", "Category name cannot be empty.", "OK");
                return;
            }
            else
            {
                var newCategory = new Category
                {
                    Name = CategoryName
                };
                await _categoryCrudFactory.CreateAsync(newCategory);
                await Shell.Current.GoToAsync("..");
            }  
        }
        public async Task OnClickUpdateCategory(Category category)
        {
            if (category == null) return;
            string newName = await Shell.Current.DisplayPromptAsync(
                "Update Name for category",
                $"Current name: {category.Name}",
                "Save",
                "Cancel",
                initialValue: category.Name
                );

            if (string.IsNullOrEmpty(newName)) return;

            category.Name = newName;

            await _categoryCrudFactory.UpdateAsync(category);
            var index = MyCategories.IndexOf(category);
            if (index >= 0)
            {
                MyCategories[index] = category;
            }
        }
        public async Task OnClickDeleteCategory(Category category)
        {
            if (category == null) return;
            bool confirm = await Shell.Current.DisplayAlertAsync(
                "Confirm Delete",
                $"Do you want to delete '{category.Name}'?",
                "Yes",
                "Cancel");
            if (!confirm) return;
            else
            {
                await _categoryCrudFactory.DeleteAsync(category);
                MyCategories.Remove(category);
            }
        }
    }
}
