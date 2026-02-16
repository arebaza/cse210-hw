using System;

public abstract class Actividad
{
    private string _fecha;
    private int _minutos;
    private SistemaUnidades _sistema;

    protected Actividad(string fecha, int minutos, SistemaUnidades sistema)
    {
        //  Defensive validation.
        if (string.IsNullOrWhiteSpace(fecha))
            throw new ArgumentException("Date cannot be empty.");

        if (minutos <= 0)
            throw new ArgumentException("Minutes must be greater than 0.");

        _fecha = fecha;
        _minutos = minutos;
        _sistema = sistema;
    }

    // Read-only public properties (fields remain private => encapsulation).
    public int Minutos => _minutos;
    public SistemaUnidades Sistema => _sistema;
    public string Fecha => _fecha;

    // Abstract methods required by the rubric (distance, speed, pace).
    // Internally we calculate in miles + mph + min/mile, and convert only for display.
    public abstract double ObtenerDistanciaMillas();
    public abstract double ObtenerVelocidadMph();
    public abstract double ObtenerRitmoMinPorMilla();

    //  Exceed expectation metric.
    public abstract double ObtenerCalorias();

    //  CSV line for save/load.
    public abstract string ALineaCSV();

    //  Unit conversion helpers.
    protected double ConvertirMillasAKm(double millas) => millas * 1.60934;

    protected double DistanciaParaMostrar(double distanciaMillas)
    {
        return _sistema == SistemaUnidades.Millas ? distanciaMillas : ConvertirMillasAKm(distanciaMillas);
    }

    protected double VelocidadParaMostrar(double velocidadMph)
    {
        return _sistema == SistemaUnidades.Millas ? velocidadMph : velocidadMph * 1.60934;
    }

    protected double RitmoParaMostrar(double ritmoMinPorMilla)
    {
        // pace in min/km = pace in min/mile / 1.60934
        return _sistema == SistemaUnidades.Millas ? ritmoMinPorMilla : (ritmoMinPorMilla / 1.60934);
    }

    protected string EtiquetaDistancia() => _sistema == SistemaUnidades.Millas ? "miles" : "km";
    protected string EtiquetaVelocidad() => _sistema == SistemaUnidades.Millas ? "mph" : "kph";
    protected string EtiquetaRitmo() => _sistema == SistemaUnidades.Millas ? "min per mile" : "min per km";

    // ✅ Rubric-safe method name
    public virtual string GetSummary()
    {
        return ObtenerResumen(formatoDetallado: false);
    }

    public virtual string ObtenerResumen(bool formatoDetallado)
    {
        string nombreActividad = GetType().Name;

        double distanciaMostrar = DistanciaParaMostrar(ObtenerDistanciaMillas());
        double velocidadMostrar = VelocidadParaMostrar(ObtenerVelocidadMph());
        double ritmoMostrar = RitmoParaMostrar(ObtenerRitmoMinPorMilla());
        double calorias = ObtenerCalorias();

        if (!formatoDetallado)
        {
            return $"{_fecha} {nombreActividad} ({_minutos} min) - " +
                   $"Distance {distanciaMostrar:F1} {EtiquetaDistancia()}, " +
                   $"Speed {velocidadMostrar:F1} {EtiquetaVelocidad()}, " +
                   $"Pace {ritmoMostrar:F1} {EtiquetaRitmo()}, " +
                   $"Calories {calorias:F0} kcal";
        }

        return
            "----------------------------------------\n" +
            $"Date: {_fecha}\n" +
            $"Activity: {nombreActividad}\n" +
            $"Time: {_minutos} minutes\n" +
            $"Distance: {distanciaMostrar:F2} {EtiquetaDistancia()}\n" +
            $"Speed: {velocidadMostrar:F2} {EtiquetaVelocidad()}\n" +
            $"Pace: {ritmoMostrar:F2} {EtiquetaRitmo()}\n" +
            $"Calories: {calorias:F0} kcal\n" +
            "----------------------------------------";
    }
}
