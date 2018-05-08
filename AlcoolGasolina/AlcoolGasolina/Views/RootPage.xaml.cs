using AlcoolGasolina.Models.Entities;
using AlcoolGasolina.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			InitializeComponent ();
            this.BindingContext = new RootPageViewModel();
            Detail = new NavigationPage(new MainPage());

        }

        private void ListViewMenu_Click(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ItemMenu;
            Detail = new NavigationPage(item.PageUrl);
            listaMenu.SelectedItem = null;
            IsPresented = false;
        }
    }
}