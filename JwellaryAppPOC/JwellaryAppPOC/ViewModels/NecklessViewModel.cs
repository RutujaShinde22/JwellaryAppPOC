using JwellaryAppPOC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JwellaryAppPOC.ViewModels
{
    public class NecklessViewModel:NotificationObject
    {
        public ICommand tapSelectItemCommand { get; set; }
        public NecklessViewModel()

        {
            this.tapSelectItemCommand = new Command(this.tapSelectItem);
            items = new List<Item>()
            {
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" },
                new Item{Image="image",Name="Jwellery",Description="Gold",Price="7647" }
            };
        }

        private void tapSelectItem(object obj)
        {
            App.NavigationService.PushAsync(App.LoginKey, true);
        }

        private List<Item> _items;
        private Item _selectedItem;
        
       
        public List<Item>items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                App.NavigationService.PushAsync(App.SelectedItemDetailKey, SelectedItem as Item);
                OnPropertyChanged();
               
            }
        }
    }

    public class NotificationObject : INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}


