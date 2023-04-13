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
using System.Threading.Tasks;
using System.Xml;

namespace test_android_developer.Scripts
{
    class XDocument
    {
        public XmlDocument document;

        //Конструктор класса
        public XDocument()
        {
            document = new XmlDocument();
        }

        //Асинхронный метод загрузки xml документа по ссылке
        public async Task LoadXml(String url)
        {
            HttpClient client = new HttpClient();
            String content = await client.GetStringAsync(url);
            Console.WriteLine("content:" + content);
            document.LoadXml(content);
        }

        //Парсинг узла
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
                }
                Offers.Add(offer.id, offer);
            }
            return Offers;
        }

    }
}