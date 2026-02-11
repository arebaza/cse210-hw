using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps, Units units)
        : base(date, minutes, units)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Each lap is 50 meters
        double km = (_laps * 50.0) / 1000.0;

        if (GetUnits() == Units.Miles)
        {
            return km * 0.62;
        }

        return km;
    }
}
