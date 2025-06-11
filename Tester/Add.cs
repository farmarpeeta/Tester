using System;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;

public class Add
{
	public Add()
	{
		question();
	}
	private void question() {
        // Vytvoření adresáře pro otázky, pokud neexistuje
        string directoryPath = Directory.GetCurrentDirectory() + "\\Questions";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        while (true) {
            // Získání seznamu adresářů v cestě
            string[] directories = Directory.GetDirectories(directoryPath);
            int directoryCount = directories.Length;

            // Vyčištění konzole a zobrazení základní nabídky pro přidání otázky
            Console.Clear();
            Console.WriteLine("PŘIDÁVÁNÍ OTÁZKY");
            Console.WriteLine("Zvolte okruh:");
            Console.WriteLine("1) zpět do menu");
            Console.WriteLine("2) nový okruh");

            // Výpis dostupných okruhů
            for (int i = 0; i < directoryCount; i++)
            {
                Console.WriteLine($"{i + 3}) {Path.GetFileNameWithoutExtension(directories[i])}");
            }

            // Čtení uživatelského vstupu
            Console.WriteLine("Vaše volba:");
            string inputLine = Console.ReadLine();

            // Ověření, že vstup je platné číslo
            if (!int.TryParse(inputLine, out int input))
            {
                Console.WriteLine("Zadej platné číslo.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            // Zpracování vstupu
            if (input == 1)
            {
                break;
            }else if(input == 2)
            {
                Console.Clear();
                // Vytvoření nového okruhu
                Console.WriteLine("Zadejte název nového okruhu:");
                string category = Console.ReadLine();
                Directory.CreateDirectory(directoryPath + "\\" + category);

                // Vytvoření souborů pro různé typy otázek
                List<CQuestion> cQuestions = new List<CQuestion> { };
                string json = JsonSerializer.Serialize(cQuestions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(directoryPath + "\\" + category + "\\cquestions.json", json);

                List<OQuestion> oQuestions = new List<OQuestion> { };
                json = JsonSerializer.Serialize(oQuestions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(directoryPath + "\\" + category + "\\oquestions.json", json);

                List<Multiple> mQuestions = new List<Multiple> { };
                json = JsonSerializer.Serialize(mQuestions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(directoryPath + "\\" + category + "\\mquestions.json", json);


            }
            else if (input > 2 && input<= directoryCount + 2)
            {
                bool falg = true;
                while (falg)
                {
                    Console.Clear();
                    // Získání názvu kategorie z vybraného adresáře
                    string category = Path.GetFileNameWithoutExtension(directories[(input) - 3]);

                    // Vyčištění konzole a zobrazení nabídky pro výběr typu otázky
                    Console.WriteLine("Vyber typ otázky:");
                    Console.WriteLine("1) Uzavřená otázka");
                    Console.WriteLine("2) Otevřená otázka");
                    Console.WriteLine("3) Multiplechoice otázka");
                    Console.WriteLine("Vaše volba:");
                    string inputLine2 = Console.ReadLine();

                    // Ověření, že vstup je platné číslo
                    if (!int.TryParse(inputLine2, out int input2))
                    {
                        Console.WriteLine("Zadej platné číslo.");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        continue; // Zpět na začátek cyklu
                    }

                    // Zpracování vstupu pro typ otázky
                    switch (input2)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Zadejte otázku:");
                            string question = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Zadejte správnou odpověď:");
                            string correct = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Zadejte špatnou odpověď:");
                            string wrong1 = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Zadejte špatnou odpověď:");
                            string wrong2 = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Zadejte špatnou odpověď:");
                            string wrong3 = Console.ReadLine();
                            CQuestion closedQuestion = new CQuestion(question, correct, [wrong1, wrong2, wrong3]);

                            string nacteny = File.ReadAllText(directoryPath + "\\" + category + "\\cquestions.json");
                            List<CQuestion> cQuestions = JsonSerializer.Deserialize<List<CQuestion>>(nacteny);
                            cQuestions.Add(closedQuestion);
                            string json = JsonSerializer.Serialize(cQuestions, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(directoryPath + "\\" + category + "\\cquestions.json", json);
                            falg = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Zadejte otázku:");
                            question = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Zadejte správnou odpověď:");
                            string answear = Console.ReadLine();
                            OQuestion openedQuestion = new OQuestion(question, answear);

                            nacteny = File.ReadAllText(directoryPath + "\\" + category + "\\oquestions.json");
                            List<OQuestion> oQuestions = JsonSerializer.Deserialize<List<OQuestion>>(nacteny);
                            oQuestions.Add(openedQuestion);
                            json = JsonSerializer.Serialize(oQuestions, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(directoryPath + "\\" + category + "\\oquestions.json", json);
                            falg = false;
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Zadejte otázku:");
                            question = Console.ReadLine();
                            List<string> corrects = new List<string> { };
                            List<string> wrongs = new List<string> { };
                            for (int i = 0; i < 4; i++) {
                                while (true) 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Zadejte odpověď (správnou nebo špatnou):");
                                    answear = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Je to (1)správná nebo (2)špatná odpově");
                                    string inputLine3 = Console.ReadLine();

                                    if (!int.TryParse(inputLine3, out int input3))
                                    {
                                        Console.WriteLine("Zadej platné číslo.");
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        continue;
                                    }
                                    if (input3 == 1)
                                    {
                                        corrects.Add(answear);
                                        break;
                                    }
                                    else if (input3 == 2)
                                    {
                                        wrongs.Add(answear);
                                        break;
                                    }
                                    else;
                                }
                            }
                            // Kontrola, že jsou zadány alespoň dvě správné odpovědi(volitelné)
                            Console.Clear();
                            Console.WriteLine("Počet správných odpovědí je:" + corrects.Count);
                            Thread.Sleep(2000);
                            Multiple multipleQuestion = new Multiple(question, corrects.ToArray(), wrongs.ToArray());
                            nacteny = File.ReadAllText(directoryPath + "\\" + category + "\\mquestions.json");
                            List<Multiple> mQuestions = JsonSerializer.Deserialize<List<Multiple>>(nacteny);
                            mQuestions.Add(multipleQuestion);
                            json = JsonSerializer.Serialize(mQuestions, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(directoryPath + "\\" + category + "\\mquestions.json", json);

                            falg = false;
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
}
