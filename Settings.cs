using System;
using System.ComponentModel;

namespace W6OP
{
    public class Settings: Object
    {
        //this setting is saved/restored and editable by user
        //[DisplayName("Dock to Right")]
        //[Description("Dock to the right side of the window")]
        //[DefaultValue(true)]
        //public bool DockToRight { get; set; } = true;

        [DisplayName("QRZ.com Logon Id")]
        [Description("Enter your QRZ logon id")]
        [DefaultValue("")]
        public string QRZLogonId { get; set; }

        // later need to encrypt before saving
        [DisplayName("QRZ.com Password")]
        [Description("Enter your QRZ password")]
        [DefaultValue("")]
        public string QRZPassword { get; set; }
    }
}
