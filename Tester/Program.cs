using System.Text.Json;

namespace Tester
{
    internal class Program
    {
        static String logo = "\r\n_________ _______  _______ _________ _______  _______ \r\n\\__   __/(  ____ \\(  ____ \\\\__   __/(  ____ \\(  ____ )\r\n   ) (   | (    \\/| (    \\/   ) (   | (    \\/| (    )|\r\n   | |   | (__    | (_____    | |   | (__    | (____)|\r\n   | |   |  __)   (_____  )   | |   |  __)   |     __)\r\n   | |   | (            ) |   | |   | (      | (\\ (   \r\n   | |   | (____/\\/\\____) |   | |   | (____/\\| ) \\ \\__\r\n   )_(   (_______/\\_______)   )_(   (_______/|/   \\__/\r\n                                                      \r\n";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(logo);
                Console.WriteLine("1) Testovat");
                Console.WriteLine("2) Přidat otázku");
                Console.WriteLine("3) Konec");
                Console.Write("Vaše volba:");

                string inputLine = Console.ReadLine();

                if (!int.TryParse(inputLine, out int input))
                {
                    Console.WriteLine("Zadej platné číslo.");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    continue; // Zpět na začátek cyklu
                }

                switch (input)
                {
                    case 1:
                        Test test = new Test();
                        break;
                    case 2:
                        Add add = new Add();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neplatné číslo.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
