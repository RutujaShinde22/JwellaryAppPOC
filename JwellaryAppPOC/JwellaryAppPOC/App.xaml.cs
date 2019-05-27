using JwellaryAppPOC.Navigation;
using JwellaryAppPOC.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JwellaryAppPOC
{
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; } = new NavigationService();
        public static readonly string LoginKey = "LoginPage";
        public static readonly string SignUpKey = "SignUpPage";
        public static readonly string HomePageKey = "HomePage";
        public static readonly string NecklessPageKey = "NecklessPage";
        public static readonly string SelectedItemDetailKey = "SelectedItemDetailsPage";
        public static readonly string SplashPageKey = "SplashScreen";
        public App()
        {
            InitializeComponent();
            //MainPage = new SignUpPage();
            Current = this;
            NavigationService.Configure(LoginKey, typeof(LoginPage));
            NavigationService.Configure(SignUpKey, typeof(SignUpPage));
            NavigationService.Configure(HomePageKey, typeof(HomePage));
            NavigationService.Configure(NecklessPageKey, typeof(NecklessPage));
            NavigationService.Configure(SelectedItemDetailKey, typeof(SelectedItemDetailsPage));
            NavigationService.Configure(SplashPageKey, typeof(SplashScreen));
            MainPage = ((NavigationService)NavigationService).SetRootPage(SplashPageKey);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
