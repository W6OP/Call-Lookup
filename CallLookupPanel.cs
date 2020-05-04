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
        private CallLookUp _CallLookUp;

        public CallLookupPanel()
        {
            InitializeComponent();

            _PrefixFileParser = new PrefixFileParser();
            _PrefixFileParser.ParsePrefixFile("");

            _CallLookUp = new CallLookUp(_PrefixFileParser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewResults.Items.Clear();

            if (TextBoxCallSign.Text != "")
            {
                IEnumerable<CallSignInfo> hitCollection = _CallLookUp.LookUpCall(TextBoxCallSign.Text);

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

        private void TextBoxCallSign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    } // end class
}
