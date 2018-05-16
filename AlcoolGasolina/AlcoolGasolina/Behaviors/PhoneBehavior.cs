using Xamarin.Forms;

namespace AlcoolGasolina.Behaviors
{
    public class PhoneBehavior : Behavior<Entry>
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
            entry.Text = FormatCpf(args.NewTextValue);
        }

        private static string FormatCpf(string input)
        {
            if (input.Length > 15)
            {
                input = input.Remove(input.Length - 1);
            }
            else if (input.Length == 2)
            {
                input = "(" + input + ") ";
            }
            else if (input.Length == 10)
            {
                input = input + "-";
            }

            return input;
        }
    }
}
