using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing."
          )
    {
    }

    public override void Run()
    {
        int remaining = GetDuration();

        while (remaining > 0)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            int inhale = Math.Min(4, remaining);
            ShowCountDown(inhale);
            remaining -= inhale;

            if (remaining <= 0) break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            int exhale = Math.Min(6, remaining);
            ShowCountDown(exhale);
            remaining -= exhale;
        }
    }
}
