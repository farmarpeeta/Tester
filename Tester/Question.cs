using System;
using System.Runtime.InteropServices;

public class Question
{
    public string question { get; set; }
    public Question(string o)
	{
		question = o;
	}
	
}
public class CQuestion : Question
{
	public string correct{ get; set; }
    public string[] wrong{ get; set; }

    public CQuestion() : base("") { }

    public CQuestion(string o, string c, string[] wrong) : base (o)
	{
		correct = c;
		this.wrong = wrong;
	}

}
public class OQuestion : Question
{
    public OQuestion() : base("") { }
    public string correct { get; set; }
	public OQuestion(string o, string c) : base(o) 
	{
		correct = c;
	}
}
public class Multiple : Question
{
    public Multiple() : base("") { }
    public string[] correct { get; set; }
    public string[] wrong { get; set; }
	public Multiple(string o, string[] correct, string[] wrong) : base(o)
	{
		this.correct = correct;
		this.wrong = wrong;
	}
}
