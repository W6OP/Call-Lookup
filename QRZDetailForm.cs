using System.Linq;
using System.Windows.Forms;
using W6OP.CallParser;

namespace W6OP
{
    public partial class QRZDetailForm : Form
    {
        private CallSignInfo hit;

        public QRZDetailForm(CallSignInfo callSignInfo)
        {
            hit = callSignInfo;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QRZDetailForm_Load(object sender, System.EventArgs e)
        {
            UpdateDisplayPanel();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateDisplayPanel()
        {
            ClearAllLabels();

            LabelCall.Text = hit.CallSign;
            LabelName.Text = hit.FirstName + " " + hit.LastName;
            LabelCountry.Text = hit.Country;
            LabelProvince.Text = hit.Province;
            LabelCounty.Text = hit.County;
            LabelLatitude.Text = hit.Latitude;
            LabelLongitude.Text = hit.Longitude;
            LabelGrid.Text = hit.Grid;
            LabelCQZone.Text = "CQ Zone: " + hit.CQ.First().ToString();
            LabelITUZone.Text = "ITU Zone: " + hit.ITU.First().ToString();

            LabelLotw.Text = hit.LotW ? "LoTW: Yes" : "LoTW: No";
        }


        /// <summary>
        /// Clear all the labels on the QRZ display panel.
        /// </summary>
        private void ClearAllLabels()
        {
            foreach (Label label in PanelQRZDisplay.Controls)
            {
                label.Text = "";
            }
        }

      
    } // end class
}
