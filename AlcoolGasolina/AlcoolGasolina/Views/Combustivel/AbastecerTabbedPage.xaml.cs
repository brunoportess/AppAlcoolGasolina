﻿using AlcoolGasolina.ViewModels.Combustivel;
using AlcoolGasolina.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class AbastecerTabbedPage : MyTabbedPage
    {
        readonly AbastecerTabbedViewModel _vm;
        public AbastecerTabbedPage ()
        {
            InitializeComponent();
            _vm = BindingContext as AbastecerTabbedViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            abastecer.BindingContext = historico.BindingContext = _vm;
        }
    }
}