using System;


public partial class Airline
{

    public const string CompanyName = "Белавиа";

    public readonly int ID;

    private string destination;
    private int flightNumber;
    private string airplaneType;
    private double departureTime;
    private List<string> daysOfWeek;

    private static int objectCount;

    public string Destination
    {
        get
        {
            return destination;
        }
        set
        {
            destination = value;
        }
    }

    public int FlightNumber
    {
        get
        {
            return flightNumber;
        }
        set
        {
            flightNumber = value;
        }
    }

    public string AirplaneType
    {
        get
        {
            return airplaneType;
        }
        set
        {
            airplaneType = value;
        }
    }

    public double DepartureTime
    {
        get
        {
            return departureTime;
        }
        set
        {
            departureTime = value;
        }
    }

    public List<string> DaysOfWeek
    {
        get
        {
            return daysOfWeek;
        }
        set
        {
            daysOfWeek = value;
        }
    }

    static Airline()
    {
        objectCount = 0;
    }

    private Airline()
    {
        ID = GetHashCode();
        objectCount++;
    }


    public Airline(string destination, int flightNumber, string airplaneType, double time, List<string> daysOfWeek) : this()
    {
        Destination = destination;
        FlightNumber = flightNumber;
        AirplaneType = airplaneType;
        DepartureTime = time;
        DaysOfWeek = daysOfWeek;
    }

    public Airline(string destination, int flightNumber, string airplaneType, double time)
    : this(destination, flightNumber, airplaneType, time, new List<string> { "Вторник", "Четверг" })
    {

    }
}

public class Airport
{
    public string City { get; set; }
    public string AirportName { get; set; }

    public Airport(string city, string airportName)
    {
        City = city;
        AirportName = airportName;
    }
}

