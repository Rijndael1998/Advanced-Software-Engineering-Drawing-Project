using System.Security.Policy;
using System.Windows.Forms;

namespace Advanced_Software_Engineering
{
    /// <summary>
    /// This class simply provides settings and some functions that are used across many components.
    /// </summary>
    public class SettingsAndHelperFunctions
    {
        /// <summary>
        /// The variable simply keep track of the windows that are currently shown (excluding <see cref="MainMenu"/>).
        /// </summary>
        public static int NumberOfWindows = 0;

        /// <summary>
        /// This helper function is executed when a window is closed. It shows the <see cref="MainMenu"/> when the count is 0
        /// </summary>
        public static void WindowClosed()
        {
            NumberOfWindows--;
            if (NumberOfWindows == 0)
            {
                System.Console.WriteLine("Showing MainMenu");
                Program.MainMenu.Show();
            }
                
        }

    }
}
