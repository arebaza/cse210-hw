using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public static class ArchivoActividades
{
    public static void GuardarCSV(string rutaArchivo, List<Actividad> listaActividades)
    {
        // Save activities to CSV.
        using StreamWriter escritor = new StreamWriter(rutaArchivo);
        escritor.WriteLine("Tipo,Fecha,Minutos,Sistema,ValorExtra");

        foreach (Actividad actividad in listaActividades)
        {
            escritor.WriteLine(actividad.ALineaCSV());
        }
    }

    public static List<Actividad> CargarCSV(string rutaArchivo)
    {
        // Load activities from CSV.
        if (!File.Exists(rutaArchivo))
            throw new FileNotFoundException("CSV file not found.", rutaArchivo);

        List<Actividad> lista = new List<Actividad>();
        string[] lineas = File.ReadAllLines(rutaArchivo);

        for (int i = 1; i < lineas.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lineas[i])) continue;

            string[] partes = lineas[i].Split(',');
            if (partes.Length < 5) continue;

            string tipo = partes[0].Trim();
            string fecha = partes[1].Trim();
            int minutos = int.Parse(partes[2].Trim(), CultureInfo.InvariantCulture);

            SistemaUnidades sistema = (SistemaUnidades)Enum.Parse(typeof(SistemaUnidades), partes[3].Trim());
            string valorExtraTexto = partes[4].Trim();

            Actividad actividad = CrearDesdeCSV(tipo, fecha, minutos, sistema, valorExtraTexto);
            lista.Add(actividad);
        }

        return lista;
    }

    private static Actividad CrearDesdeCSV(string tipo, string fecha, int minutos, SistemaUnidades sistema, string valorExtraTexto)
    {
        // Factory method creates the correct derived class.
        if (tipo.Equals("Running", StringComparison.OrdinalIgnoreCase))
        {
            double distancia = double.Parse(valorExtraTexto, CultureInfo.InvariantCulture);
            return new Running(fecha, minutos, distancia, sistema);
        }
        if (tipo.Equals("Cycling", StringComparison.OrdinalIgnoreCase))
        {
            double velocidad = double.Parse(valorExtraTexto, CultureInfo.InvariantCulture);
            return new Cycling(fecha, minutos, velocidad, sistema);
        }
        if (tipo.Equals("Swimming", StringComparison.OrdinalIgnoreCase))
        {
            int vueltas = int.Parse(valorExtraTexto, CultureInfo.InvariantCulture);
            return new Swimming(fecha, minutos, vueltas, sistema);
        }
        if (tipo.Equals("Hiking", StringComparison.OrdinalIgnoreCase))
        {
            double distancia = double.Parse(valorExtraTexto, CultureInfo.InvariantCulture);
            return new Hiking(fecha, minutos, distancia, sistema);
        }
        if (tipo.Equals("Rowing", StringComparison.OrdinalIgnoreCase))
        {
            double velocidad = double.Parse(valorExtraTexto, CultureInfo.InvariantCulture);
            return new Rowing(fecha, minutos, velocidad, sistema);
        }
        if (tipo.Equals("Elliptical", StringComparison.OrdinalIgnoreCase))
        {
            double distancia = double.Parse(valorExtraTexto, CultureInfo.InvariantCulture);
            return new Elliptical(fecha, minutos, distancia, sistema);
        }

        throw new ArgumentException($"Unknown activity type in CSV: {tipo}");
    }
}
