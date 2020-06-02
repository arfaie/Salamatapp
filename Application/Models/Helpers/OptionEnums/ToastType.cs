using System.ComponentModel;

namespace Application.Net.OptionEnums
{
    public enum ToastType
    {
        //blue, red, green, yellow
        [Description("success")]
        green,

        [Description("info")]
        blue,

        [Description("warning")]
        yellow,

        [Description("error")]
        red,

    }


}
