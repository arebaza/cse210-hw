using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // This method displays the start message and asks the user for the duration
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        // This keeps input simple for the assignment
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // This method displays the end message shared by all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    // This method shows a spinner animation for a number of seconds
    protected void ShowSpinner(int segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    // This method shows a countdown animation
    protected void ShowCountDown(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Each activity must implement its own behavior
    public abstract void Run();
}
