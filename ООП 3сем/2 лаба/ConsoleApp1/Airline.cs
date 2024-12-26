using System;

public partial class Airline
{
    // поле константа
    public const string CompanyName = "Белавиа";

    // только для чтения
    public readonly int ID;

    private string destination;
    private int flightNumber;
    private string airplaneType;
    private DateTime departureTime;
    private List<string> daysOfWeek;

    // статическое поле для подсчета количества объектов
    private static int objectCount;

    // свойства get и set
    public string Destination
    {
        get {
            return destination;
        }
        set {
            destination = value;
        }
    }

    public int FlightNumber
    {
        get {
            return flightNumber;
        }
        private set {
            flightNumber = value;
        }
    }

    public string AirplaneType
    {
        get {
            return airplaneType;
        }
        set {
            airplaneType = value;
        }
    }

    public DateTime DepartureTime
    {
        get {
            return departureTime;
        }
        set {
            departureTime = value;
        }
    }

    public List<string> DaysOfWeek
    {
        get {
            return daysOfWeek; }
        set { daysOfWeek = value;
        }
    }

    // статический конструктор
    static Airline()
    {
        objectCount = 0;
    }

    // закрытый конструктор
    private Airline()
    {
        ID = GetHashCode();
        Console.WriteLine("genbfg");
        objectCount++;
    }

    // конструктор с параметрами
    public Airline(string destination, int flightNumber, string airplaneType, DateTime departureTime, List<string> daysOfWeek) : this()
    {
        Destination = destination;
        FlightNumber = flightNumber;
        AirplaneType = airplaneType;
        DepartureTime = departureTime;
        DaysOfWeek = daysOfWeek;
    }

    // конструктор с частичными параметрами
    public Airline(string destination, int flightNumber, string airplaneType)
    : this(destination, flightNumber, airplaneType, DateTime.Now.AddDays(1), new List<string> { "Вторник", "Четверг" })
    {

    }
}
