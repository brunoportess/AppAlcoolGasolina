using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AlcoolGasolina.Views;

namespace AlcoolGasolina
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routes.Add("MainPage", typeof(MainPage));
            Routes.Add("CalcularPage", typeof(CalcularPage));
            Routes.Add("AbastecerPage", typeof(Views.Combustivel.AbastecerTabbedPage));
            Routes.Add("HistoricoPage", typeof(Views.Combustivel.HistoricoPage));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        async Task NavigateToRandomPageAsync()
        {
            string animalName = null;

            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location.AbsoluteUri}?name={animalName}");
            Shell.Current.FlyoutIsPresented = false;

            
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
