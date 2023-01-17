using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace LobbySpy
{
    internal static class Program
    {
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("Please run as administrator.", "Administrator needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
