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
    class TabContent
    {
        public string Url => _response.Url;
        
        public string Title => _response.Title;

        public string HttpCode => _response.HttpSourceCode;
        
        private TabHistory history;
        private BrowserResponse _response;

        public static async Task<TabContent> AsyncCreate(string url)
        {
            TabContent tc = new TabContent(url);
            await tc.GetPage(url);
            return tc;
        } 

        private TabContent(string url)
        { 
            //GetPage(url);
            history = new TabHistory();
        }

        /// <summary>
        /// Update the BrowserResponse object using Async
        /// </summary>
        /// <param name="url">The URL to get the HTTP response from</param>
        private async Task<BrowserResponse> GetPage(string url)
        {
            _response = await HttpRequests.Get(url);
            return _response;
        }

        /// <summary>
        /// Navigate to a new page
        /// </summary>
        /// <param name="url">The url to use for navigation</param>
        public async void Navigate(string url)
        {
            await GetPage(url);
            history.NewPage(Url, Title);
        }

        /// <summary>
        /// TabHistory is used for navigating back and forwards within a tab
        /// </summary>
        class TabHistory: History
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

            public TabHistory()
            {
                Head = null;
                current = Head;
            }

            /// <summary>
            /// Add a new entry into the tab history
            /// </summary>
            /// <param name="url">The url of the page</param>
            /// <param name="title">The title of the page</param>
            public void NewPage(string url, string title)
            {
                TabEntry newPage = new TabEntry(url, title);
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


            class TabEntry : Entry
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

                public TabEntry(string url, string title)
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
