using AlcoolGasolina.Models.Database;
using AlcoolGasolina.Models.Entities;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels.Combustivel
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class AbastecerTabbedViewModel : BaseViewModel
    {
        private readonly AbastecerHistorico abastecerHistorico;
        public Command SalvarCommand { get; set; }
        public Command<Abastecer> DelHistoricoCommand { get; set; }
        public Command RefreshHistoricoCommand { get; set; }

        private Abastecer _abastecimento;
        public Abastecer Abastecimento
        {
            get { return _abastecimento; }
            set { SetProperty(ref _abastecimento, value); }
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Abastecer> _listHistorico;
        public ObservableCollection<Abastecer> ListHistorico
        {
            get { return _listHistorico; }
            set { SetProperty(ref _listHistorico, value); }
        }

        public AbastecerTabbedViewModel()
        {
            Abastecimento = new Abastecer
            {
                Data = DateTime.Now.ToString("dd/MM/yyyy")
            };
            abastecerHistorico = new AbastecerHistorico();
            ListHistorico = new ObservableCollection<Abastecer>();
            SalvarCommand = new Command(ExecuteSalvarCommand);
            RefreshHistoricoCommand = new Command(ExecuteRefreshHistoricoCommand);
            DelHistoricoCommand = new Command<Abastecer>(ExecuteDelHistoricoCommand);
        }

        public override Task InitializeAsync(object[] args)
        {
            Task.Run(async() => {
                await abastecerHistorico.Initialize();
                await Dados();
            });
            return base.InitializeAsync(args);
        }

        private async void ExecuteRefreshHistoricoCommand()
        {
            IsRefreshing = true;
            await Dados();
        }

        private async void ExecuteDelHistoricoCommand(Abastecer obj)
        {
            string res = await DisplayActionSheet("Ações", "Cancelar", "", new string[] { "Deletar" });
            if (!string.IsNullOrEmpty(res))
            {
                if (res.Equals("Deletar"))
                {
                    await abastecerHistorico.DeleteItemAsync(obj);
                    ListHistorico.Remove(obj);
                }
            }
        }

        //private async Task<ObservableCollection<Abastecer>> Dados()
        private async Task Dados()
        {
            var list = new List<Abastecer>();
            try
            {
                list = await abastecerHistorico.GetItemsAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR LIST HISTORICO: " + e.Message);
                Crashes.TrackError(e);
                ListHistorico = new ObservableCollection<Abastecer>();
            }
            finally
            {
                IsRefreshing = false;
                if (list.Count > 0)
                {
                    ListHistorico = new ObservableCollection<Abastecer>(list);
                }
            }

        }

        private async void ExecuteSalvarCommand()
        {
            
            Debug.WriteLine($"ABASTECIMENTO: {Abastecimento}");
            try
            {
                if(!string.IsNullOrEmpty(Abastecimento.ValorLitro) && !string.IsNullOrEmpty(Abastecimento.Valor))
                {
                    Abastecimento.Litros = double.Parse(Abastecimento.Valor) / double.Parse(Abastecimento.ValorLitro);
                }
                await abastecerHistorico.SaveItemAsync(Abastecimento);
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Salvou abastecimento");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR SAVING ABASTECER: " + ex.Message);
                var properties = new Dictionary<string, string>
                {
                    { "Abastecimento", Newtonsoft.Json.JsonConvert.SerializeObject(Abastecimento)}
                };
                Crashes.TrackError(ex, properties);
                throw;
            }
            finally
            {
                await DisplayAlert("SUCESSO", "Abastecimento registrado com sucesso", "OK");
                ListHistorico.Insert(0, Abastecimento);
            }

        }
    }
}
