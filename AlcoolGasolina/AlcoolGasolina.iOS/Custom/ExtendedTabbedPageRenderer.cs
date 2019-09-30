using AlcoolGasolina.iOS.Custom;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AlcoolGasolina.Views.Custom.MyTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace AlcoolGasolina.iOS.Custom
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            if (TabBar?.Items == null) return;

            var control = (Views.Custom.MyTabbedPage)Element;
            UIColor selectedColor;
            UIColor unselectedColor;
            UIColor selectedTextColor;
            UIColor unselectedTextColor;
            UIColor backgroundColor;
            /*
            if (control != null)
            { 
            
                selectedColor = control.SelectedTabColor.ToUIColor();
                unselectedColor = control.UnselectedTabColor.ToUIColor();
                selectedTextColor = control.SelectedTabColor.ToUIColor();
                unselectedTextColor = control.UnselectedTabColor.ToUIColor();
                backgroundColor = control.BackgroundColor.ToUIColor();
                
            }
            else
            {
                selectedColor = ExtensionMethods.ToUIColor("#FFFFFF");
                unselectedColor = ExtensionMethods.ToUIColor("#00796B");
                selectedTextColor = ExtensionMethods.ToUIColor("#FFFFFF");
                unselectedTextColor = ExtensionMethods.ToUIColor("#00796B");
                backgroundColor = ExtensionMethods.ToUIColor("#009688");
            }
            */
            selectedTextColor = ExtensionMethods.ToUIColor("#009688");
            unselectedTextColor = ExtensionMethods.ToUIColor("#CCCCCC");
            selectedColor = ExtensionMethods.ToUIColor("#009688");
            unselectedColor = ExtensionMethods.ToUIColor("#CCCCCC");
            TabBar.UnselectedItemTintColor = unselectedColor;
            TabBar.SelectedImageTintColor = selectedColor;
            //TabBar.BackgroundColor = UIColor.Red;

            var tabs = Element as TabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateItem(TabBar.Items[i], selectedTextColor, unselectedTextColor);
                }
            }

            base.ViewWillAppear(animated);
        }

        public override void ItemSelected(UITabBar tabbar, UITabBarItem item)
        {
            var page = ((TabbedPage)Element).CurrentPage;

        }

        private void UpdateItem(UITabBarItem item, UIColor selected, UIColor unselected)
        {
            if (item == null) return;

            item.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = selected
            }, UIControlState.Selected);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = unselected
            }, UIControlState.Normal);
        }
    }
}