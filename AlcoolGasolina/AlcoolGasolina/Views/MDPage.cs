using Xamarin.Forms;

namespace AlcoolGasolina.Views
{
    public class MDPage : MasterDetailPage
    {


        public MDPage()
        {
            Detail = new NavigationPage(new MainPage()
            {
                BindingContext = new ViewModels.MainViewModel()
            });
            Master = new MainPage();
        }

    }
}
