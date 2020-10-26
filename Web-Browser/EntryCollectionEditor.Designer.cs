namespace Web_Browser
{
    partial class EntryCollectionEditor
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
            this.EditBtn = new System.Windows.Forms.Button();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.FilterInput = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.EntrySelector = new System.Windows.Forms.ListView();
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UrlColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.Enabled = false;
            this.EditBtn.Location = new System.Drawing.Point(745, 10);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(116, 40);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Edit...";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // FilterBtn
            // 
            this.FilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterBtn.Location = new System.Drawing.Point(745, 56);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(116, 40);
            this.FilterBtn.TabIndex = 2;
            this.FilterBtn.Text = "Filter...";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(12, 10);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(116, 40);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // DoneBtn
            // 
            this.DoneBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneBtn.Location = new System.Drawing.Point(12, 439);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(849, 40);
            this.DoneBtn.TabIndex = 5;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = true;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // FilterInput
            // 
            this.FilterInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterInput.Location = new System.Drawing.Point(12, 61);
            this.FilterInput.Name = "FilterInput";
            this.FilterInput.Size = new System.Drawing.Size(727, 35);
            this.FilterInput.TabIndex = 6;
            this.FilterInput.Text = "All";
            this.FilterInput.TextChanged += new System.EventHandler(this.FilterInput_TextChanged);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(134, 10);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(116, 40);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // EntrySelector
            // 
            this.EntrySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntrySelector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleColumn,
            this.UrlColumn,
            this.DateColumn});
            this.EntrySelector.FullRowSelect = true;
            this.EntrySelector.HideSelection = false;
            this.EntrySelector.Location = new System.Drawing.Point(12, 102);
            this.EntrySelector.Name = "EntrySelector";
            this.EntrySelector.Size = new System.Drawing.Size(849, 331);
            this.EntrySelector.TabIndex = 8;
            this.EntrySelector.UseCompatibleStateImageBehavior = false;
            this.EntrySelector.View = System.Windows.Forms.View.Details;
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            this.TitleColumn.Width = 100;
            // 
            // UrlColumn
            // 
            this.UrlColumn.Text = "URL";
            this.UrlColumn.Width = 150;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Time & Date";
            this.DateColumn.Width = 145;
            // 
            // EntryCollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 487);
            this.Controls.Add(this.EntrySelector);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.FilterInput);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.EditBtn);
            this.Name = "EntryCollectionEditor";
            this.Text = "EntryCollectionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.TextBox FilterInput;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.ListView EntrySelector;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader UrlColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
    }
}