using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace twodo.say
{
    class Program
    {
        private static ConsoleColor _foregroundColor = Console.ForegroundColor;

        static void Main(string[] args)
        {
            var commands = new List<string> { "a-z", "date", "guid", "ip" };
            var foregroundColor = Console.ForegroundColor;
            _foregroundColor = foregroundColor;

            if (!args.Any())
            {
                Console.Write("Usage: ");
                WriteYellow("two [options]");
                Console.WriteLine();
                Console.WriteLine("Options:");
                commands.ForEach(x =>
                {
                    WriteYellow($"  {x}");
                });
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
            if (args.Any(x => x == "guid"))
            {
                WriteGreen(Guid.NewGuid());
            }
            if (args.Any(x => x == "ip"))
            {
                try
                {
                    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {
                        socket.Connect("8.8.8.8", 65530);
                        var endPoint = socket.LocalEndPoint as IPEndPoint;
                        var ip = endPoint.Address.ToString();
                        WriteGreen(ip);
                    }
                }
                catch (Exception ex)
                {
                    WriteRed(ex.Message);
                }
            }
        }

        static void SetDefaultForegroundColor()
        {
            Console.ForegroundColor = _foregroundColor;
        }

        static void WriteGreen(object value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            SetDefaultForegroundColor();
        }

        static void WriteRed(object value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            SetDefaultForegroundColor();
        }

        static void WriteYellow(object value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value);
            SetDefaultForegroundColor();
        }
    }
}
