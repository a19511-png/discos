using discos2;
using System;
using System.Windows.Forms;

namespace discos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();

            Application.Run(login);
        }
    }
}
