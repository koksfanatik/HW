using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace DrawAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       
        public DrawCanvas mainCanvas1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            SeekBar slider = (SeekBar)FindViewById(Resource.Id.slider);
            slider.ProgressChanged += Slider_ProgressChanged;
            Button SimpleButton = (Button)FindViewById(Resource.Id.SimpleButton);
            SimpleButton.Click += SimpleButton_Click;
            Button BarButton = (Button)FindViewById(Resource.Id.BarButton);
            BarButton.Click += BarButton_Click;
            Button CircleButton = (Button)FindViewById(Resource.Id.CircleButton);
            CircleButton.Click += CircleButton_Click;
            DrawCanvas mainCanvas = (DrawCanvas)FindViewById(Resource.Id.Canvas);
            mainCanvas1 = mainCanvas;
            mainCanvas1.sliderValue = 1;
            mainCanvas1.buttonValue = 1;

        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            mainCanvas1.buttonValue = 3;
        }

        private void BarButton_Click(object sender, EventArgs e)
        {
            mainCanvas1.buttonValue = 2;
        }

        private void SimpleButton_Click(object sender, EventArgs e)
        {
            mainCanvas1.buttonValue=1;
        }

        private void Slider_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            
            
            mainCanvas1.sliderValue = e.Progress;


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
       
    }
}

