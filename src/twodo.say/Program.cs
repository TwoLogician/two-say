using System;
using System.Collections.Generic;
using System.Linq;

namespace twodo.say
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<string> { "DATE", "GUID" };

            if (!args.Any())
            {
                Console.WriteLine("Usage: two [options]");
                return;
            }
            if (!args.Any(x => commands.Contains(x.ToUpper())))
            {
                Console.WriteLine("Unknow Option");
                return;
            }
            if (args.Any(x => x.ToUpper() == "DATE"))
            {
                Console.WriteLine(DateTime.Now);
            }
            if (args.Any(x => x.ToUpper() == "GUID"))
            {
                Console.WriteLine(Guid.NewGuid());
            }
        }
    }
}
