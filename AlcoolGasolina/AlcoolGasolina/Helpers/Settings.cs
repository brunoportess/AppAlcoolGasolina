// Helpers/Settings.cs

namespace AlcoolGasolina.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {

        #region Setting Constants

        
        private static readonly string GoogleMapsTokensDefault = "YOU_MAPS_KEY";

        //private const string GoogleMapsPlacesUrlkey = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?type=gas_station&radius=2000";
        private static readonly string GoogleMapsPlacesUrlDefault = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?type=gas_station&radius=2000";

        #endregion


        public static string GoogleMapsToken
        {
            get => Xamarin.Essentials.Preferences.Get("GoogleMapsTokenkey", GoogleMapsTokensDefault);
            set => Xamarin.Essentials.Preferences.Set("GoogleMapsTokenkey", value);
        }

        public static string GoogleMapsPlacesUrl
        {
            get => Xamarin.Essentials.Preferences.Get("GoogleMapsPlacesUrlkey", GoogleMapsPlacesUrlDefault);
            set => Xamarin.Essentials.Preferences.Set("GoogleMapsPlacesUrlkey", value);
        }

    }
}