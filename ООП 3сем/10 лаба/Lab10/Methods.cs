using System;

public partial class Airline
{
    public static void PrintClassInfo()
    {
        Console.WriteLine($"Количество объектов, созданных в классе Airline = {objectCount}");
    }

    public void UpdateFlightDetails(string newDestination, double newTimeDeparture)
    {
        Destination = newDestination;
        newTimeDeparture = newTimeDeparture + 2;
        DepartureTime = newTimeDeparture;
    }

    public override bool Equals(object obj)
    {
        if (obj is Airline other)
        {
            return this.FlightNumber == other.FlightNumber && this.Destination == other.Destination;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Destination, FlightNumber, AirplaneType);
    }

    public override string ToString()
    {
        return $"Полет {FlightNumber} в {Destination}, {AirplaneType}, Отправление: {DepartureTime}, Дни: {string.Join(", ", DaysOfWeek)}";
    }
}
