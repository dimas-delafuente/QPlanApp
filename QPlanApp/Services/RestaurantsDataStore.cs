using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using QPlanApp.Models;

namespace QPlanApp.Services
{
    public class RestaurantsDataStore : IDataStore<Restaurant>
    {
        HttpClient client;
        IEnumerable<Restaurant> restaurants;

        private const string RESTAURANTS_ENDPOINT = @"api/restaurants";

        public RestaurantsDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            restaurants = new List<Restaurant>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<Restaurant>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync(RESTAURANTS_ENDPOINT);
                var response = await Task.Run(() => JsonConvert.DeserializeObject<RootObject>(json));
                restaurants = response.Restaurants;
            }

            return restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetItemsByLocationAsync(double latitude, double longitude, double radius)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"{RESTAURANTS_ENDPOINT}/location?longitude={longitude}&latitude={latitude}&radius={radius}");
                var response = await Task.Run(() => JsonConvert.DeserializeObject<RootObject>(json));
                restaurants = response.Restaurants;
            }

            return restaurants;
        }

        public async Task<Restaurant> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/restaurant/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Restaurant>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Restaurant restaurant)
        {
            if (restaurant == null || !IsConnected)
                return false;

            var serializedrestaurant = JsonConvert.SerializeObject(restaurant);

            var response = await client.PostAsync($"api/restaurant", new StringContent(serializedrestaurant, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Restaurant restaurant)
        {
            if (restaurant == null || restaurant.Id == null || !IsConnected)
                return false;

            var serializedrestaurant = JsonConvert.SerializeObject(restaurant);
            var buffer = Encoding.UTF8.GetBytes(serializedrestaurant);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/restaurant/{restaurant.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/restaurant/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
