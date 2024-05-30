using System;
using System.Collections.Generic;

// Define the base Activity class
abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date.ToShortDateString()} {this.GetType().Name} ({_minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Define the Running class
class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / _minutes) * 60;
    }

    public override double GetPace()
    {
        return _minutes / _distance;
    }
}

// Define the Cycling class
class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * _minutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// Define the Swimming class
class Swimming : Activity
{
    private int _laps;
    private const double LapLengthInMeters = 50;
    private const double MetersToMilesConversion = 0.000621371;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * LapLengthInMeters) * MetersToMilesConversion;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _minutes) * 60;
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create activities
        var running = new Running(new DateTime(2023, 11, 3), 30, 3.0);
        var cycling = new Cycling(new DateTime(2023, 11, 4), 45, 15.0);
        var swimming = new Swimming(new DateTime(2023, 11, 5), 40, 20);

        // Store activities in a list
        var activities = new List<Activity> { running, cycling, swimming };

        // Display activity summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
