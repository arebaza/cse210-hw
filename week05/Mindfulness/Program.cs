using System;

class Program
{
    // Creativity note:
    // 1) Prompts and questions do not repeat until all have been used once in that session.
    // 2) The program saves an activity log to "activity_log.txt" with counts and total time.
    // 3) I added a 4th activity (GratitudeActivity) to exceed requirements.

    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("activity_log.txt");
        log.Load();

        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity (Creative)");
            Console.WriteLine("5. View Activity Stats (Creative)");
            Console.WriteLine("6. Quit");
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
                    actividad = new GratitudeActivity();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Activity Stats");
                    Console.WriteLine("--------------");
                    Console.WriteLine(log.GetReport());
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case "6":
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

                log.Record(actividad.ObtenerNombreActividad(), actividad.ObtenerDuracion());
                log.Save();

                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
