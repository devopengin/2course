using System;
using System.Collections.Generic;

namespace Lab07
{
    public class GeographicalEntity
    {
        public string Name { get; set; }
        public virtual double Area { get; set; }

        public GeographicalEntity(string name)
        {
            Name = name;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"Географический объект: {Name}");
        }

        public override string ToString()
        {
            return $"Географический объект: {Name}, Площадь: {Area}";
        }
    }

    public interface IWaterBody
    {
        void Describe();
    }

    public class Ocean : GeographicalEntity, IWaterBody
    {
        public double Depth { get; set; }

        public Ocean(string name, double depth, double area) : base(name)
        {
            Depth = depth;
            Area = area;
        }

        public override void Describe()
        {
            Console.WriteLine($"Океан: {Name}, глубина: {Depth} метров, площадь: {Area} кв. км");
        }

        void IWaterBody.Describe()
        {
            Console.WriteLine($"{Name}: Водный объект глубиной {Depth} метров, площадью {Area} кв. км");
        }

        public override string ToString()
        {
            return $"Океан: {Name}, Глубина: {Depth} м, Площадь: {Area} кв. км";
        }
    }

    public class Continent : GeographicalEntity
    {
        public Continent(string name, int area) : base(name)
        {
            Area = area;
        }

        public override void Describe()
        {
            Console.WriteLine($"Континент: {Name}, площадь: {Area} кв. км");
        }

        public override string ToString()
        {
            return $"Континент: {Name}, Площадь: {Area} кв. км";
        }
    }

    public class Island : GeographicalEntity
    {
        public double Population { get; set; }
        public override double Area { get; set; }

        public Island(string name, double population) : base(name)
        {
            Population = population;
        }

        public override void Describe()
        {
            Console.WriteLine($"Остров: {Name}, население: {Population} млн, площадь: {Area} кв. км");
        }

        public override string ToString()
        {
            return $"Остров: {Name}, Население: {Population} млн";
        }
    }

    public class Land : GeographicalEntity
    {
        public override double Area { get; set; }

        public Land(string name, double area) : base(name)
        {
            Area = area;
        }

        public override void Describe()
        {
            Console.WriteLine($"Суша: {Name}, площадь: {Area} кв. км");
        }

        public override string ToString()
        {
            return $"Суша: {Name}, Площадь: {Area} кв. км";
        }
    }
}
