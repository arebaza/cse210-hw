using System;

// Creativity note:
// I reused a single timing approach and clean animations in the base class,
// and I improved randomness by reusing one Random object per activity.

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string opcion = Console.ReadLine();

            Activity actividad = null;

            switch (opcion)
            {
                case "1":
                    actividad = new BreathingActivity();
                    break;
                case "2":
                    actividad = new ReflectingActivity();
                    break;
                case "3":
                    actividad = new ListingActivity();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }

            if (actividad != null)
            {
                actividad.DisplayStartingMessage();
                actividad.Run();
                actividad.DisplayEndingMessage();

                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
