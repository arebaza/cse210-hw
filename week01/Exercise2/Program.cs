using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string entradaUsuario = Console.ReadLine();

        int porcentaje = int.Parse(entradaUsuario);

        // Letter grade
        string letra;

        if (porcentaje >= 90)
        {
            letra = "A";
        }
        else if (porcentaje >= 80)
        {
            letra = "B";
        }
        else if (porcentaje >= 70)
        {
            letra = "C";
        }
        else if (porcentaje >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        // Sign (+ or -)
        string signo = "";
        int ultimoDigito = porcentaje % 10;

        if (ultimoDigito >= 7)
        {
            signo = "+";
        }
        else if (ultimoDigito < 3)
        {
            signo = "-";
        }

        // No A+
        if (letra == "A" && signo == "+")
        {
            signo = "";
        }

        // No F+ or F-
        if (letra == "F")
        {
            signo = "";
        }

        Console.WriteLine($"Your letter grade is {letra}{signo}.");

        // Pass / Fail message
        if (porcentaje >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do better next time.");
        }
    }
}
