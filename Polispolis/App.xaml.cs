using Microsoft.Extensions.DependencyInjection;
using Polispolis.DAL.Interfaces;

namespace Polispolis
{
    public partial class App : Application
    {
        public App(IServiceProvider services)
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                var db = services.GetRequiredService<IDatabaseService>();
                await db.InitializeAsync();
            });


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}