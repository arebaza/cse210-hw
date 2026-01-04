using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string nombreUsuario = PromptUserName();
        int numeroFavorito = PromptUserNumber();

        int numeroCuadrado = SquareNumber(numeroFavorito);

        DisplayResult(nombreUsuario, numeroCuadrado);
    }

    // Displays a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Prompts the user for their name and returns it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string nombre = Console.ReadLine();
        return nombre;
    }

    // Prompts the user for their favorite number and returns it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int numero = int.Parse(Console.ReadLine());
        return numero;
    }

    // Squares a number and returns the result
    static int SquareNumber(int numero)
    {
        int resultado = numero * numero;
        return resultado;
    }

    // Displays the final result
    static void DisplayResult(string nombre, int cuadrado)
    {
        Console.WriteLine($"{nombre}, the square of your number is {cuadrado}");
    }
}
