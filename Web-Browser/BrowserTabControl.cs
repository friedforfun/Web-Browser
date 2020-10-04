using System;
using System.Collections;
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
        List<BrowserTabPage> _pages;
        
        public BrowserTabControl()
        {

        }

        
    }

    /// <summary>
    /// Specifies the Windows Forms layout of the TabPage and the content of the tab
    /// </summary>
    public class BrowserTabPage : TabPage
    {
        private TabContent Content;
        public static string HomeURL = "http://www.google.com";

        private Button Back;
        private Button Forwards;
        private Button RefreshBtn;
        private Button Home;
        private Button Go;
        private Button Menu;

        private TextBox UrlInput;

        private Label SourceViewer;

        public static async Task<BrowserTabPage> AsyncCreate()
        {
            BrowserTabPage btp = new BrowserTabPage();
            btp.Content = await TabContent.AsyncCreate(HomeURL);
            btp.SourceViewer.Text = btp.Content.HttpCode;
            btp.Text = btp.Content.Title;
            return btp;
        }

        private BrowserTabPage()
        {
            Back = new Button();
            #region Back Button config
            Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Back.Location = new System.Drawing.Point(4, 2);
            Back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Back.Name = "Back";
            Back.Size = new System.Drawing.Size(45, 48);
            Back.TabIndex = 2;
            Back.Text = "←";
            Back.UseVisualStyleBackColor = true;
            #endregion
            Controls.Add(Back);

            Forwards = new Button();
            #region Forwards Button config
            Forwards.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Forwards.Location = new System.Drawing.Point(51, 2);
            Forwards.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Forwards.Name = "forwardsBtn";
            Forwards.Size = new System.Drawing.Size(45, 48);
            Forwards.TabIndex = 3;
            Forwards.Text = "→";
            Forwards.UseVisualStyleBackColor = true;
            #endregion
            Controls.Add(Forwards);

            RefreshBtn = new Button();
            #region RefreshBtn Button config
            RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RefreshBtn.Location = new System.Drawing.Point(100, 2);
            RefreshBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            RefreshBtn.Name = "refreshBtn";
            RefreshBtn.Size = new System.Drawing.Size(45, 48);
            RefreshBtn.TabIndex = 1;
            RefreshBtn.Text = "⭮";
            RefreshBtn.UseVisualStyleBackColor = true;
            #endregion
            Controls.Add(RefreshBtn);

            Home = new Button();
            #region Home Button config
            Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Home.Location = new System.Drawing.Point(150, 2);
            Home.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Home.Name = "homeBtn";
            Home.Size = new System.Drawing.Size(45, 48);
            Home.TabIndex = 10;
            Home.Text = "⌂";
            Home.UseVisualStyleBackColor = true;
            #endregion
            Controls.Add(Home);

            // TODO: deal with Go event handler (look @ Content.Navigate())
            Go = new Button();
            #region Go Button config
            Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Go.Location = new System.Drawing.Point(960, 2);
            Go.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Go.Name = "goBtn";
            Go.Size = new System.Drawing.Size(76, 48);
            Go.TabIndex = 1;
            Go.Text = "Go";
            Go.UseVisualStyleBackColor = true;
            //Go.Click += new System.EventHandler(Go_Click);
            #endregion
            Controls.Add(Go);

            Menu = new Button();
            #region Menu Button config
            Menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Menu.Location = new System.Drawing.Point(1041, 2);
            Menu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Menu.Name = "menuBtn";
            Menu.Size = new System.Drawing.Size(106, 48);
            Menu.TabIndex = 8;
            Menu.Text = "Menu";
            Menu.UseVisualStyleBackColor = true;
            #endregion
            Controls.Add(Menu);

            UrlInput = new TextBox();
            #region UrlInput TextBox config
            UrlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            UrlInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UrlInput.Location = new System.Drawing.Point(200, 6);
            UrlInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            UrlInput.Name = "URLInput";
            UrlInput.Size = new System.Drawing.Size(757, 35);
            UrlInput.TabIndex = 0;
            UrlInput.Text = HomeURL;
            #endregion
            Controls.Add(UrlInput);

            SourceViewer = new Label();
            #region SourceViewer Label config
            SourceViewer.AutoEllipsis = true;
            SourceViewer.AutoSize = true;
            SourceViewer.BackColor = System.Drawing.Color.White;
            SourceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SourceViewer.Location = new System.Drawing.Point(4, 63);
            SourceViewer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            SourceViewer.Name = "sourceViewer";
            SourceViewer.Size = new System.Drawing.Size(2, 31);
            SourceViewer.TabIndex = 9;
            #endregion
            Controls.Add(SourceViewer);


        }



    }
}
