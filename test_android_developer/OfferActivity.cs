using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace test_android_developer
{
    [Activity(Label = "OfferActivity")]
    public class OfferActivity : Activity
    {
        private LinearLayout layout;
        private ViewGroup.MarginLayoutParams layoutParams;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_offer);
            Init();
        }

        //Инициализация
        private void Init()
        {
            layoutParams = new ViewGroup.MarginLayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams.SetMargins(10, 10, 10, 10);
            layout = FindViewById<LinearLayout>(Resource.Id.linearLayout);
            ShowInfo(Intent.Extras);
        }

        //Вывод информации на экран
        private void ShowInfo(Bundle extras)
        {
            TextView textId = FindViewById<TextView>(Resource.Id.textId);
            if (extras != null)
            {
                String value = extras.GetString("id");
                textId.Text = value;

            }
            foreach (string key in extras.KeySet())
            {
                if (!key.Equals("id"))
                    AddTextView(key + ": " + extras.GetString(key));
            }
            AddButton();
        }

        //Добавление кнопки на экран
        private void AddButton()
        {
            Button button = new Button(layout.Context);
            button.Text = "ВЕРНУТЬСЯ";
            button.TextSize = 30;
            button.Click += Click;
            layout.AddView(button);

            void Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this.ApplicationContext, typeof(MainActivity));
                StartActivity(intent);
            }
        }

        //Добавление TextView на экран
        private void AddTextView(string text)
        {
            TextView textView = new TextView(layout.Context);
            textView.Text = text;
            textView.TextSize = 10;
            textView.LayoutParameters = layoutParams;
            layout.AddView(textView);
        }
    }
}