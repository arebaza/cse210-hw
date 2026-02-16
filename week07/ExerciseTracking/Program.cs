using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Choose unit system for the run.
        SistemaUnidades sistemaElegido = SistemaUnidades.Millas;

        // Create at least one of each required type.
        List<Actividad> listaActividades = new List<Actividad>
        {
            new Running("03 Nov 2022", 30, 3.0, sistemaElegido),
            new Cycling("03 Nov 2022", 45, 15.0, sistemaElegido),
            new Swimming("03 Nov 2022", 20, 40, sistemaElegido),

            //  Extra activities (exceed expectations).
            new Hiking("10 Nov 2022", 60, 4.5, sistemaElegido),
            new Rowing("12 Nov 2022", 25, 10.0, sistemaElegido),
            new Elliptical("15 Nov 2022", 35, 3.2, sistemaElegido)
        };

        // Base-class GetSummary is called for each item (polymorphism).
        Console.WriteLine("REQUIRED OUTPUT (GetSummary)");
        foreach (Actividad actividad in listaActividades)
        {
            Console.WriteLine(actividad.GetSummary());
        }

        // Detailed report (optional).
        Console.WriteLine("\nDETAILED REPORT");
        foreach (Actividad actividad in listaActividades)
        {
            Console.WriteLine(actividad.ObtenerResumen(formatoDetallado: true));
        }

        // Save + load CSV (optional exceed expectations).
        string rutaArchivo = "actividades.csv";
        ArchivoActividades.GuardarCSV(rutaArchivo, listaActividades);
        List<Actividad> listaCargada = ArchivoActividades.CargarCSV(rutaArchivo);

        Console.WriteLine("\nLOADED FROM CSV (GetSummary)");
        foreach (Actividad actividad in listaCargada)
        {
            Console.WriteLine(actividad.GetSummary());
        }

        MostrarEstadisticas(listaCargada);
        MostrarGraficoAscii(listaCargada);
    }

    private static void MostrarEstadisticas(List<Actividad> listaActividades)
    {
        // Totals and averages.
        int totalMinutos = listaActividades.Sum(a => a.Minutos);
        double totalDistanciaMillas = listaActividades.Sum(a => a.ObtenerDistanciaMillas());
        double totalCalorias = listaActividades.Sum(a => a.ObtenerCalorias());

        double totalHoras = totalMinutos / 60.0;
        double velocidadPromedioMph = totalHoras > 0 ? (totalDistanciaMillas / totalHoras) : 0;

        SistemaUnidades sistema = listaActividades.Count > 0 ? listaActividades[0].Sistema : SistemaUnidades.Millas;

        double totalDistanciaMostrar = sistema == SistemaUnidades.Millas ? totalDistanciaMillas : totalDistanciaMillas * 1.60934;
        double velocidadPromedioMostrar = sistema == SistemaUnidades.Millas ? velocidadPromedioMph : velocidadPromedioMph * 1.60934;

        string etiquetaDist = sistema == SistemaUnidades.Millas ? "miles" : "km";
        string etiquetaVel = sistema == SistemaUnidades.Millas ? "mph" : "kph";

        Console.WriteLine("\nTOTALS / STATS");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Total time: {totalMinutos} minutes");
        Console.WriteLine($"Total distance: {totalDistanciaMostrar:F2} {etiquetaDist}");
        Console.WriteLine($"Average speed: {velocidadPromedioMostrar:F2} {etiquetaVel}");
        Console.WriteLine($"Total calories: {totalCalorias:F0} kcal");
        Console.WriteLine("----------------------------------------");
    }

    private static void MostrarGraficoAscii(List<Actividad> listaActividades)
    {
        // ASCII bars based on minutes.
        Console.WriteLine("\nASCII CHART (based on minutes)");
        Console.WriteLine("----------------------------------------");

        int maxMinutos = listaActividades.Max(a => a.Minutos);
        int anchoMaximo = 30;

        foreach (Actividad actividad in listaActividades)
        {
            int minutos = actividad.Minutos;
            int longitudBarra = (int)Math.Round((minutos / (double)maxMinutos) * anchoMaximo);

            string nombre = actividad.GetType().Name.PadRight(12);
            string barra = new string('█', longitudBarra);

            Console.WriteLine($"{nombre} {barra} {minutos}m");
        }

        Console.WriteLine("----------------------------------------");
    }
}
