using AlcoolGasolina.ViewModels.Combustivel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoricoPage : ContentPage
	{
        private readonly AbastecerTabbedPageViewModel _vm;
        public HistoricoPage ()
		{
			InitializeComponent ();
            this.BindingContext = _vm = new AbastecerTabbedPageViewModel();
        }

        protected override void OnAppearing()
        {
            listHistorico.ItemsSource = _vm.ListHistorico;
        }
    }
}