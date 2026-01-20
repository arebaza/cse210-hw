using System;

class Program
{
    static void Main(string[] args)
    {
        // Create fractions using all three constructors (required)
        Fraction fraccion1 = new Fraction();        // 1/1
        Fraction fraccion2 = new Fraction(5);       // 5/1
        Fraction fraccion3 = new Fraction(3, 4);    // 3/4
        Fraction fraccion4 = new Fraction(1, 3);    // 1/3

        // Display sample outputs (English output)
        Console.WriteLine(fraccion1.GetFractionString());
        Console.WriteLine(fraccion1.GetDecimalValue());

        Console.WriteLine(fraccion2.GetFractionString());
        Console.WriteLine(fraccion2.GetDecimalValue());

        Console.WriteLine(fraccion3.GetFractionString());
        Console.WriteLine(fraccion3.GetDecimalValue());

        Console.WriteLine(fraccion4.GetFractionString());
        Console.WriteLine(fraccion4.GetDecimalValue());

        // Verify getters and setters (required)
        // Example: change 1/1 to 6/7 using setters
        Fraction fraccionCambio = new Fraction();
        fraccionCambio.SetTop(6);
        fraccionCambio.SetBottom(7);

        Console.WriteLine(fraccionCambio.GetFractionString());
        Console.WriteLine(fraccionCambio.GetDecimalValue());

        // Optional: demonstrate Spanish helper method (still prints in English format)
        // fraccion3.MostrarResumen();
    }
}
