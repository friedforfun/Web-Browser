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
            this.BackBtn = new System.Windows.Forms.Button();
            this.ForwardsBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.GoBtn = new System.Windows.Forms.Button();
            this.MenuBtn = new System.Windows.Forms.Button();
            this.UrlInput = new System.Windows.Forms.TextBox();
            this.SourceViewer = new System.Windows.Forms.TextBox();
            this.MenuPicker = new System.Windows.Forms.MenuStrip();
            this.SetHomePage = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFavourites = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.Location = new System.Drawing.Point(8, 9);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(68, 64);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "←";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ForwardsBtn
            // 
            this.ForwardsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForwardsBtn.Location = new System.Drawing.Point(79, 9);
            this.ForwardsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardsBtn.Name = "ForwardsBtn";
            this.ForwardsBtn.Size = new System.Drawing.Size(68, 64);
            this.ForwardsBtn.TabIndex = 3;
            this.ForwardsBtn.Text = "→";
            this.ForwardsBtn.UseVisualStyleBackColor = true;
            this.ForwardsBtn.Click += new System.EventHandler(this.ForwardsBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.Location = new System.Drawing.Point(220, 9);
            this.HomeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(68, 64);
            this.HomeBtn.TabIndex = 10;
            this.HomeBtn.Text = "⌂";
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.Location = new System.Drawing.Point(149, 9);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(68, 64);
            this.RefreshBtn.TabIndex = 1;
            this.RefreshBtn.Text = "⭮";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // GoBtn
            // 
            this.GoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBtn.Location = new System.Drawing.Point(785, 11);
            this.GoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(68, 64);
            this.GoBtn.TabIndex = 1;
            this.GoBtn.Text = "Go";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // MenuBtn
            // 
            this.MenuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtn.Location = new System.Drawing.Point(856, 11);
            this.MenuBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MenuBtn.Name = "MenuBtn";
            this.MenuBtn.Size = new System.Drawing.Size(90, 64);
            this.MenuBtn.TabIndex = 8;
            this.MenuBtn.Text = "Menu";
            this.MenuBtn.UseVisualStyleBackColor = true;
            this.MenuBtn.Click += new System.EventHandler(this.MenuBtn_Click);
            // 
            // UrlInput
            // 
            this.UrlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlInput.Location = new System.Drawing.Point(297, 26);
            this.UrlInput.Margin = new System.Windows.Forms.Padding(2);
            this.UrlInput.Name = "UrlInput";
            this.UrlInput.Size = new System.Drawing.Size(479, 35);
            this.UrlInput.TabIndex = 0;
            // 
            // SourceViewer
            // 
            this.SourceViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceViewer.BackColor = System.Drawing.Color.White;
            this.SourceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SourceViewer.Location = new System.Drawing.Point(8, 86);
            this.SourceViewer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceViewer.Multiline = true;
            this.SourceViewer.Name = "SourceViewer";
            this.SourceViewer.ReadOnly = true;
            this.SourceViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SourceViewer.Size = new System.Drawing.Size(938, 443);
            this.SourceViewer.TabIndex = 0;
            // 
            // MenuPicker
            // 
            this.MenuPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPicker.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuPicker.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuPicker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetHomePage,
            this.OpenFavourites});
            this.MenuPicker.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MenuPicker.Location = new System.Drawing.Point(721, 77);
            this.MenuPicker.Name = "MenuPicker";
            this.MenuPicker.Size = new System.Drawing.Size(186, 92);
            this.MenuPicker.TabIndex = 11;
            this.MenuPicker.Text = "MenuPicker";
            this.MenuPicker.Visible = false;
            // 
            // SetHomePage
            // 
            this.SetHomePage.Name = "SetHomePage";
            this.SetHomePage.Size = new System.Drawing.Size(179, 29);
            this.SetHomePage.Text = "Set Home Page";
            // 
            // OpenFavourites
            // 
            this.OpenFavourites.Name = "OpenFavourites";
            this.OpenFavourites.Size = new System.Drawing.Size(179, 29);
            this.OpenFavourites.Text = "Favourites";
            // 
            // BrowserWindow
            // 
            this.AcceptButton = this.GoBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 536);
            this.Controls.Add(this.SourceViewer);
            this.Controls.Add(this.UrlInput);
            this.Controls.Add(this.MenuBtn);
            this.Controls.Add(this.GoBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.ForwardsBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.MenuPicker);
            this.MainMenuStrip = this.MenuPicker;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(499, 344);
            this.Name = "BrowserWindow";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.BrowserWindow_Load);
            this.MenuPicker.ResumeLayout(false);
            this.MenuPicker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button BackBtn;
        public System.Windows.Forms.Button ForwardsBtn;
        public System.Windows.Forms.Button HomeBtn;
        public System.Windows.Forms.Button RefreshBtn;
        public System.Windows.Forms.Button GoBtn;
        public System.Windows.Forms.Button MenuBtn;
        public System.Windows.Forms.TextBox UrlInput;
        public System.Windows.Forms.TextBox SourceViewer;
        private System.Windows.Forms.MenuStrip MenuPicker;
        private System.Windows.Forms.ToolStripMenuItem SetHomePage;
        private System.Windows.Forms.ToolStripMenuItem OpenFavourites;
    }
}

