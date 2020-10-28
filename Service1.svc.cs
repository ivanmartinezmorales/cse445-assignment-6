using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetQuote()
        {

            Root response;
            string url = "https://quotes.rest/qod?language=en";
            using (var client = new System.Net.WebClient())
            {
                client.Headers.Add("Accept", "application/json");
                client.Headers.Add("Content-Type", "application/json");
                response = JsonConvert.DeserializeObject<Root>(client.DownloadString(url));
            }

            // get the quote
            try
            {
                string quote = response.contents.quotes[0].quote;
                string author = response.contents.quotes[0].author;
                return quote + " - " + author;
            }
            catch
            {
                return "Twenty years from now you will be more disappointed by the things that you didn’t do than by the ones you did do. - Mark Twain";
            }

        }

    }
    public class Success
    {
        public int total { get; set; }
    }

    public class Quote
    {
        public string quote { get; set; }
        public string length { get; set; }
        public string author { get; set; }
        public List<string> tags { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        public string date { get; set; }
        public string permalink { get; set; }
        public string id { get; set; }
        public string background { get; set; }
        public string title { get; set; }
    }

    public class Contents
    {
        public List<Quote> quotes { get; set; }
    }

    public class Copyright
    {
        public int year { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public Success success { get; set; }
        public Contents contents { get; set; }
        public string baseurl { get; set; }
        public Copyright copyright { get; set; }
    }
}
