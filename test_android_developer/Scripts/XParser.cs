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
using System.Xml;
using Android.Util;
using System.IO;
using System.Net.Http;

namespace test_android_developer.Scripts
{
    class XParser
    {
        public XParser()
        {

        }

        public void Parse()
        {
            XmlDocument document = new XmlDocument();
            string url = "https://yastatic.net/market-export/_/partner/help/YML.xml";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        Console.WriteLine(result);
                        document.LoadXml(result);
                    }
                }
            }
            XmlNode node = document.DocumentElement;
            {
                Console.WriteLine("Node " + node.Value);
            }

        }
    }
}