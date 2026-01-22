using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds requirements:
        // - Prevents infinite loops when hiding words
        // - Keeps punctuation visible while hiding letters
        // - Uses clean encapsulation and separation of responsibilities

        Reference reference = new Reference("Doctrine and Covenants", 82, 10);

        Scripture scripture = new Scripture(
            reference,
            "I, the Lord, am bound when ye do what I say; but when ye do not what I say, ye have no promise."
        );

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");

            string respuestaUsuario = Console.ReadLine();

            if (respuestaUsuario.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Program finished. All words are hidden.");
    }
}
