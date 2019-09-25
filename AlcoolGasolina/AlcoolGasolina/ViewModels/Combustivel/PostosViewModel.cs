using System;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels.Combustivel
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    class PostosViewModel : BaseViewModel
    {
        public Command PostoProximoCommand { get; set; }
        public PostosViewModel()
        {
            PostoProximoCommand = new Command(ExecutePostoProximoCommand);
        }

        private async void ExecutePostoProximoCommand()
        {
            await DisplayAlert("SUCESSO", "Abastecimento registrado com sucesso", "OK");
        }
    }
}
