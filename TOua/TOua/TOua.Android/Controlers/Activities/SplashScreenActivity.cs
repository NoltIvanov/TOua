using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using FFImageLoading.Views;

namespace TOua.Droid.Controlers.Activities {
    [Activity(
        MainLauncher = false,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Android.Support.V7.App.AppCompatActivity {

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            //
            // Is not necessary. Status bar visibility changes from theme
            //
            //Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.SpalshLayout);

            ImageService.Instance
            .LoadCompiledResource("todo_1.svg")
            .WithCustomDataResolver(new SvgDataResolver(200, 0, true))
            .Into(FindViewById<ImageViewAsync>(Resource.Id.image_View));

            System.Threading.ThreadPool.QueueUserWorkItem(o => NavigateToMainActivity());
        }

        private void NavigateToMainActivity() {
            System.Threading.Thread.Sleep(2000);

            Intent intent = new Intent(this, typeof(MainActivity));
            ActivityOptions activityOptions = ActivityOptions.MakeCustomAnimation(this, Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);

            RunOnUiThread(() => StartActivity(intent, activityOptions.ToBundle()));
            Finish();
        }
    }
}