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
#if DEBUG
            //HotReloader.Current.Run(this);
           /*HotReloader.Current.Run(this, new HotReloader.Configuration
            {
                //optionaly you may specify EXTENSION's IP (ExtensionIpAddress) 
                //in case your PC/laptop and device are in different subnets
                //e.g. Laptop - 10.10.102.16 AND Device - 10.10.9.12
                ExtensionIpAddress = System.Net.IPAddress.Parse("192.168.0.50") // use your PC/Laptop IP
            });*/
#endif
            AppResources.Culture = Plugin.Multilingual.CrossMultilingual.Current.DeviceCultureInfo;
            MainPage = new Controls.TransitionNavigationPage(new MainPage()
            {
                BindingContext = new ViewModels.MainViewModel()
            });
            //MainPage = new AppShell();
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
