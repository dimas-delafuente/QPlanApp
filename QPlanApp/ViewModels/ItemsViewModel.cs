using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using QPlanApp.Models;
using QPlanApp.Views;
using System.Linq;

namespace QPlanApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Restaurants = new ObservableCollection<Restaurant>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Restaurant>(this, "AddItem", async (obj, restaurant) =>
            {
                var newRestaurant = restaurant as Restaurant;
                Restaurants.Add(newRestaurant);
                await DataStore.AddItemAsync(newRestaurant);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Restaurants.Clear();
                var restaurants = await DataStore.GetItemsAsync(true);
                foreach (var restaurant in restaurants)
                {
                    Restaurants.Add(restaurant);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}