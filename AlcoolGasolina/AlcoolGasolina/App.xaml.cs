using AlcoolGasolina.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace AlcoolGasolina
{
    public partial class App : Application
	{
        public static string DatabasePath => System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");

        public App ()
		{

            // Initialize Live Reload.
            //LiveReload.Init();

            InitializeComponent();
            AppResources.Culture = Plugin.Multilingual.CrossMultilingual.Current.DeviceCultureInfo;
            MainPage = new NavigationPage(new MainPage()
            {
                BindingContext = new ViewModels.MainViewModel()
            });
            //MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            AppCenter.Start("android=8d4d8571-c250-4076-ad31-51890d1ea735;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
        }
    }
}
