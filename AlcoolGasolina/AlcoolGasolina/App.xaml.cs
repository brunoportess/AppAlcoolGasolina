using AlcoolGasolina.Views;

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

			MainPage = new NavigationPage(new MainPage()
            {
                BindingContext = new ViewModels.MainViewModel()
            });
            //MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
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
