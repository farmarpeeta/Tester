using System;
using System.Runtime.InteropServices;

// třída Question
public class Question
{
	// otázka string
	public string question { get; set; }
	public Question(string o)
	{
		question = o;
	}

}
// třída CQuestion, která dědí z Question
public class CQuestion : Question
{
    // správná odpověď string a pole s nesprávnými odpověďmi
    public string correct { get; set; }
	public string[] wrong { get; set; }

	public CQuestion() : base("") { }

	public CQuestion(string o, string c, string[] wrong) : base(o)
	{
		correct = c;
		this.wrong = wrong;
	}

}
// třída OQuestion, která dědí z Question
public class OQuestion : Question
{
    // správná odpověď string
    public OQuestion() : base("") { }
    public string correct { get; set; }
	public OQuestion(string o, string c) : base(o) 
	{
		correct = c;
	}
}
// třída Multiple, která dědí z Question
public class Multiple : Question
{
    // správné odpovědi pole stringů a nesprávné odpovědi pole stringů
    public Multiple() : base("") { }
    public string[] correct { get; set; }
    public string[] wrong { get; set; }
	public Multiple(string o, string[] correct, string[] wrong) : base(o)
	{
		this.correct = correct;
		this.wrong = wrong;
	}
}
