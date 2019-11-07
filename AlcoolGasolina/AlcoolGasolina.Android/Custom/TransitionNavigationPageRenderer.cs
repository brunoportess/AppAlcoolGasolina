using AlcoolGasolina.Droid.Custom;
using Android.Content;
using Android.Support.V4.App;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(AlcoolGasolina.Controls.TransitionNavigationPage), typeof(TransitionNavigationPageRenderer))]
namespace AlcoolGasolina.Droid.Custom
{
    public class TransitionNavigationPageRenderer : NavigationPageRenderer
    {
        //private TransitionType _transitionType = TransitionType.Default;

        public TransitionNavigationPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            /*if (e.PropertyName == Controls.TransitionNavigationPage.TransitionTypeProperty.PropertyName)
                UpdateTransitionType();*/
            //UpdateTransitionType();
        }

        protected override void SetupPageTransition(FragmentTransaction transaction, bool isPush)
        {
            transaction.SetCustomAnimations(Resource.Animation.flip_in, Resource.Animation.flip_out,
                                                    Resource.Animation.flip_out, Resource.Animation.flip_in);
        }

        private void UpdateTransitionType()
        {
            var transitionNavigationPage = (Controls.TransitionNavigationPage)Element;
            //_transitionType = transitionNavigationPage.TransitionType;
        }
    }
}
