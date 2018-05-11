using System;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Command<string> NavegarCommand { get; set; }
        

        public MainPageViewModel() : base()
        {
            NavegarCommand = new Command<string>(ExecuteNavegarCommand);
        }

        private async void ExecuteNavegarCommand(string page)
        {
            await PushAsync(page);
        }
    }
}
