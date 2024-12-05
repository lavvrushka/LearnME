using CommunityToolkit.Maui;
using LearnMe.Data;
using LearnMe.Service;
using LearnMe.ViewModels;
using LearnMe.Views;
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddDbContext<LearnMe.Data.DbContext>();

            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<GroupRepository>();
            builder.Services.AddSingleton<CardRepository>();
            builder.Services.AddSingleton<UserSessionRepository>();
            builder.Services.AddTransient<DbContextOptions<LearnMe.Data.DbContext>>();
      
            builder.Services.AddSingleton<AuthenticationService>();

            builder.Services.AddSingleton<AuthenticationViewModel>();
            builder.Services.AddSingleton<AuthenticationPage>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();

            builder.Services.AddSingleton<SignUpViewModel>();
            builder.Services.AddSingleton<SignUpPage>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<CreateCardViewModel>();
            builder.Services.AddTransient<CreateGroupViewModel>();
            builder.Services.AddTransient<CardService>();
            builder.Services.AddTransient<GroupsService>();

            builder.Services.AddTransient<UserService>();
            builder.Services.AddSingleton<ExploreViewModel>();
            builder.Services.AddSingleton<ExplorePage>();

            builder.Services.AddSingleton<UserViewModel>();
            builder.Services.AddSingleton<UserPage>();
            builder.Services.AddSingleton<BlitzViewModel>(); 

            builder.Services.AddSingleton<CreateGroupViewModel>();
            builder.Services.AddSingleton<CreateGroupPage>();

            builder.Services.AddSingleton<CreatePage>();
            builder.Services.AddSingleton<CreateEventPage>();

            builder.Services.AddSingleton<UserEventsPage>();
            builder.Services.AddSingleton<AchievementsPage>();
            builder.Services.AddSingleton<UserSettingsPage>();
            builder.Services.AddSingleton<AvatarPage>();

            builder.Services.AddSingleton<EventRepository>();
            builder.Services.AddSingleton<EventService>();
            builder.Services.AddSingleton<EventGroupRepository>();
            builder.Services.AddSingleton<EventGroupService>();
            builder.Services.AddSingleton<CreateEventViewModel>();

   



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
