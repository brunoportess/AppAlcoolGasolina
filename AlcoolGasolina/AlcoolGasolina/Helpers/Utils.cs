using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
