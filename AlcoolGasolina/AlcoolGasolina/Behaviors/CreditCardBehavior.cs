using Xamarin.Forms;

namespace AlcoolGasolina.Behaviors
{
    public class CreditCardbehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;

            base.OnDetachingFrom(bindable);
        }

        private static void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (args.OldTextValue == null) return;
            if (args.NewTextValue.Length < args.OldTextValue.Length) return;

            var entry = (Entry)sender;
            entry.Text = FormatCard(args.NewTextValue);
        }

        private static string FormatCard(string input)
        {
            if (input.Length > 19)
            {
                input = input.Remove(input.Length - 1);
            }
            else if (input.Length == 4)
            {
                input = input + " ";
            }
            else if (input.Length == 9)
            {
                input = input + " ";
            }
            else if (input.Length == 14)
            {
                input = input + " ";
            }
            return input;
        }
    }
}
