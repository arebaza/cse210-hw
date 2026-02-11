using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // The program creates sample activities and prints summaries.
        // No user interaction is required by the assignment.

        Units units = Units.Miles; // Change to Units.Kilometers if needed

        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 03), 30, 3.0, units),
            new Cycling(new DateTime(2022, 11, 03), 30, 12.0, units),
            new Swimming(new DateTime(2022, 11, 03), 30, 40, units)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
