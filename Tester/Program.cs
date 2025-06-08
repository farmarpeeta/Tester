using System.Text.Json;

namespace Tester
{
    internal class Program
    {
        // Logo pro konzoli
        static String logo = "\r\n_________ _______  _______ _________ _______  _______ \r\n\\__   __/(  ____ \\(  ____ \\\\__   __/(  ____ \\(  ____ )\r\n   ) (   | (    \\/| (    \\/   ) (   | (    \\/| (    )|\r\n   | |   | (__    | (_____    | |   | (__    | (____)|\r\n   | |   |  __)   (_____  )   | |   |  __)   |     __)\r\n   | |   | (            ) |   | |   | (      | (\\ (   \r\n   | |   | (____/\\/\\____) |   | |   | (____/\\| ) \\ \\__\r\n   )_(   (_______/\\_______)   )_(   (_______/|/   \\__/\r\n                                                      \r\n";

        static void Main(string[] args)
        {
            while (true)
            {
                // vyčištění plochy, zobrazení loga a nabídky
                Console.Clear();
                Console.Write(logo);
                Console.WriteLine("1) Testovat");
                Console.WriteLine("2) Přidat otázku");
                Console.WriteLine("3) Konec");
                Console.Write("Vaše volba:");

                string inputLine = Console.ReadLine();

                // ověření , že vstup je platné číslo (1-3)
                if (!int.TryParse(inputLine, out int input))
                {
                    Console.WriteLine("Zadej platné číslo.");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    continue; // Zpět na začátek cyklu
                }
                // zpracování vstupu
                switch (input)
                {
                    // 1) Testování otázek
                    case 1:
                        Test test = new Test();
                        break;
                    // 2) Přidání otázky
                    case 2:
                        Add add = new Add();
                        break;
                    // 3) Konec programu
                    case 3:
                        Environment.Exit(0);
                        break;
                    // Neplatný vstup
                    default:
                        Console.WriteLine("Neplatné číslo.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
