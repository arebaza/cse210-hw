using System;

public class Elliptical : Actividad
{
    private double _distanciaMillas;

    public Elliptical(string fecha, int minutos, double distanciaMillas, SistemaUnidades sistema)
        : base(fecha, minutos, sistema)
    {
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
        return Minutos * 7.5;
    }

    public override string ALineaCSV()
    {
        return $"Elliptical,{Fecha},{Minutos},{Sistema},{_distanciaMillas:F4}";
    }
}
