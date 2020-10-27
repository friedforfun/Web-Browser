using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System.Windows.Forms;

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

        /// <summary>
        /// Send a HTTP GET request to the URI
        /// </summary>
        /// <param name="uri">The URI for the request</param>
        /// <returns>Returns a task wrapping a BrowserResponse</returns>
        public static async Task<BrowserResponse> Get(string uri)
        {
            // perform some validation on url here
            if (!uri.StartsWith("http://www.") | !uri.StartsWith("https://www."))
            {
                // fix uri string
            }
            try
            {
                HttpResponseMessage httpres = await client.GetAsync(uri);
                return await BrowserResponse.CreateAsync(httpres);

            } catch (InvalidOperationException e)
            {
                MessageBox.Show("Invalid URI provided");
            }

            throw new ArgumentException("Attempted to navigate using improper URI Argument");
        }

    }

    public class BrowserResponse
    {
        public string Title { get => _title; }
        private string _title;
        public string HttpSourceCode { get => _source; }
        private string _source;
        public string Url { get => _url; }
        private string _url;
        public int StatusCode { get => _statusCode; }
        private int _statusCode;

        private IDocument _document;
        private string _rawContent;

        public static async Task<BrowserResponse> CreateAsync(HttpResponseMessage message)
        {
            BrowserResponse br = new BrowserResponse();
            br._statusCode = await br.GetContent(message);
            return br;
        }

        private BrowserResponse()
        {
            
        }

        private async Task<int> GetContent(HttpResponseMessage message)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);

            _rawContent = await message.Content.ReadAsStringAsync();
            _document = await context.OpenAsync(req => req.Content(_rawContent));
            _title = _document.Title;
            _url = _document.Url;
            _source = _document.Source.Text;
            
            return (int)message.StatusCode;
        }
    }

}
