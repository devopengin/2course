using System;

namespace Geography
{
    public abstract class GeographicalEntity
    {
        public string Name { get; set; }

        public GeographicalEntity(string name)
        {
            Name = name;
        }
        public abstract void Describe();

        public override string ToString()
        {
            return $"Географический объект: {Name}";
        }
    }

    public interface IWaterBody
    {
        void Describe();
    }

    // класс океан
    public class Ocean : GeographicalEntity, IWaterBody
    {
        public double Depth { get; set; }

        public Ocean(string name, double depth) : base(name)
        {
            Depth = depth;
        }

        public override void Describe()
        {
            Console.WriteLine($"Океан: {Name}, глубина: {Depth} метров (реализация из абстрактного класса)");
        }

        void IWaterBody.Describe()
        {
            Console.WriteLine($"{Name}: Водный объект глубиной {Depth} метров");
        }
    }

    // класс континент
    public class Continent : GeographicalEntity
    {
        public double Area { get; set; }

        public Continent(string name, double area) : base(name)
        {
            Area = area;
        }

        public override void Describe()
        {
            Console.WriteLine($"Континент (реализация из абстрактного класса): {Name}, площадь: {Area} кв. км.");
        }
    }

    // класс государство
    public class Country : GeographicalEntity
    {
        public string Capital { get; set; }

        public Country(string name, string capital) : base(name)
        {
            Capital = capital;
        }
        public override void Describe()
        {
            Console.WriteLine($"Государство (реализация из абстрактного класса): {Name}, столица: {Capital}");
        }
    }

    // класс остров
    public class Island : GeographicalEntity
    {
        public double Population { get; set; }

        public Island(string name, double population) : base(name)
        {
            Population = population;
        }
        public override void Describe()
        {
            Console.WriteLine($"Остров (реализация из абстрактного класса): {Name}, население: {Population} млн.");
        }
    }

    // класс суша
    public class Land : GeographicalEntity
    {
        public double Area { get; set; }

        public Land(string name, double area) : base(name)
        {
            Area = area;
        }
        public override void Describe()
        {
            Console.WriteLine($"Суша (реализация из абстрактного класса): {Name}, площадь: {Area} кв. км.");
        }
    }

    // класс вода
    public class Water : GeographicalEntity, IWaterBody
    {
        public string Type { get; set; }

        public Water(string name, string type) : base(name)
        {
            Type = type;
        }
        public override void Describe()
        {
            Console.WriteLine($"Водный объект: {Name}, тип: {Type} (реализация из абстрактного класса)");
        }

        void IWaterBody.Describe()
        {
            Console.WriteLine($"{Name}: Водный объект типа {Type}");
        }
    }
    public sealed class Printer
    {
        public void IAmPrinting(GeographicalEntity obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ocean pacific = new Ocean("Тихий океан", 10994);
            Continent asia = new Continent("Азия", 44579000);
            Country japan = new Country("Япония", "Токио");
            Island hawaii = new Island("Гавайи", 1.4);
            Land europe = new Land("Европа", 10180000);
            Water nile = new Water("Река Нил", "Река");

            GeographicalEntity[] entities = { pacific, asia, japan, hawaii, europe, nile };

            Printer printer = new Printer();

            foreach (var entity in entities)
            {
                printer.IAmPrinting(entity);
                entity.Describe();

                if (entity is IWaterBody waterBody)
                {
                    Console.WriteLine("Это водный объект (вызов через интерфейс):");
                    waterBody.Describe();
                }

                var country = entity as Country;
                if (country != null)
                {
                    Console.WriteLine($"Это государство с названием: {country.Name} и столицей: {country.Capital}");
                }

                Console.WriteLine();
            }
        }
    }
}
