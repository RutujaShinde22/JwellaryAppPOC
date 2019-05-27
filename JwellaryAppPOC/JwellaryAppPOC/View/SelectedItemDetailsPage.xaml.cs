using JwellaryAppPOC.Models;
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
	public partial class SelectedItemDetailsPage : ContentPage
	{
        SelectedItemPageViewModel selectedItemPageViewModel;
        public SelectedItemDetailsPage ()
		{
			InitializeComponent ();
            selectedItemPageViewModel = new SelectedItemPageViewModel();
            BindingContext = selectedItemPageViewModel;

        }

        public SelectedItemDetailsPage(Item item) : this()
        {
            //Fetch data of selected Item
            string ImageOfSelectedItem = item.Image;
            string NameOfSelectedItem = item.Name;
            string PriceOfSelectedItem = item.Price;
            string DiscriptionOfSelectedItem = item.Description;

            //Set data for Selected Item

            SelectedItemName.Text = NameOfSelectedItem;
            SelectedItemImage.Source = ImageOfSelectedItem;
            SelectedItemPrice.Text = PriceOfSelectedItem;
            SelectedItemDiscription.Text = DiscriptionOfSelectedItem;


        }
	}
}