using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I could do one thing over today, what would it be?",
        "What is something I learned today?",
        "What is one thing I am grateful for today?"
    };

    private Random _random = new Random();

    // Returns a random prompt from the list
    public string GetRandomPrompt()
    {
        int indice = _random.Next(0, _prompts.Count);
        return _prompts[indice];
    }
}
