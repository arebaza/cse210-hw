using System;

class Program
{
    static void Main(string[] args)
    {
        // This program demonstrates inheritance using assignments
        // Base class Assignment and two derived classes

        Assignment tareaSimple = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(tareaSimple.GetSummary());
        Console.WriteLine();

        MathAssignment mathHomework = new MathAssignment(
            "Roberto Rodriguez",
            "Fractions",
            "7.3",
            "8-19"
        );

        Console.WriteLine(mathHomework.GetSummary());
        Console.WriteLine(mathHomework.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writingHomework = new WritingAssignment(
            "Mary Waters",
            "European History",
            "The Causes of World War II"
        );

        Console.WriteLine(writingHomework.GetSummary());
        Console.WriteLine(writingHomework.GetWritingInformation());
    }
}
