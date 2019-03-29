using AlcoolGasolina.Helpers;
using Plugin.Permissions.Abstractions;
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
        }

        private async void ExecuteNavegarCommand(string page)
        {
            if(page.Equals("Combustivel.Postos") || page.Equals("Combustivel.AbastecerTabbedPage"))
            {
                var status = PermissionStatus.Unknown;

                if (page.Equals("Combustivel.Postos"))
                {
                    status = await Utils.CheckPermissions(Permission.Location);
                    if (status != PermissionStatus.Granted)
                    {
                        await DisplayAlert("Permissão Negada", "É necessário a permissão para utilizar esta função", "OK");
                    }
                    else
                    {
                        await Navigation.PushAsync<Combustivel.PostosViewModel>();
                    }
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
    }
}
