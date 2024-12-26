using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab13
{
    [Serializable]

    public abstract class GeographicalEntity
    {
        [XmlAttribute("NameOfEntity")]

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
    [Serializable]
    public class Ocean : GeographicalEntity, IWaterBody
    {
        [NonSerialized]
        public int Cost = 100;
        [XmlElement("Deepth")]
        public double Depth { get; set; }

        public Ocean() : base("Конструктор без параметров") 
        {
            
        }
        public Ocean(string name, double depth, int cost) : base(name)
        {
            Depth = depth;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"Стоимость {Cost}";
        }
        public override void Describe()
        {
            Console.WriteLine($"Океан: {Name}, глубина: {Depth} метров (реализация из абстрактного класса), Стоимость: {Cost}");
        }

        void IWaterBody.Describe()
        {
            Console.WriteLine($"{Name}: Водный объект глубиной {Depth} метров");
        }
    }

    // класс континент
    [Serializable]
    public class Continent : GeographicalEntity
    {
        [XmlElement("Area")]
        public double Area { get; set; }
        [JsonIgnore]
        public int CostContinent = 100000;

        [XmlElement("ocean1")]
        public Ocean ocean1 = new Ocean("Ocean1", 10000, 323);
        public Continent(string name, double area) : base(name)
        {
            Area = area;
        }
        public Continent() : base("dfgfdgf")
        {
            
        }
        public override void Describe()
        {
            Console.WriteLine($"Континент (реализация из абстрактного класса): {Name}, площадь: {Area} кв. км.");
        }
    }

    // класс государство
    [Serializable]
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

    // класс вода
    [Serializable]
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

}
