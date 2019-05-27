using JwellaryAppPOC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JwellaryAppPOC.ViewModels
{
   public class LoginViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public LoginViewModel()
        {
            this.LoginCommand = new Command(this.Login);
            this.SignUpCommand = new Command(this.SignUp);
        }
        private string _userName;
        private string _passwordEntry;

        public string userNameEntry
        {
            get { return _userName; }
            set { _userName = value; }
        }
        

        private string passwordEntry
        {
            get { return _passwordEntry; }
            set { _passwordEntry = value; }
        }

        public void Login(object sender)
        {
            string userName = userNameEntry;
            string password = passwordEntry;

            Customer customer = new Customer();
            customer.email = userName;
            customer.password = password;

            var body = JsonConvert.SerializeObject(customer);
            var client = new RestClient("http://shoppingappdemo.azurewebsites.net/api/LogIn");
            var request = new RestRequest();

            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                App.NavigationService.PushAsync(App.HomePageKey, true);
            }
            else
            {//temporary commented this code API is not working
                // StartActivity(typeof(ContaintPage));
                //var httpResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
                // var msg = httpResponse.SelectToken("Message").Value<string>();
                // App.Current.MainPage.DisplayAlert("Error", "Please Enter Valid UserName and Password", "Ok");
                App.NavigationService.PushAsync(App.HomePageKey, true);
            }
        }

        private void SignUp(object obj)
        {
            App.NavigationService.PushAsync(App.SignUpKey, true);
        }
    }
}
