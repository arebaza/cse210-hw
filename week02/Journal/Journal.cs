using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Adds a new entry using the Journal abstraction (do not expose the list)
    public void AddEntry(Entry nuevaEntrada)
    {
        _entries.Add(nuevaEntrada);
    }

    // Displays all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        foreach (Entry entrada in _entries)
        {
            entrada.Display();
            Console.WriteLine();
        }
    }

    // Saves all entries to a file
    public void SaveToFile(string nombreArchivo)
    {
        using (StreamWriter writer = new StreamWriter(nombreArchivo))
        {
            // Each entry is stored on one line with separators:
            // date|prompt|response
            foreach (Entry entrada in _entries)
            {
                writer.WriteLine(entrada.ToFileLine());
            }
        }
    }

    // Loads entries from a file (replaces current journal content)
    public void LoadFromFile(string nombreArchivo)
    {
        List<Entry> entradasCargadas = new List<Entry>();

        if (!File.Exists(nombreArchivo))
        {
            Console.WriteLine("File not found. No entries loaded.");
            return;
        }

        string[] lineas = File.ReadAllLines(nombreArchivo);

        foreach (string linea in lineas)
        {
            // Defensive: skip empty lines
            if (string.IsNullOrWhiteSpace(linea))
            {
                continue;
            }

            Entry entrada = Entry.FromFileLine(linea);
            if (entrada != null)
            {
                entradasCargadas.Add(entrada);
            }
        }

        _entries = entradasCargadas;
    }
}
