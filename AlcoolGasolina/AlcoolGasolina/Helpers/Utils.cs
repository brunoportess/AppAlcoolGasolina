using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Collections.Generic;

namespace AlcoolGasolina.Helpers
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public static class Utils
    {
        public static async Task<Location> GetLocation()
        {
            try
            {
                //pega latitude e longitude
                var position = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMilliseconds(5000)));
                if(position == null)
                {
                    var lastPosition = await GetLastLocation();
                    return lastPosition;
                }
                return position;
            }
            catch (Exception e)
            {
                Crashes.TrackError(e, new Dictionary<string, string>{
                    { "Classe", "Utils" },
                    { "Metodo", "GetLocation" },
                    { "Linha", "31" }
                });
                return null;
                
            }
        }

        public static async Task<Location> GetLastLocation()
        {
            try
            {
                //pega latitude e longitude
                var position = await Geolocation.GetLastKnownLocationAsync();
                return position;
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"ERROR GET LAST LOCATION: {ex.Message}");
                Crashes.TrackError(ex, new Dictionary<string, string>{
                    { "Classe", "Utils" },
                    { "Metodo", "GetLastLocation" },
                    { "Linha", "55" }
                });
                return null;
            }
        }

        public static async Task<PermissionStatus> CheckPermissions(Permission permission)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Location))
                    status = results[Permission.Location];
            }

            return status;
        }

        public static async Task GetPermissionLocation()
        {
            //PRIMEIRO VERIFICA SE TEM PERMISSAO DE LOCALIZACAO
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Location))
                    _ = results[Permission.Location];
            }
        }

        public static async Task GetPermissionStorage()
        {
            //PRIMEIRO VERIFICA SE TEM PERMISSAO DE LOCALIZACAO
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Storage))
                    _ = results[Permission.Storage];
            }
        }

        public static double Distance(string lat01, string long01, string lat02, string long02)
        {
            if (string.IsNullOrEmpty(lat01) || string.IsNullOrEmpty(long01) || string.IsNullOrEmpty(lat02) || string.IsNullOrEmpty(long02)) return 0;
            var lat1 = Convert.ToDouble(lat01.Replace(".", ","), new CultureInfo("pt-BR"));
            var lon1 = Convert.ToDouble(long01.Replace(".", ","), new CultureInfo("pt-BR"));
            var lat2 = Convert.ToDouble(lat02.Replace(".", ","), new CultureInfo("pt-BR"));
            var lon2 = Convert.ToDouble(long02.Replace(".", ","), new CultureInfo("pt-BR"));

            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            var distancia = Convert.ToDouble(dist * 1.609344, new CultureInfo("pt-BR"));

            string GatoLouco = distancia.ToString("N3").Replace(",", "").Replace(".", "");

            distancia = double.Parse(GatoLouco) / 1000.00 * 1.837979094076655;

            return distancia;
        }

        public static async Task<string> GetCityName(Location location)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var latitude = location.Latitude.ToString().Replace(",", ".");
                    var longitude = location.Longitude.ToString().Replace(",", ".");
                    client.Timeout = TimeSpan.FromMilliseconds(3000);
                    var result = await client.GetAsync("https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude + "&key=" + Settings.GoogleMapsToken);
                    if (!result.IsSuccessStatusCode) return null;
                    var resultContent = await result.Content.ReadAsStringAsync();
                    var result1 = JsonConvert.DeserializeObject<dynamic>(resultContent);
                    var res = result1.results[0].address_components[3].long_name;
                    return res;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
