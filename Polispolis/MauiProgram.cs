using Microsoft.Extensions.Logging;
using Polispolis.DAL;
using Polispolis.DAL.Interfaces;
using Polispolis.Factory;
using Polispolis.Factory.Interface;
using Polispolis.View;
using Polispolis.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Polispolis
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Di
            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
            builder.Services.AddTransient<AddExerciseViewModel>();
            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<AddCategoryViewModel>();
            builder.Services.AddTransient<StartExerciseViewModel>();
            builder.Services.AddTransient<CreateSessionViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<App>();
            builder.Services.AddSingleton(typeof(ICrudFactory<>), typeof(CrudFactory<>));  
            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Ensure database tables are created before the app and view models use the DB.
            // Call InitializeAsync synchronously at startup so consumers can safely query immediately.
            

            return app;
        }
    }
}
