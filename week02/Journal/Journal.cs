using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no journal entries to display.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Journal Entries:");
        Console.WriteLine();

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

        Console.WriteLine($"Total entries: {_entries.Count}");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetFileText());
                }
            }

            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception error)
        {
            Console.WriteLine("The journal could not be saved.");
            Console.WriteLine(error.Message);
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);

            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");

                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];

                    Entry entry = new Entry(date, prompt, response);

                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Journal loaded from {filename}.");
            Console.WriteLine($"{_entries.Count} entries were loaded.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file could not be found.");
        }
        catch (Exception error)
        {
            Console.WriteLine("The journal could not be loaded.");
            Console.WriteLine(error.Message);
        }
    }
}