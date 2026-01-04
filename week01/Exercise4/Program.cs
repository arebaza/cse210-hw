using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int numero;

        do
        {
            Console.Write("Enter number: ");
            numero = int.Parse(Console.ReadLine());

            if (numero != 0)
            {
                numeros.Add(numero);
            }

        } while (numero != 0);

        // Core: sum
        int suma = 0;
        foreach (int n in numeros)
        {
            suma += n;
        }

        // Core: average
        double promedio = 0;
        if (numeros.Count > 0)
        {
            promedio = (double)suma / numeros.Count;
        }

        // Core: max (largest)
        int mayor = numeros[0];
        foreach (int n in numeros)
        {
            if (n > mayor)
            {
                mayor = n;
            }
        }

        Console.WriteLine($"The sum is: {suma}");
        Console.WriteLine($"The average is: {promedio}");
        Console.WriteLine($"The largest number is: {mayor}");

        // Stretch 1: smallest positive number
        int menorPositivo = int.MaxValue;
        bool tienePositivo = false;

        foreach (int n in numeros)
        {
            if (n > 0 && n < menorPositivo)
            {
                menorPositivo = n;
                tienePositivo = true;
            }
        }

        if (tienePositivo)
        {
            Console.WriteLine($"The smallest positive number is: {menorPositivo}");
        }

        // Stretch 2: sort and display
        numeros.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int n in numeros)
        {
            Console.WriteLine(n);
        }
    }
}
