using Polispolis.ViewModel;

namespace Polispolis.View;

public partial class StartExercisePage : ContentPage
{
	private readonly StartExerciseViewModel _viewModel;
	public StartExercisePage(StartExerciseViewModel viewModel)
	{
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
        _ = _viewModel.InitializeAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Ensure view model initialization runs after page appears and after DI/startup initialization.
        await _viewModel.InitializeAsync().ConfigureAwait(false);
    }
}