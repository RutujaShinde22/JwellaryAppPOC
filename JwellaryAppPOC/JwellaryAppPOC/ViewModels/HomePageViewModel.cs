using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JwellaryAppPOC.ViewModels
{
   public class HomePageViewModel
    {
        public ICommand NecklessSelected { get; set; }
        public ICommand RingSelected { get; set; }
        public ICommand BangelSelected { get; set; }
        public ICommand EarringSelected { get; set; }


        public HomePageViewModel()
        {
            this.NecklessSelected = new Command(this.Neckless);
            this.RingSelected = new Command(this.Ring);
            this.BangelSelected = new Command(this.Bangel);
            this.EarringSelected = new Command(this.Earring);
        }

        private void Earring(object obj)
        {
            App.NavigationService.PushAsync(App.NecklessPageKey, true);
        }

        private void Bangel(object obj)
        {
            App.NavigationService.PushAsync(App.NecklessPageKey, true);
        }

        private void Ring(object obj)
        {
            App.NavigationService.PushAsync(App.NecklessPageKey, true);
        }

        private void Neckless(object obj)
        {
            App.NavigationService.PushAsync(App.NecklessPageKey, true);
        }
    }
}
