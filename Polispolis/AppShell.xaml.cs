namespace Polispolis
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            //Routing
            Routing.RegisterRoute(nameof(View.AddExercisePage), typeof(View.AddExercisePage));
            Routing.RegisterRoute(nameof(View.LoginPage), typeof(View.LoginPage));
        }
    }
}
