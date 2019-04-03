using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.UserSkins.BonusSkins.Register();

            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier);
            UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.Bezier.OfficeDarkGray);

            WindowsFormsSettings.DefaultFont = new Font("Segoe UI", 8F);

            Application.Run(new frmMain());
        }
    }
}