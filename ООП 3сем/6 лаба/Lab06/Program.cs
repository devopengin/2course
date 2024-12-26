using System;
using System.Diagnostics;


public class GeographyException : Exception
{
    public GeographyException(string message) : base(message) { }
}

public class InvalidCoordinates : GeographyException
{
    public InvalidCoordinates(string message) : base(message) { }
}

public class InvalidContinent : GeographyException
{
    public InvalidContinent(string message) : base(message) { }
}

public class EntityNotFound : GeographyException
{
    public EntityNotFound(string message) : base(message) { }
}


public enum ContinentType
{
    Africa,
    Asia,
    Europe,
    NorthAmerica,
    SouthAmerica,
    Antarctica,
    Australia
}

public struct Coordinates
{
    public double X { get; set; }
    public double Y { get; set; }

    public Coordinates(double x, double y)
    {
        if (x < -90 || x > 90 || y < -180 || y > 180)
        {
            throw new InvalidCoordinates("Координаты вне допустимого диапазона");
        }
        X = x;
        Y = y;
    }

    public void DisplayCoordinates()
    {
        Console.WriteLine($"Координаты: широта {X}, долгота {Y}");
    }
}

public class GeographicalEntity
{
    public string Name { get; set; }

    public GeographicalEntity(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("Имя объекта не может быть пустым");
        }
        Name = name;
    }

    public virtual void Describe()
    {
        Console.WriteLine($"Географический объект: {Name}");
    }
}

public class Country : GeographicalEntity
{
    public string Capital { get; set; }
    public ContinentType Continent { get; set; }
    public Coordinates Location { get; set; }

    public Country(string name, string capital, ContinentType continent, Coordinates location)
        : base(name)
    {
        if (capital.Length < 2)
        {
            throw new InvalidContinent("Название столицы должно содержать не менее 2 символов");
        }

        Capital = capital;
        Continent = continent;
        Location = location;
    }

    public override void Describe()
    {
        Console.WriteLine($"{Name} - страна с столицей {Capital} на континенте {Continent}");
        Location.DisplayCoordinates();
    }
}

public class EarthController
{
    private List<GeographicalEntity> entities;

    public EarthController(List<GeographicalEntity> entities)
    {
        this.entities = entities;
    }

    public void FindCountriesByContinent(ContinentType continent)
    {
        try
        {
            var countries = entities.OfType<Country>().Where(c => c.Continent == continent);
            if (!countries.Any())
            {
                throw new EntityNotFound("Страны на данном континенте не найдены");
            }

            Console.WriteLine($"Страна на континенте {continent}:");
            foreach (var country in countries)
            {
                country.Describe();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            throw;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        try
        {
            List<GeographicalEntity> entities = new List<GeographicalEntity>
                {
                    new Country("Япония", "Токио", ContinentType.Asia, new Coordinates(10.0, 139.0)),
                    new Country("Беларусь", "Минск", ContinentType.Europe, new Coordinates(48.0, 2.0))
                };

            Debug.Assert(entities.Count > 0, "Список географических объектов не должен быть пустым");

            EarthController earthController = new EarthController(entities);

            // ошибка
            earthController.FindCountriesByContinent(ContinentType.NorthAmerica);
        }
        catch (InvalidCoordinates ex)
        {
            Console.WriteLine($"Ошибка с координатами: {ex.Message}");
        }
        catch (GeographyException ex)
        {
            Console.WriteLine($"Географическая ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Конец");
        }
    }
}

