using System;


public class Program
{
    static void Main(string[] args)
    {
        string[] months = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        // 1
        int n = 4;
        var selectedMonths = from m in months
                             where m.Length == n
                             select m;
        foreach (var m in selectedMonths)
        {
            Console.WriteLine(m);
        }
        Console.WriteLine("--------------------------------");
        string[] SummerAndWinterMonths = new string[] { "Январь", "Февраль", "Декабрь", "Июнь", "Июль", "Август" };
        var selectedWinterAndSummerMonths = from m in months
                                            where SummerAndWinterMonths.Contains(m)
                                            select m;

        foreach (var m in selectedWinterAndSummerMonths)
        {
            Console.WriteLine(m);
        }
        Console.WriteLine("--------------------------------");
        var monthsAlphabet = from m in months
                             orderby m
                             select m;
        foreach (var m in monthsAlphabet)
        {
            Console.WriteLine(m);
        }
        Console.WriteLine("--------------------------------");
        var someMonths = from m in months
                         where m.Contains("И") && m.Length >= 4
                         select m;
        foreach (var m in someMonths)
        {
            Console.WriteLine(m);
        }
        Console.WriteLine("--------------------------------");

        // 2 - 3
        List<Airline> list = new List<Airline>();
        Airline flight1 = new Airline("Грушевка", 1001, "Boeing", 6.45, new List<string> { "Понедельник", "Среда", "Четверг" });
        Airline flight2 = new Airline("Солигорс", 1002, "AmericanExpress", 6.32);
        flight2.AirplaneType = "Бесплатный";
        Airline flight3 = new Airline("Полоцк", 1003, "Airbus", 9.09, new List<string> { "Вторник", "Четверг" });
        Airline flight4 = new Airline("Klimovichi", 22, "Sunday", 14.50);
        flight4.AirplaneType = "Кукурузник";
        Airline flight5 = new Airline("Пятигорск", 1002, "AmericanExpress", 6.32, new List<string> { "Среда", "Пятница" });
        Airline flight6 = new Airline("Лельчицы", 1022, "AmericanExpress", 8.12);
        flight6.AirplaneType = "Кукурузник";
        Airline flight7 = new Airline("Лопухи", 1302, "AmericanExpress", 3.23, new List<string> { "Среда", "Пятница" });
        flight7.AirplaneType = "Бесплатный";
        Airline flight8 = new Airline("Заречье", 1022, "AmericanExpress", 1.23);
        flight8.AirplaneType = "Кукурузник";
        Airline flight9 = new Airline("Светлагорск", 2002, "AmericanExpress", 10.13);
        flight9.AirplaneType = "Кукурузник";
        Airline flight10 = new Airline("Светлагорск", 2202, "AmericanExpress", 9.13);
        Airline flight11 = new Airline("Сочи", 1032, "AmericanExpress", 12.12);
        list.Add(flight1);
        list.Add(flight2);
        list.Add(flight3);
        list.Add(flight4);
        list.Add(flight5);
        list.Add(flight6);
        list.Add(flight7);
        list.Add(flight8);
        list.Add(flight9);
        list.Add(flight10);
        list.Add(flight11);

        Console.WriteLine("Введите город, куда хотите прилететь");
        string temp = Console.ReadLine();

        var ListOfFlights = list.Where(n => n.Destination == temp).Select(n => n);
        foreach (Airline air in ListOfFlights)
        {
            Console.WriteLine(air);
        }

        Console.WriteLine("Список рейсов для заданного дня");
        string dayOfFlight = "Вторник";

        var flights = list.Where(n => n.DaysOfWeek.Contains(dayOfFlight)).Select(n => n);
        foreach (Airline air in flights)
        {
            Console.WriteLine(air);
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Максимальный по дню недели рейс");

        var maxDaysCount = list.Max(n => n.DaysOfWeek.Count);

        var Maxflights = list.Where(n => n.DaysOfWeek.Count == maxDaysCount).Select(n => n);

        foreach (Airline air in Maxflights)
        {
            Console.WriteLine(air);
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Все рейсы в определенный день недели и с самым поздним временем вылета");
        string dayFlight = "Среда";
        var flightsInDay = list.Where(n => n.DaysOfWeek.Contains(dayFlight)).ToList();

        if (flightsInDay.Any())
        {
            double maxDepartureTime = flightsInDay.Max(n => n.DepartureTime);

            var latestFlights = flightsInDay.Where(n => n.DepartureTime == maxDepartureTime);

            Console.WriteLine($"Рейсы на {dayFlight} с самым поздним временем вылета:");
            foreach (var air in latestFlights)
            {
                Console.WriteLine(air);
            }
        }
        else
        {
            Console.WriteLine($"Нет рейсов в день {dayOfFlight}.");
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Упорядоченный по дню и времени рейсы");

        var daysOfWeekOrder = new List<string> { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

        var orderedFlights = list
            .SelectMany(flight => flight.DaysOfWeek, (flight, day) => new { flight, day })
            .OrderBy(x => daysOfWeekOrder.IndexOf(x.day))
            .ThenBy(x => x.flight.DepartureTime)
            .Select(x => x.flight)
            .ToList();

        foreach (var flight in orderedFlights)
        {
            Console.WriteLine(flight);
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Количество рейсов для заданного типа самолета");
        var countOfFlights = list.Count(n => n.AirplaneType == "Кукурузник");

        Console.WriteLine(countOfFlights);

        // 4
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Кастомный запрос");
        var customQuery = flights
        .Where(m => m.Destination.StartsWith("С") && m.DepartureTime < 12)
        .GroupBy(m => string.Join(", ", m.DaysOfWeek))
        .Select(m => new
        {
            Day = m.Key,
            TotalFlights = m.Count(),
            EarliestFlight = m.Min(f => f.DepartureTime),
            Flights = m.OrderBy(m => m.DepartureTime).ToList()
        })
        .Where(m => m.TotalFlights > 1);

        foreach (var group in customQuery)
        {
            Console.WriteLine($"День недели: {group.Day}");
            Console.WriteLine($"Всего рейсов: {group.TotalFlights}");
            Console.WriteLine($"Самое раннее время вылета: {group.EarliestFlight}");
            foreach (var flight in group.Flights)
            {
                Console.WriteLine($" - {flight.Destination} (Вылет: {flight.DepartureTime})");
            }
        }

        // 5
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Запрос с использованием Join");

        var airports = new List<Airport>
        {
        new Airport("Светлагорск", "Аэропорт Светлагорск"),
        new Airport("Сочи", "Аэропорт Сочи"),
        new Airport("Грушевка", "Аэропорт Грушевка"),
        new Airport("Полоцк", "Аэропорт Полоцк"),
        new Airport("Лельчицы", "Аэропорт Лельчицы")
        };


        var joinedQuery = list
            .Join(airports,
                  flight => flight.Destination,
                  airport => airport.City,
                  (flight, airport) => new
                  {
                      Destination = flight.Destination,
                      Airport = airport.AirportName,
                      DepartureTime = flight.DepartureTime,
                      DaysOfWeek = string.Join(", ", flight.DaysOfWeek)
                  });

        foreach (var result in joinedQuery)
        {
            Console.WriteLine($"Рейс в: {result.Destination}");
            Console.WriteLine($"Аэропорт: {result.Airport}");
            Console.WriteLine($"Время вылета: {result.DepartureTime}");
            Console.WriteLine($"Дни вылета: {result.DaysOfWeek}");
            Console.WriteLine();
        }


    }
}
