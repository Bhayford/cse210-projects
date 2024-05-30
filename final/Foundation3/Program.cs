using System;
using System.Collections.Generic;

// Define the Address class
class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// Define the base Event class
abstract class Event
{
    protected string _title;
    protected string _description;
    protected DateTime _date;
    protected string _time;
    protected Address _address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public abstract string GetFullDetails();

    public string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public string GetShortDescription()
    {
        return $"Type: {this.GetType().Name}\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}

// Define the Lecture class
class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}

// Define the Reception class
class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
    }
}

// Define the OutdoorGathering class
class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {_weatherForecast}";
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        var address1 = new Address("123 Main St", "New York", "NY", "USA");
        var address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        var address3 = new Address("789 Oak St", "San Francisco", "CA", "USA");

        // Create events
        var lecture = new Lecture("Tech Innovations", "A talk on the latest in tech", new DateTime(2023, 6, 12), "10:00 AM", address1, "Dr. Smith", 150);
        var reception = new Reception("Networking Event", "Meet and greet with industry leaders", new DateTime(2023, 7, 20), "6:00 PM", address2, "rsvp@events.com");
        var outdoorGathering = new OutdoorGathering("Summer Festival", "A fun outdoor festival", new DateTime(2023, 8, 15), "12:00 PM", address3, "Sunny with a chance of showers");

        // Store events in a list
        var events = new List<Event> { lecture, reception, outdoorGathering };

        // Display event details
        foreach (var evt in events)
        {
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine(new string('-', 20));
        }
    }
}
