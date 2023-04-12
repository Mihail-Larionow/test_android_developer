using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace test_android_developer.Scripts
{
    class XDocument
    {
        public XmlDocument document;
        public XDocument()
        {
            document = new XmlDocument();
        }

        public void LoadXml(String url)
        {
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
        }

        public Dictionary<int, Offer> Parse(String nameOfNode)
        {
            Dictionary<int, Offer> Offers = new Dictionary<int, Offer>();
            XmlNodeList root = document.GetElementsByTagName(nameOfNode);
            foreach (XmlNode offerNode in root)
            {
                Offer offer = new Offer(Int32.Parse(offerNode.Attributes["id"].Value));
                foreach (XmlNode node in offerNode.ChildNodes)
                {
                    offer.AddAttribute(node.Name, node.InnerText);
                    Console.WriteLine(node.Name + ": " + node.InnerText);
                }
                Offers.Add(offer.id, offer);
            }
            return Offers;
        }

    }
}