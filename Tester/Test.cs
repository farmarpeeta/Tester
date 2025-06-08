using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Test
{
    public Test()
    {
        string directoryPath = Directory.GetCurrentDirectory() + "\\Questions";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        while (true)
        {
            string[] directories = Directory.GetDirectories(directoryPath);
            int directoryCount = directories.Length;
            Console.Clear();
            Console.WriteLine("TESTOVÁNÍ OTÁZEK");
            Console.WriteLine("Zvolte okruh:");
            Console.WriteLine("1) zpět do menu");
            for (int i = 0; i < directoryCount; i++)
            {
                Console.WriteLine($"{i + 2}) {Path.GetFileNameWithoutExtension(directories[i])}");
            }
            Console.WriteLine("Vaše volba:");
            string inputLine = Console.ReadLine();
            if (!int.TryParse(inputLine, out int input))
            {
                Console.WriteLine("Zadej platné číslo.");
                Console.WriteLine();
                Thread.Sleep(1000);
                continue; // Zpět na začátek cyklu
            }
            if (input == 1)
                break;
            else if (input > 1 && input <= directoryCount + 1)
            {
                string category = Path.GetFileNameWithoutExtension(directories[input - 2]);
                string load = File.ReadAllText(directoryPath + "\\" + category + "\\cquestions.json");
                List<CQuestion> cQuestions = JsonSerializer.Deserialize<List<CQuestion>>(load);
                List<Question> questions  = new List<Question> { };
                for (int i = 0; i < cQuestions.Count; i++)
                {
                    Question q = cQuestions[i];
                    questions.Add(q);
                }
                load = File.ReadAllText(directoryPath + "\\" + category + "\\mquestions.json");
                List<Multiple> mQuestions = JsonSerializer.Deserialize<List<Multiple>>(load);
                for (int i = 0; i < mQuestions.Count; i++)
                {
                    Question q = mQuestions[i];
                    questions.Add(q);
                }
                load = File.ReadAllText(directoryPath + "\\" + category + "\\oquestions.json");
                List<OQuestion> oQuestions = JsonSerializer.Deserialize<List<OQuestion>>(load);
                for (int i = 0; i < oQuestions.Count; i++)
                {
                    Question q = oQuestions[i];
                    questions.Add(q);
                }
                Random rng = new Random();
                int countCorrect = 0; // Počet správných odpovědí

                foreach (Question q in questions)
                {
                    if (q is CQuestion cQ)
                    {
                        Console.Clear();
                        Console.WriteLine("Otázka: " + cQ.question);
                        List<string> options = new List<string>(cQ.wrong);
                        options.Add(cQ.correct); // Přidáme správnou odpověď

                        // Zamíchej možnosti
                        options = options.OrderBy(item => rng.Next()).ToList();

                        Console.WriteLine("Možnosti:");
                        for (int i = 0; i < options.Count; i++)
                        {
                            Console.WriteLine($"{options[i]}");
                        }
                        Console.Write("Tvá odpověď (zadej číslo): ");
                        string input1 = Console.ReadLine();
                        if (input1 == cQ.correct)
                        {
                            Console.WriteLine("Správně!");
                            countCorrect++;
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine("Špatně! Správná odpověď je: " + cQ.correct);
                            Thread.Sleep(2000);
                        }
                    }
                    else if (q is OQuestion oQ)
                    {
                        Console.Clear();
                        Console.WriteLine("Otázka: " + oQ.question);
                        Console.WriteLine("Vaše odpověď:");
                        string answer = oQ.correct;
                        string input2 = Console.ReadLine();
                        if (input2.ToLower() == answer.ToLower())
                        {
                            Console.WriteLine("Správně!");
                            countCorrect++;
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine("Špatně! Správná odpověď je: " + answer);
                            Thread.Sleep(2000);
                        }
                    }
                    else if (q is Multiple mQ)
                    {
                        Console.Clear();
                        List<string> options = new List<string>(mQ.correct);
                        foreach(string wrong in mQ.wrong)
                        {
                            options.Add(wrong); // Přidáme špatné odpovědi
                        }
                        options = options.OrderBy(item => rng.Next()).ToList();
                        Console.WriteLine("Otázka: " + mQ.question);
                        Console.WriteLine("Možnosti:");
                        for (int i = 0; i < options.Count; i++)
                        {
                            Console.WriteLine($"{options[i]}");
                        }
                        Console.Write("Tvá odpověď (zadej číslo): ");
                        string input1 = Console.ReadLine();
                        if(mQ.correct.Contains(input1))
                        {
                            Console.WriteLine("Správně!");
                            Console.WriteLine("Správné odpovědi jsou: " + string.Join(", ", mQ.correct));
                            countCorrect++;
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine("Špatně! Správné odpovědi jsou: " + string.Join(", ", mQ.correct));
                            Thread.Sleep(2000);
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Test dokončen!");
                Console.WriteLine($"Počet správných odpovědí: {countCorrect} z {questions.Count}");
                Console.WriteLine("Stiskni libovolnou klávesu pro pokračování...");
                Console.ReadKey();
            }
        }

    }
}

