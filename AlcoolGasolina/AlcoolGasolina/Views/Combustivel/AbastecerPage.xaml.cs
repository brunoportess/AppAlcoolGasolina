
using AlcoolGasolina.ViewModels.Combustivel;
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
            this.BindingContext = new AbastecerPageViewModel();
		}
	}
}