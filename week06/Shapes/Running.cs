using System;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance, Units units)
        : base(date, minutes, units)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }
}
