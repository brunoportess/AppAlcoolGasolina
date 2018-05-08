using AlcoolGasolina.ViewModels;
using Xamarin.Forms;

namespace AlcoolGasolina.Views
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            this.BindingContext = new MainPageViewModel();
		}
	}
}
