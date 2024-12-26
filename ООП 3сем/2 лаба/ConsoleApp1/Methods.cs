using System;

public partial class Airline
{
    // статический метод для вывода информации о классе
    public static void PrintClassInfo()
    {
        Console.WriteLine($"Количество объектов, созданных в классе Airline = {objectCount}");
    }

    // метод с использованием ref и out параметров
    public void UpdateFlightDetails(ref string newDestination, out DateTime newTimeDeparture)
    {
        Destination = newDestination;
        newTimeDeparture = DateTime.Now.AddHours(3);
        DepartureTime = newTimeDeparture;
    }

    // переопределение методов из Object
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
