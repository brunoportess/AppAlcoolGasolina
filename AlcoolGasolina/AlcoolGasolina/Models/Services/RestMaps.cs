using AlcoolGasolina.Helpers;
using AlcoolGasolina.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlcoolGasolina.Models.Services
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class RestMaps
    {
        public async Task<PostoCombustivel> GetPostoAsync()
        {
            var _list = new List<PostoCombustivel>();
            try
            {
                var myPosition = await Utils.GetLastLocation();
                var _lat = myPosition.Latitude.ToString().Replace(",",".");
                var _lng = myPosition.Longitude.ToString().Replace(",", ".");

                var fullUrl = Settings.GoogleMapsPlacesUrl + "&keyword=posto&location=" + _lat + "," + _lng + "&key=" + Settings.GoogleMapsToken;
                
                var client = new HttpClient
                {
                    Timeout = TimeSpan.FromMilliseconds(5000),
                    //BaseAddress = new Uri(Settings.GoogleMapsPlacesUrl+ "&location=" + _lat + "," + _lng + "&key=" + Settings.GoogleMapsToken)
                };
                
                //var result = await client.GetAsync("&location="+ _lat + ","+ _lng + "&key="+Settings.GoogleMapsToken);
                var result = await client.GetAsync(fullUrl);
                if (!result.IsSuccessStatusCode) return null;

                var resultContent = await result.Content.ReadAsStringAsync();
                //var result1 = JsonConvert.DeserializeObject<dynamic>(resultContent);
                //var lista = new List<PostoCombustivel>(result1.results);
                var lista = JsonConvert.DeserializeObject<PostoCombustivel>(resultContent);
                return lista;
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RestMap error: " + ex.Message);
                return null;
            }
        }
    }
}
