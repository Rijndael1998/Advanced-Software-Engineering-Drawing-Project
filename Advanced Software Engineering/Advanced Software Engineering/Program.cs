using System;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {

    internal static class Program {
        public static Form MainMenu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainMenu = new Menu();
            Application.Run(MainMenu);
        }
    }
}