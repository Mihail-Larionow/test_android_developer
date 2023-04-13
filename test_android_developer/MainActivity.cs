using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.CardView.Widget;
using System;
using System.Collections.Generic;
using test_android_developer.Scripts;

namespace test_android_developer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private LinearLayout layout;
        private ViewGroup.MarginLayoutParams layoutParams;
        private XDocument document;
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
            document = new XDocument();
            document.LoadXml(URL);
            layoutParams = new ViewGroup.MarginLayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
            layoutParams.SetMargins(10, 10, 10, 10);
            foreach (KeyValuePair<int, Offer> entry in document.Parse("offer"))
            {
                ShowCard(entry.Value);
            }
        }

        private void ShowCard(Offer offer)
        {
            CardView cardView = new CardView(layout.Context);
            TextView textView = new TextView(cardView.Context);
            cardView.SetBackgroundColor(Color.Gray);
            cardView.LayoutParameters = layoutParams;
            textView.Text = offer.id.ToString();
            textView.TextSize = 20;
            textView.Gravity = GravityFlags.Center;
            SetOnClickListener(textView, offer);
            cardView.AddView(textView);
            layout.AddView(cardView);
        }

        private void SetOnClickListener(TextView textView, Offer offer)
        {
            textView.Click += Click;
            void Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this.ApplicationContext, typeof(OfferActivity));
                intent.PutExtra("id", textView.Text);
                foreach(KeyValuePair<string, string> attribute in offer.attributes)
                {
                    intent.PutExtra(attribute.Key, attribute.Value);
                }
                StartActivity(intent);
            }
        }

    }
}