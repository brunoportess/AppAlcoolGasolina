using System;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels
{
    public class CalcularPageViewModel : ViewModelBase
    {
        public Command CalcularCommand { get; set; }
        private string _valorAlcool;
        public string ValorAlcool
        {
            get { return _valorAlcool; }
            set { SetProperty(ref _valorAlcool, value); }
        }

        private string _valorGasolina;
        public string ValorGasolina
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

        public CalcularPageViewModel() : base()
        {
            CalcularCommand = new Command(ExecuteCalcularCommand);
        }

        private async void ExecuteCalcularCommand()
        {
            if (string.IsNullOrEmpty(ValorAlcool) || string.IsNullOrEmpty(ValorGasolina))
            {
                await DisplayAlert("Oops", "Preencha todos os campos", "OK");
            }
            else
            {
                var res = Math.Round((Convert.ToDouble(ValorAlcool) / Convert.ToDouble(ValorGasolina)), 2);
                ValorMedia = "A MÉDIA É DE " + res.ToString();
                if (res > Convert.ToDouble(0.7))
                {
                    Resposta = "ABASTEÇA COM GASOLINA";
                }
                else
                {
                    Resposta = "ABASTEÇA COM ÁLCOOL";
                }
            }

        }
    }
}
