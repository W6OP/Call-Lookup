using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6OP
{
    public class Settings
    {
        public Settings()
        {

        }

        //this setting is saved/restored and editable by user
        [DisplayName("Dock to Right")]
        [Description("Dock to the right side of the window")]
        [DefaultValue(true)]
        public bool DockToRight { get; set; } = true;

        [DisplayName("QRZ.com Logon Id")]
        [Description("Enter your QRZ logon id")]
        [DefaultValue(true)]
        public bool QRZLogonId { get; set; } = true;

        // later need to encrypt before saving
        [DisplayName("QRZ.com Password")]
        [Description("Enter your QRZ password")]
        [DefaultValue(true)]
        public bool QRZPassword { get; set; } = true;
    }
}
