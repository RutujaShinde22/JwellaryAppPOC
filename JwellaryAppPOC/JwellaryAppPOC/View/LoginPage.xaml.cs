﻿using JwellaryAppPOC.ViewModels;
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
	public partial class LoginPage : ContentPage
	{
        private LoginViewModel loginViewModel;
        public LoginPage ()
		{
			InitializeComponent ();
            loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel ;
		}

        
    }
}