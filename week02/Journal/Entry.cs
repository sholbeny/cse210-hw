using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _category;
    private int _wordCount;

    public Entry(
        string date,
        string promptText,
        string entryText,
        string category)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _category = category;

        _wordCount = entryText
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Length;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Category: {_category}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine($"Word Count: {_wordCount}");
        Console.WriteLine();
    }

    public string GetFileText()
    {
        return $"{_date}~|~{_category}~|~{_promptText}~|~{_entryText}";
    }
}