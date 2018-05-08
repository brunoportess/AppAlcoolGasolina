using System;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Command CalcularCommand { get; set; }
        private double _valorAlcool;
        public double ValorAlcool
        {
            get { return _valorAlcool; }
            set { SetProperty(ref _valorAlcool, value); }
        }

        private double _valorGasolina;
        public double ValorGasolina
        {
            get { return _valorGasolina; }
            set { SetProperty(ref _valorGasolina, value); }
        }

        private string _valorMedia;
        public string ValorMedia
        {
            get { return _valorMedia; }
            set { SetProperty(ref _valorMedia, value); }
        }

        private string _resposta;
        public string Resposta
        {
            get { return _resposta; }
            set { SetProperty(ref _resposta, value); }
        }

        public MainPageViewModel() : base()
        {
            CalcularCommand = new Command(ExecuteCalcularCommand);
        }

        private async void ExecuteCalcularCommand()
        {
            await PushAsync(new Views.MainPage());
            /*var res = Math.Round((ValorAlcool / ValorGasolina), 2);
            ValorMedia = "A MÉDIA É DE " + res.ToString();
            if (res > Convert.ToDouble(0.7))
            {
                Resposta = "ABASTEÇA COM GASOLINA";
            }
            else
            {
                Resposta = "ABASTEÇA COM ÁLCOOL";
            }*/
        }
    }
}
