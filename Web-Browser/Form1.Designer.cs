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
            this.NewTab = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.navigationWindow = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardsBtn = new System.Windows.Forms.Button();
            this.menuBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.URLInput = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.sourceViewer = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.homeBtn = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.navigationWindow.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewTab
            // 
            this.NewTab.Location = new System.Drawing.Point(8, 51);
            this.NewTab.Name = "NewTab";
            this.NewTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewTab.Size = new System.Drawing.Size(1541, 936);
            this.NewTab.TabIndex = 1;
            this.NewTab.Text = "+";
            this.NewTab.UseVisualStyleBackColor = true;
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
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // navigationWindow
            // 
            this.navigationWindow.Controls.Add(this.homeBtn);
            this.navigationWindow.Controls.Add(this.sourceViewer);
            this.navigationWindow.Controls.Add(this.goBtn);
            this.navigationWindow.Controls.Add(this.URLInput);
            this.navigationWindow.Controls.Add(this.refreshBtn);
            this.navigationWindow.Controls.Add(this.menuBtn);
            this.navigationWindow.Controls.Add(this.forwardsBtn);
            this.navigationWindow.Controls.Add(this.backBtn);
            this.navigationWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationWindow.Location = new System.Drawing.Point(3, 3);
            this.navigationWindow.Name = "navigationWindow";
            this.navigationWindow.Size = new System.Drawing.Size(1535, 930);
            this.navigationWindow.TabIndex = 5;
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
            // URLInput
            // 
            this.URLInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URLInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLInput.Location = new System.Drawing.Point(266, 7);
            this.URLInput.Name = "URLInput";
            this.URLInput.Size = new System.Drawing.Size(1001, 44);
            this.URLInput.TabIndex = 0;
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
            // sourceViewer
            // 
            this.sourceViewer.AutoEllipsis = true;
            this.sourceViewer.AutoSize = true;
            this.sourceViewer.BackColor = System.Drawing.Color.White;
            this.sourceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceViewer.Location = new System.Drawing.Point(6, 79);
            this.sourceViewer.Name = "sourceViewer";
            this.sourceViewer.Size = new System.Drawing.Size(2, 39);
            this.sourceViewer.TabIndex = 9;
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
            // homeBtn
            // 
            this.homeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.Location = new System.Drawing.Point(200, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(60, 60);
            this.homeBtn.TabIndex = 10;
            this.homeBtn.Text = "⌂";
            this.homeBtn.UseVisualStyleBackColor = true;
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
            this.tabPage1.ResumeLayout(false);
            this.navigationWindow.ResumeLayout(false);
            this.navigationWindow.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage NewTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel navigationWindow;
        private System.Windows.Forms.Label sourceViewer;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox URLInput;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button menuBtn;
        private System.Windows.Forms.Button forwardsBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button homeBtn;
    }
}

