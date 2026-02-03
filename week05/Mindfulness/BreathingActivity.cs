using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        int tiempo = 0;

        while (tiempo < _duration)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            tiempo += 4;

            if (tiempo >= _duration) break;

            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountDown(6);
            tiempo += 6;
        }
    }
}
