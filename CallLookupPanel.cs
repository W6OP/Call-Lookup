using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using W6OP.CallParser;

namespace W6OP
{
    public partial class CallLookupPanel : UserControl
    {
        private readonly PrefixFileParser _PrefixFileParser;
        private CallLookUp CallLookUp;

        // these must be initialized or GetSettings() fails
        public string QRZLogonId = "";
        public string QRZPassword = "";

        public CallLookupPanel()
        {
            InitializeComponent();

            _PrefixFileParser = new PrefixFileParser();
            _PrefixFileParser.ParsePrefixFile("");

            CallLookUp = new CallLookUp(_PrefixFileParser);
        }


        private void CallLookupPanel_Load(object sender, EventArgs e)
        {
            //Settings settings = CallLookup.Se;
            //TextBoxCallSign.Text = settings.QRZLogonId;
            //TextBoxQRZPassword.Text = settings.QRZPassword;
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

            if (TextBoxCallSign.Text != "")
            {
                if (CheckBoxQRZ.Checked)
                {
                     hitCollection = CallLookUp.LookUpCall(TextBoxCallSign.Text, TextBoxQRZuserId.Text, TextBoxQRZPassword.Text);
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
                        var flags = string.Join(",", hit.CallSignFlags);
                        UpdateListViewResults(hit.CallSign, hit.Kind, hit.Country, hit.Province, hit.DXCC.ToString(), flags);
                    }
                }
            }
        }

        /// <summary>
        /// Prevent cross thread calls.
        /// </summary>
        /// <param name="call"></param>
        /// <param name="clear"></param>
        private void UpdateListViewResults(string call, PrefixKind kind, string country, string province, string dxcc, string flags)
        {
            if (!InvokeRequired)
            {
                ListViewItem item;

                if (kind == PrefixKind.DXCC)
                {
                    item = new ListViewItem(call);
                    item.BackColor = Color.Honeydew;
                }
                else
                {
                    item = new ListViewItem("--- " + call);
                    item.BackColor = Color.LightGray;
                }

                item.SubItems.Add(kind.ToString());
                item.SubItems.Add(country);
                item.SubItems.Add(province ?? "");
                item.SubItems.Add(dxcc);
                item.SubItems.Add(flags);
                ListViewResults.Items.Add(item);
                Application.DoEvents();
            }
            else
            {
                this.BeginInvoke(new Action<string, PrefixKind, string, string, string, string>(this.UpdateListViewResults), call, kind, country, province, dxcc, flags);
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

        #region QRZ

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxQRZuserId_Enter(object sender, EventArgs e)
        {
            if (TextBoxQRZuserId.Text == "")
            {
                TextBoxQRZuserId.Text = "QRZ User Id";
                TextBoxQRZuserId.ForeColor = Color.Gray;
            }
            else
            {
                TextBoxQRZuserId.Text = "";
                TextBoxQRZuserId.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxQRZPassword_Enter(object sender, EventArgs e)
        {

            if (TextBoxQRZPassword.Text == "")
            {
                TextBoxQRZPassword.PasswordChar = '\0';
                TextBoxQRZPassword.Text = "QRZ Password";
                TextBoxQRZPassword.ForeColor = Color.Gray;
            }
            else
            {
                TextBoxQRZPassword.PasswordChar = '*';
                TextBoxQRZPassword.Text = "";
                TextBoxQRZPassword.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxQRZuserId_Leave(object sender, EventArgs e)
        {
            if (TextBoxQRZuserId.Text == "")
            {
                TextBoxQRZuserId.Text = "QRZ User Id";
                TextBoxQRZuserId.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxQRZPassword_Leave(object sender, EventArgs e)
        {
            if (TextBoxQRZPassword.Text == "")
            {
                TextBoxQRZPassword.PasswordChar = '\0';
                TextBoxQRZPassword.Text = "QRZ Password";
                TextBoxQRZPassword.ForeColor = Color.Gray;
            }
        }

        #endregion

    } // end class
}
