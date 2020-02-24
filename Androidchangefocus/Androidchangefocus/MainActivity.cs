using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Java.Util.Zip;
using Android.Graphics;
using System;
using Android.Views.Accessibility;

namespace Androidchangefocus
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RelativeLayout sfondo;
        Button b1, b2, b3;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            sfondo = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);

            b1 = new Button(ApplicationContext)
            {
                Text = "BUTTON 1 press me to change focus to BUTTON 3",
                Focusable = true,
                FocusableInTouchMode = true,
                ScreenReaderFocusable = true,
            };
            b1.SetBackgroundColor(Color.Green);
            b1.SetX(100); b1.SetY(200);
            b1.Click += changefocus;

            b2 = new Button(ApplicationContext)
            {
                Text = "BUTTON 2",
                Focusable = true,
                FocusableInTouchMode = true,
                ScreenReaderFocusable = true,
            };
            b2.SetBackgroundColor(Color.Yellow);
            b2.SetX(500); b2.SetY(500);

            b3 = new Button(ApplicationContext)
            {
                Text = "BUTTON 3",
                Focusable = true,
                FocusableInTouchMode = true,
                ScreenReaderFocusable = true,
            };
            b3.SetBackgroundColor(Color.Orange);
            b3.SetX(800); b3.SetY(800);

            sfondo.AddView(b1);
            sfondo.AddView(b2);
            sfondo.AddView(b3);

        }

        private void changefocus(object sender, EventArgs e)
        {
            Console.WriteLine("PIPPO change focus pressed");
            //b3.ImportantForAccessibility = ImportantForAccessibility.Yes;
            b3.SendAccessibilityEvent(EventTypes.ViewAccessibilityFocused);
            //b3.SendAccessibilityEvent(EventTypes.ViewFocused);
            //b3.SendAccessibilityEvent(EventTypes.WindowsChanged);
            //b3.RequestFocus();
            //b3.SendAccessibilityEventUnchecked(AccessibilityEvent.WindowsChangeAccessibilityFocused);
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}