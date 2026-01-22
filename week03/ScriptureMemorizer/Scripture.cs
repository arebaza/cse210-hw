using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] palabras = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (string palabra in palabras)
        {
            Word nuevaPalabra = new Word(palabra);
            _words.Add(nuevaPalabra);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Count how many words are still visible
        int visibles = 0;

        foreach (Word palabra in _words)
        {
            if (!palabra.IsHidden())
            {
                visibles++;
            }
        }

        int cantidadAocultar = Math.Min(numberToHide, visibles);
        int ocultadas = 0;

        while (ocultadas < cantidadAocultar)
        {
            int indice = _random.Next(_words.Count);

            if (!_words[indice].IsHidden())
            {
                _words[indice].Hide();
                ocultadas++;
            }
        }
    }

    public string GetDisplayText()
    {
        string textoFinal = "";

        foreach (Word palabra in _words)
        {
            textoFinal += palabra.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} - {textoFinal.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word palabra in _words)
        {
            if (!palabra.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
