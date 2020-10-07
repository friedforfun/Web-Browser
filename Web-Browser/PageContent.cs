using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    /// <summary>
    /// Object storing the state of a tab
    /// </summary>
    class PageContent
    {
        public string Url;
        
        public string Title => _response.Title;

        public string HttpCode => _response.HttpSourceCode;
        
        private PageHistory LocalHistory;
        private BrowserResponse _response;

        public static async Task<PageContent> AsyncCreate(string url)
        {
            PageContent pc = new PageContent(url);
            await pc.GetPage();
            // init LocalHistory
            PageHistory FirstPage = new PageHistory(pc.Url, pc.Title);
            pc.LocalHistory = FirstPage;
            return pc;
        } 

        private PageContent(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Update the BrowserResponse object using Async
        /// </summary>
        /// <param name="url">The URL to get the HTTP response from</param>
        private async Task<BrowserResponse> GetPage()
        {
            _response = await HttpRequests.Get(Url);
            return _response;
        }

        /// <summary>
        /// Navigate to a new page
        /// </summary>
        /// <param name="url">The url to use for navigation</param>
        public async void Navigate(string url)
        {
            Url = url;
            await GetPage();
            LocalHistory.NewPage(Url, Title);
        }

        /// <summary>
        /// PageHistory is used for navigating back and forwards within a tab
        /// </summary>
        class PageHistory: History
        {
            /// <summary>
            /// Points to the current node in the list
            /// </summary>
            private Entry current;

            /// <summary>
            /// Backing field for Head
            /// </summary>
            private Entry _head;
            /// <summary>
            /// get/set for _head
            /// </summary>
            protected override Entry Head
            {
                get => _head;
                set
                {
                    _head = value;
                    // Any time head is set to a new value set current to this location
                    current = value;
                }
            }

            public bool IsEmpty
            {
                get => Head == null;
            }

            public bool CanStepForward
            {
                get => current.Forwards != null;
            }

            public bool CanStepBack
            {
                get => current.Back != null;
            }

            public PageHistory(string url, string title)
            {
                PageEntry firstPage = new PageEntry(url, title);
                Head = firstPage;
                current = Head;
            }

            /// <summary>
            /// Add a new entry into the tab history
            /// </summary>
            /// <param name="url">The url of the page</param>
            /// <param name="title">The title of the page</param>
            public void NewPage(string url, string title)
            {
                PageEntry newPage = new PageEntry(url, title);
                AddEntry(newPage);
            }

            /// <summary>
            /// Add new entry in list, set head & current to this entry
            /// </summary>
            /// <param name="e"></param>
            protected override void AddEntry(Entry e)
            {
                e.Back = Head;
                Head.Forwards = e;
                Head = e;
            }

            protected void StepBack()
            {
                if (CanStepBack)
                {
                    current = current.Back;
                }
            }

            protected void StepForwards()
            {
                if (CanStepForward)
                {
                    current = current.Forwards;
                }
            }


            class PageEntry : Entry
            {
                private readonly string _url;
                private readonly string _title;
                private readonly DateTime _accessTime;
                private Entry _back;
                private Entry _forwards;

                protected override string Url => _url;
                protected override string Title => _title;
                protected override DateTime AccessTime => _accessTime;
                public override Entry Back { get => _back; set => _back = value; }
                public override Entry Forwards { get => _forwards; set => _forwards = value; }

                public PageEntry(string url, string title)
                {
                    _url = url;
                    _title = title;
                    _accessTime = DateTime.Now;
                    _back = null;
                    _forwards = null;
                }
            }
        }
    }
}
