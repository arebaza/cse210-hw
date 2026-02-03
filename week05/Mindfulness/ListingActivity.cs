using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly Random _random;
    private readonly List<string> _prompts;
    private Queue<string> _promptBag;

    private int _contador;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
          )
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _promptBag = CreateShuffleBag(_prompts);
    }

    public override void Run()
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetNextPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        List<string> responses = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entrada = Console.ReadLine();

            // This avoids counting blank lines.
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                responses.Add(entrada);
            }
        }

        _contador = responses.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_contador} items.");
    }

    // This returns prompts without repeating until all are used once.
    private string GetNextPrompt()
    {
        if (_promptBag.Count == 0)
        {
            _promptBag = CreateShuffleBag(_prompts);
        }
        return _promptBag.Dequeue();
    }

    private Queue<string> CreateShuffleBag(List<string> items)
    {
        List<string> copy = new List<string>(items);

        for (int i = copy.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            string temp = copy[i];
            copy[i] = copy[j];
            copy[j] = temp;
        }

        return new Queue<string>(copy);
    }
}
