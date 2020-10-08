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

        /// <summary>
        /// This function removes spaces from the start and the end of the text. This should be unit tested.
        /// </summary>
        /// <param name="text">Simply any string of any size</param>
        /// <returns>A string without spaces at the begining or the end</returns>
        /// <example>
        /// For example
        /// <code>
        /// string a = "     a simple sentence surrounded by spaces                ";
        /// string b = StripSpaces(a);
        /// Console.WriteLine(b); // => "a simple sentence surrounded by spaces";
        /// </code>
        /// </example>
        /// <example>
        /// The code won't remove internal double spaces:
        /// <code>
        /// string a = "     a    simple    sentence     surrounded    by    spaces                ";
        /// string b = StripSpaces(a);
        /// Console.WriteLine(b); // => "a    simple    sentence     surrounded    by    spaces";
        /// </code>
        /// </example>
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
