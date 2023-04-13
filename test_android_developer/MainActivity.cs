using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.CardView.Widget;
using System.Collections.Generic;
using test_android_developer.Scripts;

namespace test_android_developer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private LinearLayout layout;
        private const string URL = "https://yastatic.net/market-export/_/partner/help/YML.xml";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            layout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            Init();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void Init()
        {
            XDocument document = new XDocument();
            document.LoadXml(URL);
            CreateList(document.Parse("offer"));
        }

        private void CreateList(Dictionary<int, Offer> offers)
        {
            foreach (KeyValuePair<int, Offer> entry in offers)
            {
                CardView cardView = new CardView(layout.Context);
                TextView textView = new TextView(cardView.Context);
                cardView.SetBackgroundColor(Color.Gray);
                ViewGroup.MarginLayoutParams layoutParams = new ViewGroup.MarginLayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
                layoutParams.SetMargins(10, 10, 10, 10);
                cardView.LayoutParameters = layoutParams;
                textView.Text = entry.Key.ToString();
                textView.Gravity = GravityFlags.Center;
                cardView.AddView(textView);
                layout.AddView(cardView);
            }
        }

        private void SetOnClick()
        {
            Intent intent = new Intent(this.ApplicationContext, typeof(OfferActivity));
            intent.PutExtra("Offers", "offer");
            StartActivity(typeof(OfferActivity));
        }
    }
}