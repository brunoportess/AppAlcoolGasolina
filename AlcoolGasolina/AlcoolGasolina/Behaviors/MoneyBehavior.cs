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
           if (string.IsNullOrEmpty(e.NewTextValue) || Convert.ToDouble(e.NewTextValue) == Convert.ToDouble(e.OldTextValue) / 100) return;
            //if(Convert.ToDouble(e.NewTextValue) == 0) ((Entry)sender).Text = "";
            var valor = Convert.ToDecimal(e.NewTextValue.Replace(".", "").Replace(",", ""));
            valor = valor / 100;
            var str = valor.ToString("n2");
            ((Entry)sender).Text = str;
        }
    }
}
