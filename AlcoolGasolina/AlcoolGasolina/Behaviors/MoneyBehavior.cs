using System;
using Xamarin.Forms;

namespace AlcoolGasolina.Behaviors
{
    public class MoneyBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrEmpty(e.OldTextValue)) return;
            var nvalue = Convert.ToDouble(e.NewTextValue, System.Globalization.CultureInfo.InvariantCulture);
            var ovalue = Convert.ToDouble(e.OldTextValue, System.Globalization.CultureInfo.InvariantCulture) / 100;
           if (nvalue == ovalue) return;
            //if(Convert.ToDouble(e.NewTextValue) == 0) ((Entry)sender).Text = "";
            var valor = Convert.ToDecimal(e.NewTextValue.Replace(".", "").Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
            valor = valor / 100;
            var str = valor.ToString("n2");
            ((Entry)sender).Text = str;
        }
    }
}
