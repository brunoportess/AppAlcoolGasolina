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
            if (e.NewTextValue == null || Convert.ToDouble(e.NewTextValue) == Convert.ToDouble(e.OldTextValue) / 100) return;
            var valor = Convert.ToDecimal(e.NewTextValue.Replace(".", "").Replace(",", ""));
            valor = valor / 100;
            //var str = String.Format("{0:#.##}", valor.ToString());
            var str = valor.ToString("n2");
            ((Entry)sender).Text = str;
        }
    }
}
