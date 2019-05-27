using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JwellaryAppPOC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashScreen : ContentPage
	{
		public SplashScreen ()
		{
			InitializeComponent ();
            OnAppearing();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(2000);
            await App.NavigationService.PushAsync(App.LoginKey, true);
            
        }


    }
}