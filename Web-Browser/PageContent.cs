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
    public class PageContent
    {
        public string Url;
        
        public string Title => _response.Title;

        public string HttpCode => _response.HttpSourceCode;

        public PageHistory LocalHistory;
        private BrowserResponse _response;

        public event EventHandler<ContextChangedEventArgs> ContextChanged;

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

            ContextChangedEventArgs args = new ContextChangedEventArgs();
            args.Url = Url;
            args.Title = Title;
            OnContextChanged(args);
        }

        public async void NavigateNoHistory(string url)
        {
            Url = url;
            await GetPage();

            ContextChangedEventArgs args = new ContextChangedEventArgs();
            args.Url = Url;
            args.Title = Title;
            OnContextChanged(args);
        }

        private async void HistoryNavigate()
        {
            Url = LocalHistory.GetUrl;
            await GetPage();
            ContextChangedEventArgs args = new ContextChangedEventArgs();
            args.Url = Url;
            args.Title = Title;
            OnContextChanged(args);
        }

        public void Back()
        {
            LocalHistory.StepBack();
            HistoryNavigate();
        }

        public void Forwards()
        {
            LocalHistory.StepForwards();
            HistoryNavigate();
        }

        protected virtual void OnContextChanged(ContextChangedEventArgs e)
        {
            EventHandler<ContextChangedEventArgs> handler = ContextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        /// <summary>
        /// PageHistory is used for navigating back and forwards within a tab
        /// </summary>
        public class PageHistory: History
        {
            /// <summary>
            /// Points to the current node in the list
            /// </summary>
            private Entry Current;

            public string GetUrl => Current.Url;
            public string GetTitle => Current.Title;

            public string test => Current.Back.Forwards.Title;

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
                    // Any time head is set to a new value set Current to this location
                    Current = value;
                }
            }

            public bool IsEmpty
            {
                get => Head == null;
            }

            public bool CanStepForward
            {
                get => Current.Forwards != null;
            }

            public bool CanStepBack
            {
                get => Current.Back != null;
            }

            public PageHistory(string url, string title)
            {
                PageEntry firstPage = new PageEntry(url, title);
                Head = firstPage;
                Current = Head;
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
            /// Add new entry in list, set head & Current to this entry
            /// </summary>
            /// <param name="e"></param>
            protected override void AddEntry(Entry e)
            {
                Head.Forwards = e;
                e.Back = Head;
                Head = e;
                Current = Head;
            }

            public void StepBack()
            {
                if (CanStepBack)
                {
                    Current = Current.Back;

                }
            }

            public void StepForwards()
            {
                if (CanStepForward)
                {
                    Current = Current.Forwards;
                }
            }
            protected class PageEntry : Entry
            {
                private readonly string _url;
                private readonly string _title;
                private readonly DateTime _accessTime;
                private Entry _back;
                private Entry _forwards;

                public override string Url => _url;
                public override string Title => _title;
                public override DateTime AccessTime => _accessTime;
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
    public class ContextChangedEventArgs : EventArgs
    {
        public string Url;
        public string Title;
    }
}
