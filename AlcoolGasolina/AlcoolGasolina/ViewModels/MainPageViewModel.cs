using AlcoolGasolina.Helpers;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Threading.Tasks;
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
            if(page.Equals("Combustivel.Postos") || page.Equals("Combustivel.AbastecerTabbedPage"))
            {
                var status = PermissionStatus.Unknown;
                //verifica se possui a permissão
                if(page.Equals("Combustivel.AbastecerTabbedPage"))
                {
                    status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                }
                else
                {
                    status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                }
                
                //se nao estiver liberado, faz a solicitacao
                if (status != PermissionStatus.Granted)
                {
                    status = await Utils.CheckPermissions(Permission.Location);
                }

                var statusStr = status.ToString();
                if (statusStr.Contains("Granted"))
                {
                    await PushAsync(page);
                }
                else
                {
                    await DisplayAlert("Acesso negado", "As permissões necessárias não foram concedidas","OK");
                }
            }
            else
            {
                await PushAsync(page);
            }   
        }
    }
}
