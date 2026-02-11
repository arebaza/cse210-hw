using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed, Units units)
        : base(date, minutes, units)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        double hours = GetMinutes() / 60.0;
        return _speed * hours;
    }

    public override double GetSpeed()
    {
        return _speed;
    }
}
