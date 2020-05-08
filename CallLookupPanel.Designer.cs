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
            this.CheckBoxQRZ = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonLookupCall
            // 
            this.ButtonLookupCall.Location = new System.Drawing.Point(197, 16);
            this.ButtonLookupCall.Name = "ButtonLookupCall";
            this.ButtonLookupCall.Size = new System.Drawing.Size(87, 23);
            this.ButtonLookupCall.TabIndex = 1;
            this.ButtonLookupCall.Text = "Lookup Call";
            this.ButtonLookupCall.UseVisualStyleBackColor = true;
            this.ButtonLookupCall.Click += new System.EventHandler(this.ButtonCallLookup_Click);
            // 
            // TextBoxCallSign
            // 
            this.TextBoxCallSign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxCallSign.Location = new System.Drawing.Point(34, 17);
            this.TextBoxCallSign.Name = "TextBoxCallSign";
            this.TextBoxCallSign.Size = new System.Drawing.Size(157, 23);
            this.TextBoxCallSign.TabIndex = 0;
            this.TextBoxCallSign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCallSign_KeyDown);
            // 
            // ListViewResults
            // 
            this.ListViewResults.BackColor = System.Drawing.Color.Ivory;
            this.ListViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.ListViewResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListViewResults.HideSelection = false;
            this.ListViewResults.Location = new System.Drawing.Point(0, 51);
            this.ListViewResults.Name = "ListViewResults";
            this.ListViewResults.Size = new System.Drawing.Size(499, 197);
            this.ListViewResults.TabIndex = 13;
            this.ListViewResults.TabStop = false;
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
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dxcc";
            this.columnHeader5.Width = 100;
            // 
            // CheckBoxQRZ
            // 
            this.CheckBoxQRZ.AutoSize = true;
            this.CheckBoxQRZ.Location = new System.Drawing.Point(301, 19);
            this.CheckBoxQRZ.Name = "CheckBoxQRZ";
            this.CheckBoxQRZ.Size = new System.Drawing.Size(117, 19);
            this.CheckBoxQRZ.TabIndex = 2;
            this.CheckBoxQRZ.Text = "Add QRZ Lookup";
            this.CheckBoxQRZ.UseVisualStyleBackColor = true;
            // 
            // CallLookupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.CheckBoxQRZ);
            this.Controls.Add(this.ListViewResults);
            this.Controls.Add(this.TextBoxCallSign);
            this.Controls.Add(this.ButtonLookupCall);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CallLookupPanel";
            this.Size = new System.Drawing.Size(499, 248);
            this.Load += new System.EventHandler(this.CallLookupPanel_Load);
            this.VisibleChanged += new System.EventHandler(this.ButtonCallLookup_Click);
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
        private System.Windows.Forms.CheckBox CheckBoxQRZ;
    }
}
