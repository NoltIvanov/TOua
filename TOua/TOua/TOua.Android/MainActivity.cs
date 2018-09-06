﻿
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using TransportAndOwner.Views;
using Xamarin.Forms;

namespace TOua.Droid {
    [Activity(Label = "Державний транспортний реєстр", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
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

            UserDialogs.Init(this);

            LoadApplication(new App());
        }
    }
}



//using Acr.UserDialogs;
//using Android.App;
//using Android.Content.PM;
//using Android.OS;
//using TransportAndOwner.Views;
//using Xamarin.Forms;

//namespace TOua.Droid {
//    [Activity(Label = "Державний транспортний реєстр", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
//    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
//        protected override void OnCreate(Bundle savedInstanceState) {
//            MessagingCenter.Subscribe<object>(this, CustomNavigationView.ON_CUSTOM_NAVIGATION_VIEW_APPEARING, (param) => {
//                MessagingCenter.Unsubscribe<object>(this, CustomNavigationView.ON_CUSTOM_NAVIGATION_VIEW_APPEARING);

//                Window.SetBackgroundDrawableResource(Resource.Drawable.common_window_background_layer_list_drawable);
//            });

//            TabLayoutResource = Resource.Layout.Tabbar;
//            ToolbarResource = Resource.Layout.Toolbar;

//            base.OnCreate(savedInstanceState);
//            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
//            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

//            UserDialogs.Init(this);

//            LoadApplication(new App());
//        }
//    }
//}