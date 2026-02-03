using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private readonly Random _random;
    private readonly List<string> _prompts;
    private readonly List<string> _questions;

    private Queue<string> _promptBag;
    private Queue<string> _questionBag;

    public ReflectingActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
          )
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _promptBag = CreateShuffleBag(_prompts);
        _questionBag = CreateShuffleBag(_questions);
    }

    public override void Run()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetNextPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(GetNextQuestion());
            ShowSpinner(4);
        }
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

    // This returns questions without repeating until all are used once.
    private string GetNextQuestion()
    {
        if (_questionBag.Count == 0)
        {
            _questionBag = CreateShuffleBag(_questions);
        }
        return _questionBag.Dequeue();
    }

    // This creates a shuffled queue from a list.
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
