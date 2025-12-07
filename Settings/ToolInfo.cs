using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NFSColorRX
{
    public static class ToolInfo
    {
        public const string Name = "NFS Color R-X";
        public const string Version = "v1.3";
        public const string Authors = "FiLixsi";
        public static string FullTitle => $"{Name} {Version} | By {Authors}";
    }

    public static class ToolInfoInit
    {
        public static void Apply(Form form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = ToolInfo.FullTitle;
            form.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
