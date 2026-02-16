using System;

public class Rowing : Actividad
{
    private double _velocidadMph;

    public Rowing(string fecha, int minutos, double velocidadMph, SistemaUnidades sistema)
        : base(fecha, minutos, sistema)
    {
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
        return Minutos * 8.0;
    }

    public override string ALineaCSV()
    {
        return $"Rowing,{Fecha},{Minutos},{Sistema},{_velocidadMph:F4}";
    }
}
