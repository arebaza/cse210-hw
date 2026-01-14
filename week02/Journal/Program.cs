using System;

class Program
{
    static void Main(string[] args)
    {
        Journal miJournal = new Journal();
        PromptGenerator generador = new PromptGenerator();

        string opcion = "";

        // Main menu loop
        while (opcion != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            opcion = Console.ReadLine();

            if (opcion == "1")
            {
                // Write a new entry
                string prompt = generador.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string respuestaUsuario = Console.ReadLine();

                string fechaActual = DateTime.Now.ToShortDateString();

                Entry nuevaEntrada = new Entry(fechaActual, prompt, respuestaUsuario);
                miJournal.AddEntry(nuevaEntrada);
            }
            else if (opcion == "2")
            {
                // Display all entries
                miJournal.DisplayAll();
            }
            else if (opcion == "3")
            {
                // Save to a file
                Console.Write("What is the filename? ");
                string archivo = Console.ReadLine();
                miJournal.SaveToFile(archivo);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (opcion == "4")
            {
                // Load from a file
                Console.Write("What is the filename? ");
                string archivo = Console.ReadLine();
                miJournal.LoadFromFile(archivo);
                Console.WriteLine("Journal loaded successfully.");
            }
            else if (opcion == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose 1-5.");
            }
        }
    }
}
