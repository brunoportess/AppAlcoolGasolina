using AlcoolGasolina.Helpers;
using AlcoolGasolina.Models.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Postos : ContentPage
	{
		public Postos ()
		{
			InitializeComponent ();
            SetMapa();

        }

        private async void SetMapa()
        {
            var restMaps = new RestMaps();
            var listaPostos = await restMaps.GetPostoAsync();
            if(listaPostos != null)
            {
                foreach (var obj in listaPostos.results)
                {
                    if (obj.geometry.location.lat != 0 && obj.geometry.location.lng != 0)
                    {
                        MyMap.IsVisible = true;
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
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AbastecerPage());
        }
    }
}