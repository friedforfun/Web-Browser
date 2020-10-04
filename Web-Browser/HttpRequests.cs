using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

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
            HttpResponseMessage httpres = await client.GetAsync(uri);
            return await BrowserResponse.CreateAsync(httpres);
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
        public int StatusCode { get; }
        private int _statusCode;

        private IDocument _document;
        private string _rawContent;

        public static async Task<BrowserResponse> CreateAsync(HttpResponseMessage message)
        {
            BrowserResponse br = new BrowserResponse(message);
            await br.GetContent(message.Content);
            return br;
        }

        private BrowserResponse(HttpResponseMessage message)
        {
            _statusCode = (int)message.StatusCode;
        }

        private async Task<int> GetContent(HttpContent content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);

            _rawContent = await content.ReadAsStringAsync();
            _document = await context.OpenAsync(req => req.Content(_rawContent));
            _title = _document.Title;
            _url = _document.Url;
            _source = _document.Source.Text;

            return -1;
        }
    }

}
