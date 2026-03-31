using Polispolis.ViewModel;

namespace Polispolis.View;

public partial class CreateSession : ContentPage
{
	private readonly CreateSessionViewModel _viewModel;
	public CreateSession(CreateSessionViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.InitializeAsync();
    }
}