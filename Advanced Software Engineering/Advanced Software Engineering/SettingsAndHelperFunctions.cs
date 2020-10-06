using System.Windows.Forms;

namespace Advanced_Software_Engineering
{
    public class SettingsAndHelperFunctions
    {
        public static int NumberOfWindows = 0;

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
