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

namespace test_android_developer.Scripts
{
    class Offer
    {
        public int id;
        public Dictionary<String, String> attributes;

        //Конструктор класса
        public Offer(int id)
        {
            this.id = id;
            attributes = new Dictionary<String, String>();
        }

        //Добавление атрибутов в словарь
        public void AddAttribute(String name, String value)
        {
            string val;
            if (!attributes.TryGetValue(name, out val))
                attributes.Add(name, value);
        }
    }
}