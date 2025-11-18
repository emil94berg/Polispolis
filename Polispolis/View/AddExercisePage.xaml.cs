using Polispolis.ViewModel;

namespace Polispolis.View;

public partial class AddExercisePage : ContentPage
{
	public AddExercisePage(AddExerciseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}