

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /*
         * Metodo BALIVO
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        */

        #region [property Monkey Nights]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public bool IsNotBusy { get => !_isBusy; }

        /*protected Application CurrentApplication
        {
            get { return Application.Current; }
        }*/

        #region [ Navegação ]

        protected async Task PushAsync(Page page) => await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(page));

        protected async Task PushModalAsync(Page page) => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page));

        protected void MainPage(Page page) => Application.Current.MainPage = new NavigationPage(page);

        protected Task PopAsync(bool animated = true) => Application.Current.MainPage.Navigation.PopAsync(animated);

        #endregion


        #region [ Alert ]
        
        public async Task DisplayAlert(string title, string message, string cancel) => await Application.Current.MainPage.DisplayAlert(title, message, cancel);

        public async Task DisplayAlert(string title, string message, string accept, string cancel) => await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

        #endregion
    }
}