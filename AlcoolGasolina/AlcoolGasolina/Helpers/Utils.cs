using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlcoolGasolina.Helpers
{
    public static class Utils
    {
        public static async Task<Position> GetLocation()
        {
            //pega a posicao do usuario com o plugin do james
            var locator = Plugin.Geolocator.CrossGeolocator.Current;
            //precisão de distancia do gps
            locator.DesiredAccuracy = 50;
            //pega latitude e longitude
            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(5000));
            //seta o nome da cidade na variavel
            //var cidade = await GetCityName(position.Latitude.ToString(), position.Longitude.ToString());
            //Debug.WriteLine("Cidade Atual: " + cidade);
            return position;
            //return restUtils.GetCityName(Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync);
        }

        public static async Task<Position> GetLastLocation()
        {
            //pega a posicao do usuario com o plugin do james
            var locator = Plugin.Geolocator.CrossGeolocator.Current;
            //precisão de distancia do gps
            locator.DesiredAccuracy = 50;
            //pega latitude e longitude
            var position = await locator.GetLastKnownLocationAsync();
            //seta o nome da cidade na variavel
            //var cidade = await GetCityName(position.Latitude.ToString(), position.Longitude.ToString());
            //Debug.WriteLine("Cidade Atual: " + cidade);
            return position;
            //return restUtils.GetCityName(Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync);
        }

        public static async Task<PermissionStatus> CheckPermissions(Permission permission)
        {
            var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            bool request = false;
            if (permissionStatus == PermissionStatus.Denied)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {

                    var title = $"Permissão {permission}";
                    var question = $"Para usar esta aplicação requer permissão de {permission}.";
                    var positive = "Configurações";
                    var negative = "Talvez depois";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                    if (task == null)
                        return permissionStatus;

                    var result = await task;
                    if (result)
                    {
                        await CrossPermissions.Current.RequestPermissionsAsync(permission);
                        //CrossPermissions.Current.OpenAppSettings();
                    }

                    return permissionStatus;
                }

                request = true;

            }

            if (request || permissionStatus != PermissionStatus.Granted)
            {
                var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(permission);

                if (!newStatus.ContainsKey(permission))
                {
                    return permissionStatus;
                }

                permissionStatus = newStatus[permission];

                if (newStatus[permission] != PermissionStatus.Granted)
                {
                    permissionStatus = newStatus[permission];
                    var title = $"Permissão {permission}";
                    var question = $"Para usar esta aplicação requer permissão de {permission}.";
                    var positive = "Configurações";
                    var negative = "Talvez depois";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                    if (task == null)
                        return permissionStatus;

                    var result = await task;
                    if (result)
                    {
                        //await CrossPermissions.Current.RequestPermissionsAsync(permission);
                        CrossPermissions.Current.OpenAppSettings();

                    }
                    return permissionStatus;
                }
            }

            return permissionStatus;
        }
    }
}
