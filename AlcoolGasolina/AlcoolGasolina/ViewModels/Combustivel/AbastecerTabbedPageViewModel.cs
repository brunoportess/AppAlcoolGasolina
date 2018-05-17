using AlcoolGasolina.Models.Database;
using AlcoolGasolina.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels.Combustivel
{
    public class AbastecerTabbedPageViewModel : ViewModelBase
    {
        private readonly AbastecerHistorico abastecerHistorico;
        public Command SalvarCommand { get; set; }

        private string _data;
        public string Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        private string _valor;
        public string Valor
        {
            get { return _valor; }
            set { SetProperty(ref _valor, value); }
        }

        private ObservableCollection<Abastecer> _listHistorico;
        public ObservableCollection<Abastecer> ListHistorico
        {
            get { return _listHistorico; }
            set { SetProperty(ref _listHistorico, value); }
        }

        public AbastecerTabbedPageViewModel() : base()
        {
            Data = DateTime.Now.ToString("dd/mm/yyyy");
            abastecerHistorico = new AbastecerHistorico();
            SalvarCommand = new Command(ExecuteSalvarCommand);
            Task.Run(async () => ListHistorico = await Dados());
        }

        private async Task<ObservableCollection<Abastecer>> Dados()
        {
            var list = new List<Abastecer>();
            try
            {
                await abastecerHistorico.Initialize();
                list = await abastecerHistorico.GetItemsAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR LIST HISTORICO: " + e.Message);
                throw;
            }

            if (list.Count > 0)
            {
                return new ObservableCollection<Abastecer>(list);
            }
            return null;
        }

        private async void ExecuteSalvarCommand()
        {
            var obj = new Abastecer
            {
                Data = DateTime.Now.ToString("dd/mm/yyyy HH:mm"),
                Valor = Convert.ToDouble(Valor)
            };

            try
            {
                await abastecerHistorico.Initialize();
                await abastecerHistorico.SaveItemAsync(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR SAVING ABASTECER: " + ex.Message);
                throw;
            }
            finally
            {
                await DisplayAlert("SUCESSO", "Abastecimento registrado com sucesso", "OK");
                //Gambiarra pra atualizar a listview
                //ListHistorico = await Dados();
                //Abaixo foi tentativa de adicionar o item na listview sem recarregar
                ListHistorico.Insert(0, obj);
                OnPropertyChanged("ListHistorico");                
            }
            
        }
    }
}
