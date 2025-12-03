using Microsoft.Extensions.Logging;
using Polispolis.View;
using Polispolis.ViewModel;
using Polispolis.Factory.Interface;
using Polispolis.Factory;

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
            builder.Services.AddTransient<AddExerciseViewModel>();
            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton(typeof(ICrudFactory<>), typeof(CrudFactory<>));  

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
