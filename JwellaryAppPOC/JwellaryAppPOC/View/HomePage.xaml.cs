using JwellaryAppPOC.ViewModels;
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
	public partial class HomePage : ContentPage
	{
        private HomePageViewModel homePageViewModel;
        public HomePage ()
		{
			InitializeComponent ();
            homePageViewModel = new HomePageViewModel();
            BindingContext = homePageViewModel;
		}
    }
}