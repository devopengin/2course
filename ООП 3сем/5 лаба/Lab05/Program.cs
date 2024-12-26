using System;


namespace Geography
{
    // перечисление
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
    // структура
    public struct Coordinates
    {
        public double x { get; set; }
        public double y { get; set; }

        public Coordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void DisplayCoordinates()
        {
            Console.WriteLine($"Координаты: широта {x}, долгота {y}");
        }
    }
    // класс-контейнер
    public class GeographicalContainer
    {
        private List<GeographicalEntity> entities = new List<GeographicalEntity>();

        public void Add(GeographicalEntity entity)
        {
            entities.Add(entity);
        }

        public void Remove(GeographicalEntity entity)
        {
            entities.Remove(entity);
        }

        public List<GeographicalEntity> GetAll()
        {
            return entities;
        }

        public void DisplayAll()
        {
            foreach (var entity in entities)
            {
                Console.WriteLine(entity);
                entity.Describe();
            }
        }
    }

    // абстрактный класс географических объектов
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
    // класс-Контроллер
    public class EarthController
    {
        private GeographicalContainer container;

        public EarthController(GeographicalContainer container)
        {
            this.container = container;
        }

        public void FindCountriesByContinent(ContinentType continent)
        {
            var countries = container.GetAll().OfType<Country>().Where(c => c.Continent == continent);
            Console.WriteLine($"Государства на континенте {continent}:");
            foreach (var country in countries)
            {
                country.DisplayCapital();
            }
        }

        public void CountSeas()
        {
            int count = container.GetAll().OfType<Ocean>().Count();
            Console.WriteLine($"Количество морей (океанов): {count}");
        }

        public void SortIslands()
        {
            var islands = container.GetAll().OfType<Island>().OrderBy(i => i.Name);
            Console.WriteLine("Острова по алфавиту:");
            foreach (var island in islands)
            {
                Console.WriteLine(island.Name);
            }
        }
    }

    public interface IWaterBody
    {
        void Describe();
    }

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
            Ocean north = new Ocean("Северный Ледовитый", 23459);
            Coordinates japanCoordinates = new Coordinates(35.6895, 139.6917);
            Country japan = new Country("Япония", "Токио", ContinentType.Asia, japanCoordinates);
            Country france = new Country("Франция", "Париж", ContinentType.Europe, new Coordinates(48.8566, 2.3522));
            Country italy = new Country("Италия", "Рим", ContinentType.Europe, new Coordinates(34.344334, 4.4344));
            Island hawaii = new Island("Гавайи", 1.4);
            Island madagascar = new Island("Мадагаскар", 26.26);
            Water nile = new Water("Река Нил", "Река");

            GeographicalContainer container = new GeographicalContainer();
            container.Add(pacific);
            container.Add(north);
            container.Add(japan);
            container.Add(france);
            container.Add(italy);
            container.Add(hawaii);
            container.Add(madagascar);
            container.Add(nile);

            EarthController earthController = new EarthController(container);

            earthController.FindCountriesByContinent(ContinentType.Europe);
            earthController.CountSeas();
            earthController.SortIslands();
        }
    }
}
