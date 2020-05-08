using System;
using System.ComponentModel.Composition;
using VE3NEA.HamCockpit.PluginAPI;
using System.Windows.Forms;
using System.Reflection;

namespace W6OP
{
    [Export(typeof(IPlugin))]
    [Export(typeof(IVisualPlugin))]
    public class CallLookupPlugin : IPlugin, IDisposable, IVisualPlugin
    {
        private CallLookupPanel lookupPanel;
        private Settings settings = new Settings();

        #region iPlugin Implementation

        public string Name => "W6OP Call Lookup";

        public string Author => "W6OP";

        private bool enabled;
        public bool Enabled { get => enabled; set => enabled = value; }

        // public object Settings { get => settings; set => settings = (value as Settings); }
        public object Settings { get => GetSettings(); set => ApplySettings(value as Settings); }

        public object GetSettings()
        {
            return settings;
        }

        public void ApplySettings(Settings value)
        {
            settings = value;
        }

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
            lookupPanel = new CallLookupPanel { Name = GetTitleAndVersion() };
            lookupPanel.Plugin = this;
            return lookupPanel;
        }

        public void DestroyPanel(UserControl panel)
        {
            lookupPanel.Dispose();
            lookupPanel = null;
        }

        private string GetTitleAndVersion()
        {
            // get the version number
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName an = asm.GetName();
            string version = an.Version.Major + "." + an.Version.Minor + "." + an.Version.Build + "." + an.Version.Revision;
            return "Call Lookup (" + version + ")";
        }
    }// end class
   



   

   







}
