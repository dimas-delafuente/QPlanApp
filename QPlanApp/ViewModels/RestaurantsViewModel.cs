using MvvmHelpers;
using QPlanApp.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace QPlanApp.ViewModels
{
    public class RestaurantsViewModel : BaseViewModel
    {
        ObservableCollection<CustomPin> customPins;
        ObservableCollection<Restaurant> restaurants;

        public RestaurantsViewModel()
        {

        }

        public ObservableCollection<CustomPin> CustomPins
        {
            get => customPins;
            set => SetProperty(ref customPins, value);
        }

        public ObservableCollection<Restaurant> Restaurants
        {
            get => restaurants;
            set => SetProperty(ref restaurants, value);
        }

        public override async Task InitializeAsync()
        {
            try
            {
                IsBusy = true;
                var res = new ObservableCollection<Restaurant>();
                CustomPins = new ObservableCollection<CustomPin>();
                var dataRestaurants =  await DataStore.GetItemsAsync(true);
                CustomPins = new ObservableRangeCollection<CustomPin>();

                foreach (var restaurant in dataRestaurants.Take(10))
                {
                    CustomPins.Add(new CustomPin
                    {
                        Label = restaurant.Name,
                        Position = new Xamarin.Forms.Maps.Position(restaurant.Location.Latitude, restaurant.Location.Longitude)
                    });

                    res.Add(restaurant);
                }

                Restaurants = res;
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[Suggestions] Error retrieving data: {httpEx}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}