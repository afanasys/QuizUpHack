using System;
using System.Runtime.InteropServices;
using System.Security;

namespace QuizUpHack.Helpers
{
    public static class CommonHelpers
    {
        public static void TimerCallback(Object o)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.WriteLine(DateTime.Now.Second);
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
        public static void ClearCurrentConsoleLine()
        {
            Console.CursorLeft = 0;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.CursorTop--;
        }
        public static string GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }

            return SecureStringToString(pwd);//what a bad code
        }
        static String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }
        public static void DrawTextProgressBar(string stepDescription, int progress, int total)
        {
            const int totalChunks = 60;

            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = totalChunks + 1;
            Console.Write("]"); //end
            Console.CursorLeft = 1;

            var pctComplete = Convert.ToDouble(progress) / total;
            int numChunksComplete = Convert.ToInt16(totalChunks * pctComplete);

            //draw completed chunks
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("".PadRight(numChunksComplete));

            //draw incomplete chunks
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("".PadRight(totalChunks - numChunksComplete));

            //draw totals
            Console.CursorLeft = totalChunks + 5;
            Console.BackgroundColor = ConsoleColor.Black;

            string output = progress + " / " + total;
            Console.Write(output.PadRight(15) + stepDescription); //pad the output so when changing from 3 to 4 digits we avoid text shifting
           
        }
    }

   
}
