using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 3 test: Base class
        Assignment simple = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(simple.GetSummary());
        Console.WriteLine();

        // Step 4 test: MathAssignment
        MathAssignment math = new MathAssignment(
            "Roberto Rodriguez",
            "Fractions",
            "7.3",
            "8-19"
        );

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine();

        // Step 5 test: WritingAssignment
        WritingAssignment writing = new WritingAssignment(
            "Mary Waters",
            "European History",
            "The Causes of World War II"
        );

        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}
