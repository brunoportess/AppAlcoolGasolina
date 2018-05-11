using AlcoolGasolina.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalcularPage : ContentPage
	{
		public CalcularPage ()
		{
			InitializeComponent ();
            this.BindingContext = new CalcularPageViewModel();
		}
	}
}