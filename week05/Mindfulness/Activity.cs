using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // This displays the common starting message for all activities.
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = PedirDuracion();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // This displays the common ending message for all activities.
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    // This method asks the user for duration and validates input.
    private int PedirDuracion()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a valid positive number.");
        }
    }

    // This shows a spinner animation for a given number of seconds.
    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }

        Console.Write(" \b");
    }

    // This shows a countdown animation.
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // This returns the activity name for logging.
    public string ObtenerNombreActividad()
    {
        return _name;
    }

    // This returns the duration for logging.
    public int ObtenerDuracion()
    {
        return _duration;
    }

    // This returns the duration so derived classes can use it safely.
    protected int GetDuration()
    {
        return _duration;
    }

    // Each derived activity must implement Run.
    public abstract void Run();
}
