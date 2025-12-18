using Polispolis.Factory.Interface;
using Polispolis.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Polispolis.ViewModel
{
    public class AddCategoryViewModel
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
                }
            }
        }

        public ICommand SaveCategoryCommand { get; }
        public AddCategoryViewModel(ICrudFactory<Category> categoryCrudFactory)
        {
            _categoryCrudFactory = categoryCrudFactory ?? throw new ArgumentNullException(nameof(categoryCrudFactory));
            SaveCategoryCommand = new Command(async () => await OnSaveCategoryClickedAsync());
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
    }
}
