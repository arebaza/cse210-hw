using System;

public enum Units
{
    Miles,
    Kilometers
}

public abstract class Activity
{
    // Private fields to enforce encapsulation
    private DateTime fechaActividad;
    private int minutosDuracion;
    private Units _units;

    protected Activity(DateTime date, int minutes, Units units)
    {
        fechaActividad = date;
        minutosDuracion = minutes;
        _units = units;
    }

    // Protected getters to allow derived classes to use the data safely
    protected DateTime GetDate() => fechaActividad;
    protected int GetMinutes() => minutosDuracion;
    protected Units GetUnits() => _units;

    // Abstract and virtual methods enable polymorphism
    public abstract double GetDistance();

    public virtual double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / GetMinutes()) * 60.0;
    }

    public virtual double GetPace()
    {
        double distance = GetDistance();
        return GetMinutes() / distance;
    }

    // Shared summary method for all activities
    public virtual string GetSummary()
    {
        string unitLabel = (GetUnits() == Units.Miles) ? "miles" : "km";
        string speedLabel = (GetUnits() == Units.Miles) ? "mph" : "kph";

        return $"{GetDate():dd MMM yyyy} {GetType().Name} ({GetMinutes()} min) - " +
               $"Distance {FormatearNumero(GetDistance())} {unitLabel}, " +
               $"Speed {FormatearNumero(GetSpeed())} {speedLabel}, " +
               $"Pace: {FormatearNumero(GetPace())} min per {unitLabel}";
    }

    // Helper method to keep numeric formatting consistent
    protected string FormatearNumero(double value)
    {
        return value.ToString("0.00");
    }
}
