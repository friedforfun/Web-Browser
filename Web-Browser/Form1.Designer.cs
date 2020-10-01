namespace Web_Browser
{
    partial class BrowserWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserWindow));
            this.URLInput = new System.Windows.Forms.TextBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardsBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.navigationWindow = new System.Windows.Forms.Panel();
            this.menuBtn = new System.Windows.Forms.Button();
            this.bottomInfo = new System.Windows.Forms.ToolStrip();
            this.toggleSource = new System.Windows.Forms.ToolStripButton();
            this.pageContent = new System.Windows.Forms.Panel();
            this.menuPane = new System.Windows.Forms.MenuStrip();
            this.menuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.menuForwards = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFavourites = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTab = new System.Windows.Forms.TabPage();
            this.goBtn = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.navigationWindow.SuspendLayout();
            this.bottomInfo.SuspendLayout();
            this.pageContent.SuspendLayout();
            this.menuPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // URLInput
            // 
            this.URLInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URLInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLInput.Location = new System.Drawing.Point(200, 7);
            this.URLInput.Name = "URLInput";
            this.URLInput.Size = new System.Drawing.Size(1067, 44);
            this.URLInput.TabIndex = 0;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(134, 3);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(60, 60);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "⭮";
            this.refreshBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(6, 3);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(60, 60);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "←";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // forwardsBtn
            // 
            this.forwardsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardsBtn.Location = new System.Drawing.Point(68, 3);
            this.forwardsBtn.Name = "forwardsBtn";
            this.forwardsBtn.Size = new System.Drawing.Size(60, 60);
            this.forwardsBtn.TabIndex = 3;
            this.forwardsBtn.Text = "→";
            this.forwardsBtn.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.NewTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1557, 995);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.navigationWindow);
            this.tabPage1.Location = new System.Drawing.Point(8, 51);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1541, 936);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // navigationWindow
            // 
            this.navigationWindow.Controls.Add(this.goBtn);
            this.navigationWindow.Controls.Add(this.URLInput);
            this.navigationWindow.Controls.Add(this.refreshBtn);
            this.navigationWindow.Controls.Add(this.menuBtn);
            this.navigationWindow.Controls.Add(this.bottomInfo);
            this.navigationWindow.Controls.Add(this.pageContent);
            this.navigationWindow.Controls.Add(this.forwardsBtn);
            this.navigationWindow.Controls.Add(this.backBtn);
            this.navigationWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationWindow.Location = new System.Drawing.Point(3, 3);
            this.navigationWindow.Name = "navigationWindow";
            this.navigationWindow.Size = new System.Drawing.Size(1535, 930);
            this.navigationWindow.TabIndex = 5;
            // 
            // menuBtn
            // 
            this.menuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBtn.Location = new System.Drawing.Point(1381, 3);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(141, 60);
            this.menuBtn.TabIndex = 8;
            this.menuBtn.Text = "Menu";
            this.menuBtn.UseVisualStyleBackColor = true;
            // 
            // bottomInfo
            // 
            this.bottomInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomInfo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.bottomInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleSource});
            this.bottomInfo.Location = new System.Drawing.Point(0, 880);
            this.bottomInfo.Name = "bottomInfo";
            this.bottomInfo.Size = new System.Drawing.Size(1535, 50);
            this.bottomInfo.TabIndex = 5;
            this.bottomInfo.Text = "toolStrip1";
            // 
            // toggleSource
            // 
            this.toggleSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggleSource.Image = ((System.Drawing.Image)(resources.GetObject("toggleSource.Image")));
            this.toggleSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleSource.Name = "toggleSource";
            this.toggleSource.Size = new System.Drawing.Size(46, 44);
            this.toggleSource.Text = "viewPageSource";
            this.toggleSource.ToolTipText = "Toggle between HTTP source code view and the rendered web page";
            // 
            // pageContent
            // 
            this.pageContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageContent.AutoScroll = true;
            this.pageContent.Controls.Add(this.menuPane);
            this.pageContent.Location = new System.Drawing.Point(6, 72);
            this.pageContent.Name = "pageContent";
            this.pageContent.Size = new System.Drawing.Size(1529, 802);
            this.pageContent.TabIndex = 6;
            // 
            // menuPane
            // 
            this.menuPane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPane.Dock = System.Windows.Forms.DockStyle.None;
            this.menuPane.Enabled = false;
            this.menuPane.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuPane.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBack,
            this.menuForwards,
            this.menuFavourites,
            this.menuSettings});
            this.menuPane.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuPane.Location = new System.Drawing.Point(1380, 0);
            this.menuPane.Name = "menuPane";
            this.menuPane.Size = new System.Drawing.Size(149, 148);
            this.menuPane.TabIndex = 7;
            this.menuPane.Text = "Menu";
            this.menuPane.Visible = false;
            this.menuPane.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuBtn_ItemClicked);
            // 
            // menuBack
            // 
            this.menuBack.Name = "menuBack";
            this.menuBack.Size = new System.Drawing.Size(84, 36);
            this.menuBack.Text = "Back";
            // 
            // menuForwards
            // 
            this.menuForwards.Name = "menuForwards";
            this.menuForwards.Size = new System.Drawing.Size(130, 36);
            this.menuForwards.Text = "Forwards";
            // 
            // menuFavourites
            // 
            this.menuFavourites.Name = "menuFavourites";
            this.menuFavourites.Size = new System.Drawing.Size(143, 36);
            this.menuFavourites.Text = "Favourites";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(121, 36);
            this.menuSettings.Text = "Settings";
            // 
            // NewTab
            // 
            this.NewTab.Location = new System.Drawing.Point(8, 39);
            this.NewTab.Name = "NewTab";
            this.NewTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewTab.Size = new System.Drawing.Size(1352, 1102);
            this.NewTab.TabIndex = 1;
            this.NewTab.Text = "+";
            this.NewTab.UseVisualStyleBackColor = true;
            // 
            // goBtn
            // 
            this.goBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBtn.Location = new System.Drawing.Point(1273, 3);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(102, 60);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // BrowserWindow
            // 
            this.AcceptButton = this.goBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 995);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(660, 420);
            this.Name = "BrowserWindow";
            this.Text = "Browser";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.navigationWindow.ResumeLayout(false);
            this.navigationWindow.PerformLayout();
            this.bottomInfo.ResumeLayout(false);
            this.bottomInfo.PerformLayout();
            this.pageContent.ResumeLayout(false);
            this.pageContent.PerformLayout();
            this.menuPane.ResumeLayout(false);
            this.menuPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox URLInput;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button forwardsBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage NewTab;
        private System.Windows.Forms.Panel navigationWindow;
        private System.Windows.Forms.Panel pageContent;
        private System.Windows.Forms.ToolStrip bottomInfo;
        private System.Windows.Forms.ToolStripButton toggleSource;
        private System.Windows.Forms.MenuStrip menuPane;
        private System.Windows.Forms.ToolStripMenuItem menuBack;
        private System.Windows.Forms.ToolStripMenuItem menuForwards;
        private System.Windows.Forms.ToolStripMenuItem menuFavourites;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.Button menuBtn;
        private System.Windows.Forms.Button goBtn;
        private System.Diagnostics.EventLog eventLog1;
    }
}

