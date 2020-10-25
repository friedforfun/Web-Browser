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
            this.EntrySelector = new System.Windows.Forms.ListBox();
            this.EditBtn = new System.Windows.Forms.Button();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.FilterInput = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EntrySelector
            // 
            this.EntrySelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntrySelector.FormattingEnabled = true;
            this.EntrySelector.ItemHeight = 29;
            this.EntrySelector.Location = new System.Drawing.Point(12, 109);
            this.EntrySelector.Name = "EntrySelector";
            this.EntrySelector.Size = new System.Drawing.Size(437, 323);
            this.EntrySelector.TabIndex = 0;
            // 
            // EditBtn
            // 
            this.EditBtn.Enabled = false;
            this.EditBtn.Location = new System.Drawing.Point(333, 3);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(116, 40);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Edit...";
            this.EditBtn.UseVisualStyleBackColor = true;
            // 
            // FilterBtn
            // 
            this.FilterBtn.Location = new System.Drawing.Point(333, 56);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(116, 40);
            this.FilterBtn.TabIndex = 2;
            this.FilterBtn.Text = "Filter...";
            this.FilterBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(12, 3);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(116, 40);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // DoneBtn
            // 
            this.DoneBtn.Location = new System.Drawing.Point(12, 439);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(437, 40);
            this.DoneBtn.TabIndex = 5;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = true;
            // 
            // FilterInput
            // 
            this.FilterInput.Enabled = false;
            this.FilterInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterInput.Location = new System.Drawing.Point(12, 56);
            this.FilterInput.Name = "FilterInput";
            this.FilterInput.Size = new System.Drawing.Size(301, 35);
            this.FilterInput.TabIndex = 6;
            this.FilterInput.Text = "All";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(175, 3);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(116, 40);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            // 
            // EntryCollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 487);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.FilterInput);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.EntrySelector);
            this.Name = "EntryCollectionEditor";
            this.Text = "EntryCollectionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox EntrySelector;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.TextBox FilterInput;
        private System.Windows.Forms.Button ClearBtn;
    }
}