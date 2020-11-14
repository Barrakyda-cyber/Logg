using System;
using LoggingLibrary;
using static System.Console;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string text = $"{DateTime.Now}:{random.Next()}";
            WriteLine(text);

            Save save = new Save();
            save.message += (m) => WriteLine(m);
            save.Added(text);
        }

    }
}
