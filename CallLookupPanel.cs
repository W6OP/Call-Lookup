using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using W6OP.CallParser;

namespace W6OP
{
    public partial class CallLookupPanel : UserControl
    {
        // prefix file parser and call lookup class instances
        private readonly PrefixFileParser PrefixFileParser;
        private CallLookUp CallLookUp;
        Settings settings;
       
        // plugin instance
        public CallLookupPlugin Plugin;

        // these must be initialized or GetSettings() fails
        public string QRZLogonId = "";
        public string QRZPassword = "";

        public CallLookupPanel()
        {
            InitializeComponent();

            PrefixFileParser = new PrefixFileParser();
            PrefixFileParser.ParsePrefixFile("");
            CallLookUp = new CallLookUp(PrefixFileParser); 
        }


        private void CallLookupPanel_Load(object sender, EventArgs e)
        {
            settings = (Settings)Plugin.Settings;
            TextBoxCallSign.Focus();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ButtonLookupCall.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCallLookup_Click(object sender, EventArgs e)
        {
            IEnumerable<CallSignInfo> hitCollection;

            ListViewResults.Items.Clear();
            //ClearAllLabels();

            try
            {
                if (TextBoxCallSign.Text != "")
                {
                    if (CheckBoxQRZ.Checked)
                    {
                        if (!string.IsNullOrEmpty(settings.QRZLogonId) && !string.IsNullOrEmpty(settings.QRZLogonId))
                        {
                            hitCollection = CallLookUp.LookUpCall(TextBoxCallSign.Text, settings.QRZLogonId, settings.QRZPassword);
                        }
                        else
                        {
                            MessageBox.Show("Please go to Plugin Settings and add your QRZ.com credentials", "Missing Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        hitCollection = CallLookUp.LookUpCall(TextBoxCallSign.Text);
                    }

                    if (hitCollection != null)
                    {
                        var hitList = hitCollection.ToList();
                        foreach (CallSignInfo hit in hitList)
                        {
                            UpdateListViewResults(hit.CallSign, hit.Kind, hit.Country, hit.Province, hit.DXCC.ToString(), hit.IsQRZInformation, hit);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        }

        /// <summary>
        /// Prevent cross thread calls.
        /// </summary>
        /// <param name="call"></param>
        /// <param name="clear"></param>
        private void UpdateListViewResults(string call, PrefixKind kind, string country, string province, string dxcc, bool isQRZ, CallSignInfo hit)
        {
            if (!InvokeRequired)
            {
                ListViewItem item;

                if (kind == PrefixKind.DXCC)
                {
                    item = new ListViewItem(call);
                    item.BackColor = Color.Thistle;
                }
                else
                {
                    item = new ListViewItem(call);
                    item.BackColor = Color.LavenderBlush;
                }

                item.SubItems.Add(kind.ToString());
                item.SubItems.Add(country);
                item.SubItems.Add(province ?? "");
                item.SubItems.Add(dxcc);

                if (isQRZ)
                {
                    item.SubItems.Add("QRZ");
                    item.Tag = hit;
                }
                else
                {
                    item.SubItems.Add("");
                }

                ListViewResults.Items.Add(item);
            }
            else
            {
                BeginInvoke(new Action<string, PrefixKind, string, string, string, bool, CallSignInfo>(this.UpdateListViewResults), call, kind, country, province, dxcc, isQRZ, hit);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCallSign_KeyDown(object sender, KeyEventArgs e)
        {
            if(!CheckBoxQRZ.Checked)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ButtonCallLookup_Click(this, new EventArgs());
                }
            }
            else
            {
                if (TextBoxCallSign.Text.Length > 2)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        ButtonCallLookup_Click(this, new EventArgs());
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            QRZDetailForm detail;

            if (ListViewResults.SelectedItems.Count > 0)
            {
                ListViewItem item = ListViewResults.SelectedItems[0];
                if (item.Tag != null)
                {
                    detail = new QRZDetailForm((CallSignInfo)item.Tag);
                    detail.StartPosition = FormStartPosition.CenterParent;
                    detail.Show(this);
                }
            }
        }
    } // end class
}
