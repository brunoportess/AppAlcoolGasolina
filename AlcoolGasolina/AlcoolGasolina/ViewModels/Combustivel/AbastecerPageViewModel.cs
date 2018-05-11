using System;
using System.Collections.Generic;
using System.Text;

namespace AlcoolGasolina.ViewModels.Combustivel
{
    public class AbastecerPageViewModel : ViewModelBase
    {
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

        public AbastecerPageViewModel() : base()
        {
            Data = DateTime.Now.ToString("dd/mm/yyyy");
        }
    }
}
