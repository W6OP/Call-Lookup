namespace W6OP
{
    partial class CallLookupPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonLookupCall = new System.Windows.Forms.Button();
            this.TextBoxCallSign = new System.Windows.Forms.TextBox();
            this.ListViewResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ButtonLookupCall
            // 
            this.ButtonLookupCall.Location = new System.Drawing.Point(0, 6);
            this.ButtonLookupCall.Name = "ButtonLookupCall";
            this.ButtonLookupCall.Size = new System.Drawing.Size(75, 23);
            this.ButtonLookupCall.TabIndex = 0;
            this.ButtonLookupCall.Text = "Lookup Call";
            this.ButtonLookupCall.UseVisualStyleBackColor = true;
            this.ButtonLookupCall.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextBoxCallSign
            // 
            this.TextBoxCallSign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxCallSign.Location = new System.Drawing.Point(81, 8);
            this.TextBoxCallSign.Name = "TextBoxCallSign";
            this.TextBoxCallSign.Size = new System.Drawing.Size(135, 20);
            this.TextBoxCallSign.TabIndex = 1;
            this.TextBoxCallSign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCallSign_KeyDown);
            // 
            // ListViewResults
            // 
            this.ListViewResults.BackColor = System.Drawing.Color.Honeydew;
            this.ListViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.ListViewResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListViewResults.HideSelection = false;
            this.ListViewResults.Location = new System.Drawing.Point(0, 41);
            this.ListViewResults.Name = "ListViewResults";
            this.ListViewResults.Size = new System.Drawing.Size(647, 202);
            this.ListViewResults.TabIndex = 13;
            this.ListViewResults.UseCompatibleStateImageBehavior = false;
            this.ListViewResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Call";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kind";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Country";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Province";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dxcc";
            this.columnHeader5.Width = 119;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Call Sign Flags";
            this.columnHeader6.Width = 150;
            // 
            // CallLookupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListViewResults);
            this.Controls.Add(this.TextBoxCallSign);
            this.Controls.Add(this.ButtonLookupCall);
            this.Name = "CallLookupPanel";
            this.Size = new System.Drawing.Size(647, 243);
            this.VisibleChanged += new System.EventHandler(this.button1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLookupCall;
        private System.Windows.Forms.TextBox TextBoxCallSign;
        private System.Windows.Forms.ListView ListViewResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
