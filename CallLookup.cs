using System;
using System.ComponentModel.Composition;
using VE3NEA.HamCockpit.PluginAPI;
using System.Windows.Forms;

namespace W6OP
{
    [Export(typeof(IPlugin))]
    [Export(typeof(IVisualPlugin))]
    public class CallLookup : IPlugin, IDisposable, IVisualPlugin
    {
        private CallLookupPanel lookupPanel;
        private Settings settings = new Settings();

        private CallLookup()
        {
           
        }

        #region iPlugin Implementation

        public string Name => "Call Lookup";

        public string Author => "W6OP";

        private bool enabled;
        public bool Enabled { get => enabled; set => enabled = value; }

        public object Settings { get => settings; set => settings = (value as Settings); }

        public ToolStrip ToolStrip => null;

        public ToolStripItem StatusItem => null;

        public bool CanCreatePanel => true;

        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public UserControl CreatePanel()
        {
            lookupPanel = new CallLookupPanel { Name = "Call Lookup" };
            return lookupPanel;
        }

        public void DestroyPanel(UserControl panel)
        {
            lookupPanel.Dispose();
            lookupPanel = null;
        }
    }// end class
   



   

   







}
