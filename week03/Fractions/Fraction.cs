using System;

public class Fraction
{
    // Private attributes (encapsulation)
    private int _top;
    private int _bottom;

    // Constructor 1: no parameters -> 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: one parameter -> top/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor 3: two parameters -> top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Returns the fraction as a string like "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value like 0.75
    public double GetDecimalValue()
    {
        // Cast to double to avoid integer division
        return (double)_top / _bottom;
    }

    // Helper method (Spanish name) to show a quick summary (optional)
    // This keeps encapsulation because it uses public methods, not direct access.
    public void MostrarResumen()
    {
        Console.WriteLine(GetFractionString());
        Console.WriteLine(GetDecimalValue());
    }
}
