// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AlcoolGasolina.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string GoogleMapsTokenkey = "AIzaSyBbla1DKY6l8d1iZ6JMR5m4gMeda3-8J0I";
        private static readonly string GoogleMapsTokensDefault = "AIzaSyBbla1DKY6l8d1iZ6JMR5m4gMeda3-8J0I";

        #endregion


        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(GoogleMapsTokenkey, GoogleMapsTokensDefault);
            set => AppSettings.AddOrUpdateValue(GoogleMapsTokenkey, value);
        }

    }
}