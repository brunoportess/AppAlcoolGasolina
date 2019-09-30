using AlcoolGasolina.Droid.Custom;
using AlcoolGasolina.Views.Custom;
using Android.Content;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

//[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace AlcoolGasolina.Droid.Custom
{
    public class ExtendedTabbedPageRenderer : TabbedPageRenderer
    {
        private bool _isConfigured = false;
        private ViewPager _pager;
        private TabLayout _layout;

        public ExtendedTabbedPageRenderer(Context context) : base(context) { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            _pager = (ViewPager)ViewGroup.GetChildAt(0);
            _layout = (TabLayout)ViewGroup.GetChildAt(1);

            var control = (Views.Custom.MyTabbedPage)sender;
            Android.Graphics.Color selectedColor;
            Android.Graphics.Color unselectedColor;
            if (control != null)
            {
                selectedColor = control.SelectedIconColor.ToAndroid();
                unselectedColor = control.UnselectedIconColor.ToAndroid();
            }
            else
            {
                //selectedColor = new Android.Graphics.Color(ContextCompat.GetColor(Context, Resource.Color.tabBarSelected));
                selectedColor = new Android.Graphics.Color(Android.Graphics.Color.ParseColor("#FF0000"));
                //unselectedColor = new Android.Graphics.Color(ContextCompat.GetColor(Context, Resource.Color.tabBarUnselected));
                unselectedColor = new Android.Graphics.Color(Android.Graphics.Color.ParseColor("#00FF00"));
            }

            for (int i = 0; i < _layout.TabCount; i++)
            {
                var tab = _layout.GetTabAt(i);
                var icon = tab.Icon;
                if (icon != null)
                {
                    var color = tab.IsSelected ? selectedColor : unselectedColor;
                    icon = Android.Support.V4.Graphics.Drawable.DrawableCompat.Wrap(icon);
                    icon.SetColorFilter(color, PorterDuff.Mode.SrcIn);
                }
            }
        }
    }
}