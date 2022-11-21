using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace KayneRest
{
    public class Program
    {
        public class QuoteGenerator
        {
            private HttpClient _client;

            public QuoteGenerator(HttpClient client)
            {
                _client = client;
            }

            static void Main(string[] args)
            {
                var client = new HttpClient();



                for (int i = 0; i < 6; i++)
                {
                    var kanyeURL = "https://api.kanye.rest/";

                    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                    var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

                    var ronResponse = client.GetStringAsync(ronURL).Result;

                    var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                    Console.WriteLine($" Ron Swanson: {ronQuote}");
                    Thread.Sleep(2500);
                    Console.WriteLine();
                    Console.WriteLine($" Kanye : \"{kanyeQuote}\"");
                    Thread.Sleep(2500);
                    Console.WriteLine();

                }
            }


        }
    }
}
