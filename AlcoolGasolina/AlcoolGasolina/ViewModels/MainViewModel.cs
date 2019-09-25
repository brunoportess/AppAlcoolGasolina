using AlcoolGasolina.Helpers;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class MainViewModel : BaseViewModel
    {
        public Command<string> NavegarCommand { get; set; }

        public MainViewModel()
        {
            NavegarCommand = new Command<string>(ExecuteNavegarCommand);
            /*Device.BeginInvokeOnMainThread(async () =>
            {
                PermissionStatus status = await Utils.CheckPermissions(Permission.Location);
            });*/
        }

        private async void ExecuteNavegarCommand(string page)
        {
            if(page.Equals("Combustivel.Postos") || page.Equals("Combustivel.AbastecerTabbedPage"))
            {
                if (page.Equals("Combustivel.Postos"))
                {
                    /*PermissionStatus status = await Utils.CheckPermissions(Permission.Location);
                    if (status != PermissionStatus.Granted)
                    {
                        await DisplayAlert("Permissão Negada", "É necessário a permissão para utilizar esta função", "OK");
                    }
                    else
                    {
                        await Navigation.PushAsync<Combustivel.PostosViewModel>();
                    }*/
                    await Navigation.PushAsync<Combustivel.PostosViewModel>();
                }
                else
                {
                    await Navigation.PushAsync<Combustivel.AbastecerTabbedViewModel>();
                }
            }
            else
            {
                await Navigation.PushAsync<CalcularViewModel>();
            }   
        }

        /*public override Task InitializeAsync(object[] args)
        {
            Task.Run(async () => {
                PermissionStatus status = await Utils.CheckPermissions(Permission.Location);
            });
            return base.InitializeAsync(args);
        }*/
    }
}
