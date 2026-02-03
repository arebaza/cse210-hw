using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    public GratitudeActivity()
        : base(
            "Gratitude",
            "This activity will help you feel more peace by writing short gratitude statements. It helps you focus on the good."
          )
    {
    }

    public override void Run()
    {
        Console.WriteLine();
        Console.WriteLine("Write as many gratitude statements as you can.");
        Console.WriteLine("Example: 'I am grateful for my family.'");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        List<string> statements = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                statements.Add(line);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You wrote {statements.Count} gratitude statements.");
    }
}
