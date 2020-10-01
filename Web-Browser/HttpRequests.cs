using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace Web_Browser
{
    public class HttpRequests
    {
        /// <summary>
        /// Static HttpClient shared accross all instances of Http class
        /// </summary>
        private static readonly HttpClient client;

        static HttpRequests()
        {
            client = new HttpClient();
        }

        public static async Task Get(string uri)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                // possibly change to handle non-success status code
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(response.StatusCode);
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception");
                Console.WriteLine("Message: {0}", e.Message);
            }
            
        }

    }
}
