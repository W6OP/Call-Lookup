using System.ComponentModel;

namespace W6OP
{
    public enum Units
    {
        Kilometers,
        Miles
    }
    public class Settings : object
    {
        [DisplayName("QRZ.com Logon Id")]
        [Description("Enter your QRZ logon id")]
        [DefaultValue("")]
        public string QRZLogonId { get; set; }

        // later need to encrypt before saving
        [DisplayName("QRZ.com Password")]
        [Description("Enter your QRZ password")]
        [DefaultValue("")]
        public string QRZPassword { get; set; }

        [DisplayName("Grid Square")]
        [Description("Enter 6 character grid for your location")]
        [DefaultValue("")]
        public string Grid { get; set; }

        [DisplayName("Display Units")]
        [Description("Enter units miles/kilometers")]
        [DefaultValue("Kilometers")]
        public Units Unit { get; set; }
    }
}
