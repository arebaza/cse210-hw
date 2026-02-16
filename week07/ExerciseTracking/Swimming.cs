using System;

public class Swimming : Actividad
{
    private int _vueltas;

    public Swimming(string fecha, int minutos, int vueltas, SistemaUnidades sistema)
        : base(fecha, minutos, sistema)
    {
        //  Defensive validation.
        if (vueltas <= 0)
            throw new ArgumentException("Laps must be greater than 0.");

        _vueltas = vueltas;
    }

    public override double ObtenerDistanciaMillas()
    {
        //Distance (miles) = laps * 50 / 1000 * 0.62
        return (_vueltas * 50.0 / 1000.0) * 0.62;
    }

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
        // Simple estimate for lap swimming.
        return Minutos * 9.0;
    }

    public override string ALineaCSV()
    {
        return $"Swimming,{Fecha},{Minutos},{Sistema},{_vueltas}";
    }
}
