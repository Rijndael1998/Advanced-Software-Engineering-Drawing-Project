using System.Security.Policy;
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

        public static string StripSpaces(string text)
        {
            int start;

            for(start = 0; start < text.Length; start++)
            {
                char character = text[start];
                if (character != " "[0]) break;
            }

            int end;

            for(end = text.Length - 1; end >= 0; end--)
            {
                char character = text[end];
                if (character != " "[0]) break;
            }

            return text.Substring(start, end);

        }
    }
}
