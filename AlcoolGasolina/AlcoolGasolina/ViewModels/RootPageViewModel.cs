using AlcoolGasolina.Helpers;
using AlcoolGasolina.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AlcoolGasolina.ViewModels
{
    public class RootPageViewModel :ViewModelBase
    {
        private List<ItemMenu> _listItensMenu;
        public List<ItemMenu> ListItensMenu
        {
            get { return _listItensMenu; }
            set { SetProperty(ref _listItensMenu, value); }
        }

        public RootPageViewModel() : base()
        {
            RootListGenerate();
        }

        private void RootListGenerate()
        {
            ListItensMenu = RootMenu.Itens();
        }
    }
}
