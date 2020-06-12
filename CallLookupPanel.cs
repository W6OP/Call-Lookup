using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unclassified.Util;
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
        public string Grid = "";

        /// <summary>
        /// Constuctor.
        /// </summary>
        public CallLookupPanel()
        {
            InitializeComponent();

            PrefixFileParser = new PrefixFileParser();
            PrefixFileParser.ParsePrefixFile("");
            CallLookUp = new CallLookUp(PrefixFileParser);
        }


        /// <summary>
        /// Initialization after window loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallLookupPanel_Load(object sender, EventArgs e)
        {
            settings = (Settings)Plugin.Settings;
            TextBoxCallSign.Focus();
        }


        /// <summary>
        /// Captures the Enter key when in the Call Sign textbox.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
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
        /// Look up a call sign.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCallLookup_Click(object sender, EventArgs e)
        {
            IEnumerable<CallSignInfo> hitCollection;
            string heading;
            string distance;
            string grid = "";

            ListViewResults.Items.Clear();

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
                            if (settings.Grid != "")
                            {
                                grid = GetGridFromLatLong(hit.Latitude,hit.Longitude);
                                heading = GetHeading(grid);
                                distance = GetDistance(grid);
                            } else
                            {
                                heading = "0";
                                distance = "0";
                            }

                            UpdateListViewResults(hit, heading, distance, grid);
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
        /// Get the heading from one grid to another.
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        private string GetHeading(string destination)
        {
            string homeLocation = settings.Grid;
            double azimuth = MaidenheadLocator.Azimuth(homeLocation.ToUpper(), destination.ToUpper());

            return string.Format("{0:0.##}", azimuth);
        }

        /// <summary>
        /// Get the distance from one grid to another.
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        private string GetDistance(string destination)
        {
            string homeLocation = settings.Grid;
            double distance = MaidenheadLocator.Distance(homeLocation.ToUpper(), destination.ToUpper());

            if (settings.Unit == Units.Miles)
            {
                distance /= 1.6;
            }

            return string.Format("{0:0.##}", distance);
        }

        /// <summary>
        /// Get the maidenhead grid form the latitude and longitude.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        private string GetGridFromLatLong(string latitude, string longitude)
        {
            double lat = Convert.ToDouble(latitude);
            double lon = Convert.ToDouble(longitude);

            string grid = MaidenheadLocator.LatLngToLocator(lat, lon);

            return grid;
        }

        /// <summary>
        /// Display the results in a ListView
        /// Prevent cross thread calls.
        /// </summary>
        /// <param name="call"></param>
        /// <param name="clear"></param>
        private void UpdateListViewResults(CallSignInfo hit, string heading, string distance, string grid)
        {
            if (!InvokeRequired)
            {
                ListViewItem item;

                if (hit.Kind == PrefixKind.DXCC)
                {
                    item = new ListViewItem(hit.CallSign);
                    item.BackColor = Color.Thistle;
                }
                else
                {
                    item = new ListViewItem(hit.CallSign);
                    item.BackColor = Color.LavenderBlush;
                }

                item.SubItems.Add(hit.Kind.ToString());
                item.SubItems.Add(hit.Country);
                item.SubItems.Add(hit.Province ?? "");
                item.SubItems.Add(hit.DXCC.ToString());

                if (hit.IsQRZInformation)
                {
                    item.SubItems.Add("QRZ");
                    item.Tag = hit;
                }
                else
                {
                    item.SubItems.Add("");
                }

                //heading = String.Format("{0:0.##}", heading);
                //distance = String.Format("{0:0.##}", distance);

                item.SubItems.Add(heading);
                item.SubItems.Add(distance);
                item.SubItems.Add(grid);

                ListViewResults.Items.Add(item);
            }
            else
            {
                BeginInvoke(new Action<CallSignInfo, string, string, string>(this.UpdateListViewResults), hit, heading, distance, grid);
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
