using Polispolis.View;
using System.Threading.Tasks;

namespace Polispolis
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        
        private async void AddExerciseButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddExercisePage));
        }
    }
}
