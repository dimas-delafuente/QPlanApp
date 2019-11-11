using MvvmHelpers;
using QPlanApp.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using QPlanApp.Services.Geolocator;
using Xamarin.Forms;

namespace QPlanApp.ViewModels
{
    public class RestaurantsViewModel : BaseViewModel
    {
        ObservableCollection<CustomPin> customPins;
        ObservableCollection<Restaurant> restaurants;
        private ILocationService locationService;

        public RestaurantsViewModel()
        {
            this.locationService = DependencyService.Get<ILocationService>();

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

                var location = await locationService.GetPositionAsync();
                var res = new ObservableCollection<Restaurant>();
                var pins = new ObservableCollection<CustomPin>();
                var dataRestaurants =  await DataStore.GetItemsByLocationAsync(location.Latitude, location.Longitude, 10000);

                foreach (var restaurant in dataRestaurants.Take(10))
                {
                    pins.Add(new CustomPin
                    {
                        Label = restaurant.Name,
                        Position = new Xamarin.Forms.Maps.Position(restaurant.Location.Latitude, restaurant.Location.Longitude)
                    });

                    res.Add(restaurant);
                }

                Restaurants = res;
                CustomPins = pins;
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