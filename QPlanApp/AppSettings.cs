using Xamarin.Essentials;

namespace QPlanApp.Settings
{
	public static class AppSettings
    {
        //IF YOU DEPLOY YOUR OWN ENDPOINT REPLACE THE VALUEW BELOW

        //App Center
        const string defaultAppCenterAndroid = "b3b1403c-3f9d-4c77-805e-9c002de6ddf7";
        const string defaultAppCenteriOS = "7a2a290b-07b0-47dc-9dcd-15461e894e6d";

        static string defaultRestaurantsEndpoint;
        static string defaultSettingsFileUrl;

        // Maps
        const string defaultBingMapsApiKey = "AkSuJ-YtW4VDvIzErxK3ke2ILQD1muWwS2KN2QvhqHobx4YBEIYqkEVBLyx1LYby";
        public const string DefaultFallbackMapsLocation = "40.4165000,-3.7025600"; //Lat, long (MADRID)


        const string root = "https://backend.smarthotel360.com/";

        static AppSettings()
        {
            defaultRestaurantsEndpoint = $"{root}hotels-api";
		}


        // API Endpoints

        public static string RestaurantsEndpoint
        {
            get => Preferences.Get(nameof(RestaurantsEndpoint), defaultRestaurantsEndpoint);
            set => Preferences.Set(nameof(RestaurantsEndpoint), value);
        }

        // Other settings

        public static string BingMapsApiKey
        {
            get => Preferences.Get(nameof(BingMapsApiKey), defaultBingMapsApiKey);
            set => Preferences.Set(nameof(BingMapsApiKey), value);
        }

        public static string SettingsFileUrl
        {
            get => Preferences.Get(nameof(SettingsFileUrl), defaultSettingsFileUrl);
            set => Preferences.Set(nameof(SettingsFileUrl), value);
        }

        public static string FallbackMapsLocation
        {
            get => Preferences.Get(nameof(FallbackMapsLocation), DefaultFallbackMapsLocation);
            set => Preferences.Set(nameof(FallbackMapsLocation), value);
        }

        public static string AppCenterAnalyticsAndroid
        {
            get => Preferences.Get(nameof(AppCenterAnalyticsAndroid), defaultAppCenterAndroid);
            set => Preferences.Set(nameof(AppCenterAnalyticsAndroid), value);
        }

        public static string AppCenterAnalyticsIos
        {
            get => Preferences.Get(nameof(AppCenterAnalyticsIos), defaultAppCenteriOS);
            set => Preferences.Set(nameof(AppCenterAnalyticsIos), value);
        }

    }
}
