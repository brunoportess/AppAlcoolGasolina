using Xamarin.Forms;

namespace AlcoolGasolina.Views.Custom
{
    public class MyTabbedPage : TabbedPage
    {
        // SelectedIconColor
        public Color SelectedIconColor
        {
            get { return (Color)GetValue(SelectedIconColorProperty); }
            set { SetValue(SelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty SelectedIconColorProperty = BindableProperty.Create(
            nameof(SelectedItemProperty),
            typeof(Color),
            typeof(MyTabbedPage),
            Color.White);

        // UnselectedIconColor
        public Color UnselectedIconColor
        {
            get { return (Color)GetValue(UnelectedIconColorProperty); }
            set { SetValue(UnelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty UnelectedIconColorProperty = BindableProperty.Create(
            nameof(UnselectedIconColor),
            typeof(Color),
            typeof(MyTabbedPage),
            Color.White);

        // SelectedTextColor
        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
            nameof(SelectedTextColor),
            typeof(Color),
            typeof(MyTabbedPage),
            Color.White);

        // UnselectedTextColor
        public Color UnselectedTextColor
        {
            get { return (Color)GetValue(UnselectedTextColorProperty); }
            set { SetValue(UnselectedTextColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedTextColorProperty = BindableProperty.Create(
            nameof(UnselectedTextColor),
            typeof(Color),
            typeof(MyTabbedPage),
            Color.White);
    }
}
