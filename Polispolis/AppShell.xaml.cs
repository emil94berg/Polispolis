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
            Routing.RegisterRoute(nameof(View.AddCategoryPage), typeof(View.AddCategoryPage));
            Routing.RegisterRoute(nameof(View.StartExercisePage), typeof(View.StartExercisePage));
            Routing.RegisterRoute(nameof(View.CreateSession), typeof(View.CreateSession));
        }
    }
}
