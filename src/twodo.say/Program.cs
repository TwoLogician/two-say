using System;
using System.Collections.Generic;
using System.Linq;

namespace twodo.say
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<string> { "A-Z", "DATE", "GUID" };

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!args.Any())
            {
                Console.WriteLine("Usage: two [options]");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            if (!args.Any(x => commands.Contains(x.ToUpper())))
            {
                Console.WriteLine("Unknow Option");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            if (args.Any(x => x.ToUpper() == "A-Z"))
            {
                var random = new Random();
                var cha = (char)random.Next('A', 'Z');
                Console.WriteLine(cha);
            }
            if (args.Any(x => x.ToUpper() == "DATE"))
            {
                Console.WriteLine(DateTime.Now);
            }
            if (args.Any(x => x.ToUpper() == "GUID"))
            {
                Console.WriteLine(Guid.NewGuid());
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
