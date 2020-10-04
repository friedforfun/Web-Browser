using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public class BrowserTabControl: TabControl
    {
        //BrowserTabPage
        class BrowserTabPageCollection: TabPageCollection
        {

        }
    }

    public class BrowserTabPage : TabPage
    {
        private TabContent Content;

    }
}
