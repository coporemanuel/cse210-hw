using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _entryText;

    public Entry(string date, string prompt, string entryText)
    {
        _date = date;
        _prompt = prompt;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("------------------------------");
    }
}
