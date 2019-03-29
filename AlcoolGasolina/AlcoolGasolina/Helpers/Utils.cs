using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Diagnostics;
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
            var position = new Position();
            try
            {
                //pega a posicao do usuario com o plugin do james
                var locator = Plugin.Geolocator.CrossGeolocator.Current;
                //precisão de distancia do gps
                locator.DesiredAccuracy = 50;
                //pega latitude e longitude
                position = await locator.GetLastKnownLocationAsync();
            }
            catch (Exception e)
            {

                Debug.WriteLine($"ERROR GET LAST LOCATION: {e.Message}");
                return null;
            }
            return position;
        }

        public static async Task<PermissionStatus> CheckPermissions(Permission permission)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Location))
                    status = results[Permission.Location];
            }

            return status;
            /* var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
             if (permissionStatus != PermissionStatus.Granted)
             {
                 if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(permission))
                 {
                     await App.Current.MainPage.DisplayAlert("Need location", "Gunna need that location", "OK");
                 }

                 var results = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                 //Best practice to always check that the key exists
                 if (results.ContainsKey(permission))
                     permissionStatus = results[permission];
             }

             return permissionStatus;
             */
            /*bool request = false;
            if (permissionStatus == PermissionStatus.Denied)
            {
                if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
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

            return permissionStatus;*/
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
                    status = results[Permission.Location];
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
                    status = results[Permission.Storage];
            }
        }
    }
}
