using Polispolis.ViewModel;

namespace Polispolis.View;

public partial class AddCategoryPage : ContentPage
{
    private readonly AddCategoryViewModel _viewModel;
    public AddCategoryPage(AddCategoryViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }


    //private readonly AddExerciseViewModel _viewModel;

    //public AddExercisePage(AddExerciseViewModel viewModel)
    //{
    //    InitializeComponent();
    //    _viewModel = viewModel;
    //    BindingContext = _viewModel;
    //    _ = _viewModel.InitializeAsync();
    //}

    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    // Ensure view model initialization runs after page appears and after DI/startup initialization.
    //    await _viewModel.InitializeAsync().ConfigureAwait(false);
    //}
}