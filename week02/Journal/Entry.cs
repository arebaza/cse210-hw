using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    // Constructor makes it easy to create an entry correctly
    public Entry(string fecha, string prompt, string respuesta)
    {
        _date = fecha;
        _promptText = prompt;
        _entryText = respuesta;
    }

    // Displays one entry in a friendly format
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }

    // Converts an entry to a single-line format for file saving
    public string ToFileLine()
    {
        // Replace the separator just in case the user types it in their response
        string safePrompt = _promptText.Replace("|", "/");
        string safeText = _entryText.Replace("|", "/");

        return $"{_date}|{safePrompt}|{safeText}";
    }

    // Builds an Entry object from a saved file line
    public static Entry FromFileLine(string linea)
    {
        // Expected: date|prompt|response
        string[] parts = linea.Split("|");

        if (parts.Length != 3)
        {
            // If the line is not formatted correctly, ignore it
            return null;
        }

        string fecha = parts[0];
        string prompt = parts[1];
        string respuesta = parts[2];

        return new Entry(fecha, prompt, respuesta);
    }
}
