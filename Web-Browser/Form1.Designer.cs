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
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.Location = new System.Drawing.Point(11, 11);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(90, 80);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "←";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // ForwardsBtn
            // 
            this.ForwardsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForwardsBtn.Location = new System.Drawing.Point(105, 11);
            this.ForwardsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardsBtn.Name = "ForwardsBtn";
            this.ForwardsBtn.Size = new System.Drawing.Size(90, 80);
            this.ForwardsBtn.TabIndex = 3;
            this.ForwardsBtn.Text = "→";
            this.ForwardsBtn.UseVisualStyleBackColor = true;
            // 
            // HomeBtn
            // 
            this.HomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.Location = new System.Drawing.Point(293, 11);
            this.HomeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(90, 80);
            this.HomeBtn.TabIndex = 10;
            this.HomeBtn.Text = "⌂";
            this.HomeBtn.UseVisualStyleBackColor = true;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.Location = new System.Drawing.Point(199, 11);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(90, 80);
            this.RefreshBtn.TabIndex = 1;
            this.RefreshBtn.Text = "⭮";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            // 
            // GoBtn
            // 
            this.GoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBtn.Location = new System.Drawing.Point(1047, 14);
            this.GoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(90, 80);
            this.GoBtn.TabIndex = 1;
            this.GoBtn.Text = "Go";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // MenuBtn
            // 
            this.MenuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtn.Location = new System.Drawing.Point(1141, 14);
            this.MenuBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MenuBtn.Name = "MenuBtn";
            this.MenuBtn.Size = new System.Drawing.Size(120, 80);
            this.MenuBtn.TabIndex = 8;
            this.MenuBtn.Text = "Menu";
            this.MenuBtn.UseVisualStyleBackColor = true;
            // 
            // UrlInput
            // 
            this.UrlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlInput.Location = new System.Drawing.Point(396, 33);
            this.UrlInput.Margin = new System.Windows.Forms.Padding(2);
            this.UrlInput.Name = "UrlInput";
            this.UrlInput.Size = new System.Drawing.Size(637, 44);
            this.UrlInput.TabIndex = 0;
            // 
            // SourceViewer
            // 
            this.SourceViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceViewer.BackColor = System.Drawing.Color.White;
            this.SourceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SourceViewer.Location = new System.Drawing.Point(11, 108);
            this.SourceViewer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceViewer.Multiline = true;
            this.SourceViewer.Name = "SourceViewer";
            this.SourceViewer.ReadOnly = true;
            this.SourceViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SourceViewer.Size = new System.Drawing.Size(1250, 553);
            this.SourceViewer.TabIndex = 0;
            // 
            // BrowserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 670);
            this.Controls.Add(this.SourceViewer);
            this.Controls.Add(this.UrlInput);
            this.Controls.Add(this.MenuBtn);
            this.Controls.Add(this.GoBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.ForwardsBtn);
            this.Controls.Add(this.BackBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(658, 416);
            this.Name = "BrowserWindow";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.BrowserWindow_Load);
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
    }
}

