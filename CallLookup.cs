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

        private CallLookupPanel panel;

        #region iPlugin Implementation

        public string Name => "Call Lookup";

        public string Author => "Peter Bourget W6OP";

        private bool enabled;
        public bool Enabled { get => enabled; set => enabled = value; }

        public object Settings { get => Settings; set => Settings = value; }

        public ToolStrip ToolStrip => null;

        public ToolStripItem StatusItem => null;

        #endregion

        #region IVisualPlugin Implementation

        public bool CanCreatePanel => true;

        public UserControl CreatePanel()
        {
            panel = new CallLookupPanel { Name = "Call Lookup Panel" };
            return panel;
        }

        public void DestroyPanel(UserControl panel)
        {
            this.panel = null;
        }

        #endregion


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }// end class
   



   

   







}
