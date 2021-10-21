using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace twodo.say
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<string> { "a-z", "date", "ip", "guid" };

            if (!args.Any())
            {
                WriteYellow("Usage: two [options]");
                return;
            }
            if (!args.Any(x => commands.Contains(x)))
            {
                WriteRed("Unknow Option");
                return;
            }
            if (args.Any(x => x == "a-z"))
            {
                var random = new Random();
                var cha = (char)random.Next('A', 'Z');
                WriteGreen(cha);
            }
            if (args.Any(x => x == "date"))
            {
                WriteGreen(DateTime.Now);
            }
            if (args.Any(x => x == "ip"))
            {
                try
                {
                    var ip = Dns.GetHostEntry(Environment.MachineName).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
                    WriteGreen(ip);
                }
                catch (Exception ex)
                {
                    WriteRed(ex.Message);
                }
            }
            if (args.Any(x => x == "guid"))
            {
                WriteGreen(Guid.NewGuid());
            }
        }

        static void SetGray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void WriteGreen(object value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            SetGray();
        }

        static void WriteRed(object value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            SetGray();
        }

        static void WriteYellow(object value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value);
            SetGray();
        }
    }
}
