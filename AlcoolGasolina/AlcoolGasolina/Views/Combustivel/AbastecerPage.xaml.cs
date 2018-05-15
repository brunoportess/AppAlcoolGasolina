
using AlcoolGasolina.ViewModels.Combustivel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbastecerPage : ContentPage
	{
		public AbastecerPage()
		{
			InitializeComponent ();
            this.BindingContext = new AbastecerTabbedPageViewModel();
		}

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null || Convert.ToDouble(e.NewTextValue) == Convert.ToDouble(e.OldTextValue) / 100) return;
            //var valor = (e.NewTextValue.Contains(".")) ? Convert.ToDouble(e.NewTextValue) * 100 : Convert.ToDouble(e.NewTextValue);
            var valor = Convert.ToDouble(e.NewTextValue.Replace(".", ""));
            valor = valor / 100;
            entryValor.Text = valor.ToString();
        }
    }
}