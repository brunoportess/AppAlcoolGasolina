using AlcoolGasolina.ViewModels.Combustivel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlcoolGasolina.Views.Combustivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbastecerTabbedPage : TabbedPage
    {
        private readonly AbastecerTabbedPageViewModel _vm;
        public AbastecerTabbedPage ()
        {
            InitializeComponent();
            this.BindingContext = _vm = new AbastecerTabbedPageViewModel();
            abastecer.BindingContext = _vm;
            historico.BindingContext = _vm;
        }
    }
}