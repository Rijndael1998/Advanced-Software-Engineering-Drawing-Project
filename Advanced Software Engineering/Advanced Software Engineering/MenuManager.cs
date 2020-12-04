using System;

namespace Advanced_Software_Engineering {

    /// <summary>
    /// Menu manager manages if the menu is shown to the user. It is a static class because every Form should be able to see it.
    /// See <see cref="Menu"/>.
    /// </summary>
    public static partial class MenuManager {

        /// <summary>
        /// The variable simply keep track of the windows that are currently shown (excluding <see cref="Menu"/>).
        /// </summary>
        public static int NumberOfWindows = 0;

        /// <summary>
        /// This helper function is executed when a window is closed. It shows the <see cref="Menu"/> when the count is 0
        /// </summary>
        public static void WindowClosed() {
            NumberOfWindows--;
            if (NumberOfWindows == 0) {
                Console.WriteLine("Showing MainMenu");
                Program.MainMenu.Show();
            }
        }
    }
}