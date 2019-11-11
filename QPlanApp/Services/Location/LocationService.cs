using Xamarin.Essentials;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using QPlanApp.Extensions;
using QPlanApp.Settings;

namespace QPlanApp.Services.Geolocator
{
    public class LocationService : ILocationService
    {
        private readonly TimeSpan positionReadTimeout = TimeSpan.FromSeconds(5);

        public async Task<Location> GetPositionAsync()
        {
            try
            {
                Location position = await Geolocation.GetLastKnownLocationAsync();

                if (position != null)
                {
                    // Got a cahched position, so let's use it.
                    return position;
                }
                                
                position = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = positionReadTimeout
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location: " + ex);
            }

            var defaultLocation = AppSettings.DefaultFallbackMapsLocation.ParseLocation();

            return defaultLocation;
        }
    }
}