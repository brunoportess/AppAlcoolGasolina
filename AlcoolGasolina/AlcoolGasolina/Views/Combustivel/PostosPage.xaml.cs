using AlcoolGasolina.Helpers;
using AlcoolGasolina.Models.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class PostosPage : ContentPage
    {
        Position PostoProximo { get; set; }
        Location MyPosition { get; set; }
        public PostosPage()
        {
            InitializeComponent();
            PostoProximo = new Position();
            //Task.Run( async() => await RotateImageContinously(true));
            RotateImageContinously(true);
            MainThread.BeginInvokeOnMainThread(MyMainThreadCode);
            
        }
        async void MyMainThreadCode()
        {
            //            MyPosition = await Utils.GetLocation();
            //Task.Run(async () => );
            try
            {
                await SetMapa();
            }
            catch (System.Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        private async Task SetMapa()
        {
            //MainThread.BeginInvokeOnMainThread(MyMainThreadCode);
            //MyPosition = await Utils.GetLocation();
            await SetMyPosition();
            var restMaps = new RestMaps();

            //var MyPosition = await Utils.GetLocation();
            /*if(MyPosition == null)
            {
                await Application.Current.MainPage.DisplayAlert("Que pena!", "Não foi possível localizar a posição do GPS", "OK");
                await Navigation.PopAsync();
            }*/
            var listaPostos = await restMaps.GetPostoAsync();
            if (listaPostos != null && MyPosition != null)
            {
                double Distancia = 999;
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

                        // VERIFICA SE É O POSTO MAIS PROXIMO DO USUARIO
                        double DistanciaAtual = Utils.Distance(MyPosition.Latitude.ToString(), MyPosition.Longitude.ToString(), obj.geometry.location.lat.ToString(), obj.geometry.location.lng.ToString());
                        if(DistanciaAtual < Distancia)
                        {
                            Distancia = DistanciaAtual;
                            PostoProximo = position;
                        }
                    }
                }
                RotateImageContinously(false);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Que pena!", "Não foi possível localizar a posição do GPS", "OK");
                await Navigation.PopAsync();
            }
        }

        private async Task SetMyPosition()
        {
            MyPosition = await Utils.GetLocation();
            if (MyPosition == null) return;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(MyPosition.Latitude, MyPosition.Longitude), Distance.FromMeters(600)));
            //RotateImageContinously(false);
            indicatorLayout.IsVisible = false;
            MyMap.IsVisible = true;
            btnPostoProximo.IsVisible = true;
            var cidade = await Utils.GetCityName(MyPosition);
            if(string.IsNullOrEmpty(cidade))
            {
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Abriu o mapa");
            } 
            else
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

        private async void btnPostoProximo_Clicked(object sender, System.EventArgs e)
        {
            var location = new Xamarin.Essentials.Location(PostoProximo.Latitude, PostoProximo.Longitude);
            var options = new Xamarin.Essentials.MapLaunchOptions { NavigationMode = Xamarin.Essentials.NavigationMode.Driving };

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }

        async void RotateImageContinously(bool rotate = true)
        {
            while (rotate) // a CancellationToken in real life ;-)
            {
                await imageLoading.RotateYTo(180, 600, Easing.CubicIn);
                await imageLoading.RotateYTo(360, 600, Easing.CubicOut);
            }
        }
    }
}