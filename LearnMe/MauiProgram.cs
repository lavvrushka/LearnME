using CommunityToolkit.Maui;
using LearnMe.Data;
using LearnMe.Service;
using LearnMe.ViewModels;
using LearnMe.Views;
using Microsoft.Extensions.Logging;

namespace LearnMe
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-Medium.ttf", "RegularFont");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MediumFont");
                    fonts.AddFont("Montserrat-Bold.ttf", "BoldFont");
                });
            builder.Services.AddSingleton<DbContext>();

            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<UserSessionRepository>();


      
            builder.Services.AddSingleton<AuthenticationService>();

            builder.Services.AddSingleton<AuthenticationViewModel>();
            builder.Services.AddSingleton<AuthenticationPage>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();

            builder.Services.AddSingleton<SignUpViewModel>();
            builder.Services.AddSingleton<SignUpPage>();

            builder.Services.AddSingleton<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
