using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        int numeroMagico = int.Parse(Console.ReadLine());

        int adivinanza = -1;

        while (adivinanza != numeroMagico)
        {
            Console.Write("What is your guess? ");
            adivinanza = int.Parse(Console.ReadLine());

            if (adivinanza < numeroMagico)
            {
                Console.WriteLine("Higher");
            }
            else if (adivinanza > numeroMagico)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
