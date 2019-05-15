using AlcoolGasolina.Helpers;
using AlcoolGasolina.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class PostosPage : ContentPage
    {
        public PostosPage()
        {
            InitializeComponent();
            SetMapa();
        }

        private async void SetMapa()
        {
            var restMaps = new RestMaps();
            var listaPostos = await restMaps.GetPostoAsync();
            if (listaPostos != null)
            {
                foreach (var obj in listaPostos.results)
                {
                    if (obj.geometry.location.lat != 0 && obj.geometry.location.lng != 0)
                    {
                        var position = new Position(obj.geometry.location.lat, obj.geometry.location.lng); // Latitude, Longitude
                        var pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = position,
                            Label = obj.name,
                            Address = obj.vicinity
                        };
                        MyMap.Pins.Add(pin);
                    }
                }
                await SetMyPosition();
            }
        }

        private async Task SetMyPosition()
        {
            var myPosition = await Utils.GetLocation();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(myPosition.Latitude, myPosition.Longitude), Distance.FromMeters(600)));
            MyMap.IsVisible = true;
            indicator.IsVisible = false;
            indicator.IsRunning = false;
            var cidade = await Utils.GetCityName(myPosition);
            if(string.IsNullOrEmpty(cidade))
            {
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Abriu o mapa");
            } else
            {
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Abriu o mapa", new Dictionary<string, string>
                {
                    {
                        "Cidade", cidade
                    }
                });
            }
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AbastecerPage());
        }
    }
}