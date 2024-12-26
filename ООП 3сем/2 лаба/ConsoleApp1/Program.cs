using System;


public class Program
{
    public static void Main(string[] args)
    {
        Airline flight1 = new Airline("Грушевка", 1001, "Boeing", DateTime.Now.AddHours(2), new List<string> { "Понедельник", "Среда", "Четверг" });
        Airline flight2 = new Airline("Солигорс", 1002, "AmericanExpress");
        Airline flight3 = new Airline("Полоцк", 1003, "Airbus", DateTime.Now.AddHours(5), new List<string> { "Вторник", "Четверг" });

        Console.WriteLine(flight1);
        Console.WriteLine(flight2);
        Console.WriteLine(flight3);

        // сравнение объектов
        Console.WriteLine(flight1.Equals(flight2)); // false

        // статический метод
        Airline.PrintClassInfo();

        // ипользование ref и out параметров
        string newDestination = "Витебск";
        flight1.UpdateFlightDetails(ref newDestination, out DateTime newTime);
        Console.WriteLine($"Обновленный полет: {flight1}");

        // массив объектов класса Airline
        Airline[] flights = { flight1, flight2, flight3 };

        // список рейсов для определенного пункта назначения
        string destinationSearch = "Жабинка";
        foreach (var flight in flights)
        {
            if (flight.Destination == destinationSearch)
            {
                Console.WriteLine($"Полет в {destinationSearch}: {flight}");
            }
        }

        // список рейсов для определенного дня недели
        string daySearch = "Понедельник";
        foreach (var flight in flights)
        {
            if (flight.DaysOfWeek.Contains(daySearch))
            {
                Console.WriteLine($"Полет в {daySearch}: {flight}");
            }
        }

        // анонимный тип
        var anonymousFlight = new { Destination = "Жлобин", FlightNumber = 104, AirplaneType = "Кукурузник" };

        Console.WriteLine($"Полет анонимного типа:\nПункт назначения: {anonymousFlight.Destination}\n" +
                          $"Номер рейса: {anonymousFlight.FlightNumber}\n" +
                          $"Тип самолета: {anonymousFlight.AirplaneType}");
    }
}
