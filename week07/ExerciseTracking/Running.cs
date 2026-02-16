using System;

public class Running : Actividad
{
    private double _distanciaMillas;

    public Running(string fecha, int minutos, double distanciaMillas, SistemaUnidades sistema)
        : base(fecha, minutos, sistema)
    {
        // Defensive validation.
        if (distanciaMillas <= 0)
            throw new ArgumentException("Distance must be greater than 0.");

        _distanciaMillas = distanciaMillas;
    }

    public override double ObtenerDistanciaMillas() => _distanciaMillas;

    public override double ObtenerVelocidadMph()
    {
        return (ObtenerDistanciaMillas() / Minutos) * 60.0;
    }

    public override double ObtenerRitmoMinPorMilla()
    {
        return Minutos / ObtenerDistanciaMillas();
    }

    public override double ObtenerCalorias()
    {
        // Simple estimate.
        return ObtenerDistanciaMillas() * 100.0;
    }

    public override string ALineaCSV()
    {
        return $"Running,{Fecha},{Minutos},{Sistema},{_distanciaMillas:F4}";
    }
}
