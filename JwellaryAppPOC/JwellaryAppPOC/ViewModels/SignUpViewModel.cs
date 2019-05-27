using JwellaryAppPOC.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JwellaryAppPOC.ViewModels
{
    public class SignUpViewModel
    {
       public ICommand SubmitCommand { get; set; }
        public SignUpViewModel()
        { 
            this.SubmitCommand = new Command(this.Submit);
        }

        private void Submit(object obj)
        {
            if ( !ValidatorHelper.NameIsValid(this.FirstNameEntry))
            {
                App.Current.MainPage.DisplayAlert("Error", "Please Enter Valid First Name", "OK");
            }
            else if (!ValidatorHelper.NameIsValid(this.LastNameEntry))
            {
                App.Current.MainPage.DisplayAlert("Error", "Please Enter Valid Last Name", "OK");
            }
            else if ( !ValidatorHelper.EmailIsValid(this.EmailEntry))
            {
                App.Current.MainPage.DisplayAlert("Error", "Please Enter Valid Email", "OK");
            }
            else
            {
                App.NavigationService.PushAsync(App.LoginKey, true);
            }

        }

        public string _firstNameentry;
        public string _lastNameentry;
        public string _emailEntry;
        public string _addressEntry;
        public string __userNameEntry;
        public string _passwordEntry;
        public string _passwordReEntry;

        public string FirstNameEntry
        {
            get { return _firstNameentry; }
            set { _firstNameentry = value; }
        }
        public string LastNameEntry
        {
            get { return _lastNameentry; }
            set { _lastNameentry = value; }
        }
        public string EmailEntry
        {
            get { return _emailEntry; }
            set { _emailEntry = value; }
        }
        public string AddressEntry
        {
            get { return _addressEntry; }
            set { _addressEntry = value; }
        }
        public string UserNameEntry
        {
            get { return __userNameEntry; }
            set { __userNameEntry = value; }
        }
        public string PasswordEntry
        {
            get { return _passwordEntry; }
            set { _passwordEntry = value; }
        }
        public string PasswordReEntry
        {
            get { return _passwordReEntry; }
            set { _passwordReEntry = value; }
        }

    }
}
