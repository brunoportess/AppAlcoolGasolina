using AlcoolGasolina.Models.Entities;
using AlcoolGasolina.ViewModels;
using System;
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
            this.BindingContext = new RootViewModel();
            Detail = new NavigationPage(new CalcularPage());

        }

        private void ListViewMenu_Click(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ItemMenu;
            var pageType = Type.GetType("AlcoolGasolina.Views."+ item.PageUrl);
            var _page = Activator.CreateInstance(pageType) as Page;
            Detail = new NavigationPage(_page);
            listaMenu.SelectedItem = null;
            IsPresented = false;
        }
    }
}