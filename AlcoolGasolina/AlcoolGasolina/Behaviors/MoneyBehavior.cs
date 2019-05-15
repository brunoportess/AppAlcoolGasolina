using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
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
            //, System.Globalization.CultureInfo.InvariantCulture
            try
            {
                if (string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrEmpty(e.OldTextValue)) return;
                var nvalue = Convert.ToDouble(e.NewTextValue, System.Globalization.CultureInfo.InvariantCulture);
                var ovalue = Convert.ToDouble(e.OldTextValue, System.Globalization.CultureInfo.InvariantCulture) / 100;
                if (nvalue == ovalue) return;
                var valor = Convert.ToDecimal(e.NewTextValue.Replace(".", "").Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
                valor /= 100;
                var str = valor.ToString("n2");
                ((Entry)sender).Text = str;
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Old Value", e.OldTextValue },
                    { "New value", e.NewTextValue}
                };
                Crashes.TrackError(ex, properties);
                //throw;
                ((Entry)sender).Text = e.NewTextValue;
            }
        }
    }
}
