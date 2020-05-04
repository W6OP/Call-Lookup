using System;
using System.ComponentModel.Composition;
using VE3NEA.HamCockpit.PluginAPI;
using System.Windows.Forms;

namespace W6OP
{
    [Export(typeof(IPlugin))]
    public class CallLookup : IPlugin, IDisposable
    {

        private CallLookupPanel lookup = new CallLookupPanel();
        private Settings settings = new Settings();
       

        #region iPlugin Implementation

        public string Name => "Call Lookup";

        public string Author => "W6OP";

        private bool enabled;
        public bool Enabled { get => enabled; set => enabled = value; }

        public object Settings { get => GetSettings(); set => ApplySettings(value as Settings); }

        private void ApplySettings(Settings settings)
        {
            lookup.QRZLogonId = settings.QRZLogonId.ToUpper();
            lookup.QRZPassword = settings.QRZPassword;
           
        }

        private object GetSettings()
        {
            settings.QRZLogonId = lookup.QRZLogonId;
            settings.QRZPassword = lookup.QRZPassword;
            return settings;
        }

        public ToolStrip ToolStrip => null;

        public ToolStripItem StatusItem => null;

        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }// end class
   



   

   







}
