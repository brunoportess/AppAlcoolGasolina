using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class AbastecerPage : ContentPage
	{
		public AbastecerPage()
		{
			InitializeComponent ();
            pickerCombustivel.ItemsSource = new List<string>
            {
                AppResources.AlcoolText,
                AppResources.GasolinaText
            };
		}
    }
}