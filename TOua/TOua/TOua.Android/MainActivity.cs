
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Views;
using TransportAndOwner.Views;
using Xamarin.Forms;

namespace TOua.Droid {
    [Activity(MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {

        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState) {
            MessagingCenter.Subscribe<object>(this, CustomNavigationView.ON_CUSTOM_NAVIGATION_VIEW_APPEARING, (param) => {
                MessagingCenter.Unsubscribe<object>(this, CustomNavigationView.ON_CUSTOM_NAVIGATION_VIEW_APPEARING);

                Window.SetBackgroundDrawableResource(Resource.Drawable.common_window_background_layer_list_drawable);
            });

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            Instance = this;
            UserDialogs.Init(this);

            LoadApplication(new App());
        }
    }
}