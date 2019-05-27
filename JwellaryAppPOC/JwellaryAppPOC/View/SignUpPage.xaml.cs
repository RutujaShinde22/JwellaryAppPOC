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
	public partial class SignUpPage : ContentPage
	{
        SignUpViewModel signUpViewModel;
        public SignUpPage ()
		{
			InitializeComponent ();
            signUpViewModel = new SignUpViewModel();
            BindingContext = signUpViewModel;
            
		}

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = JwellaryAppPOC.Helpers.ValidatorHelper.NameIsValid(e.NewTextValue);
            if(result)
            {
                FirstName.TextColor = Color.Black;
               
            }
            else
            {
                FirstName.TextColor = Color.Red;
               
                
            }
        }
       

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = JwellaryAppPOC.Helpers.ValidatorHelper.NameIsValid(e.NewTextValue);
            if (result)
            {
                LastName.TextColor = Color.Black;
            }
            else
            {
                LastName.TextColor = Color.Red;
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = JwellaryAppPOC.Helpers.ValidatorHelper.EmailIsValid(e.NewTextValue);
            if (result)
            {
                Email.TextColor = Color.Black;
            }
            else
            {
                Email.TextColor = Color.Red;
            }

        }

        
    }
}