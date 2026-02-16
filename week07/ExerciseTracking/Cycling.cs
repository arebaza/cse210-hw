using System;

public class Cycling : Actividad
{
    private double _velocidadMph;

    public Cycling(string fecha, int minutos, double velocidadMph, SistemaUnidades sistema)
        : base(fecha, minutos, sistema)
    {
        // Defensive validation.
        if (velocidadMph <= 0)
            throw new ArgumentException("Speed must be greater than 0.");

        _velocidadMph = velocidadMph;
    }

    public override double ObtenerVelocidadMph() => _velocidadMph;

    public override double ObtenerDistanciaMillas()
    {
        return ObtenerVelocidadMph() * (Minutos / 60.0);
    }

    public override double ObtenerRitmoMinPorMilla()
    {
        return 60.0 / ObtenerVelocidadMph();
    }

    public override double ObtenerCalorias()
    {
        // Simple estimate based on speed.
        double kcalPorMinuto = _velocidadMph < 12 ? 6 : (_velocidadMph < 16 ? 8 : 10);
        return Minutos * kcalPorMinuto;
    }

    public override string ALineaCSV()
    {
        return $"Cycling,{Fecha},{Minutos},{Sistema},{_velocidadMph:F4}";
    }
}
