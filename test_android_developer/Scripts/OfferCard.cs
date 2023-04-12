using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace test_android_developer.Scripts
{
    class OfferCard
    {
        private Offer offer;
        public OfferCard(Offer offer)
        {
            this.offer = offer;
        }
        public Label ShowShortCard()
        {
            Label label = new Label();
            label.Text = offer.id.ToString();
            return label;
        }

        public void ShowFullCard()
        {

        }
    }
}