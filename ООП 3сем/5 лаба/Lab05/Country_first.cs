using System;


namespace Geography
{
    public partial class Country : GeographicalEntity
    {
        public string Capital { get; set; }
        public ContinentType Continent { get; set; }
        public Coordinates Location { get; set; }

        public Country(string name, string capital, ContinentType continent, Coordinates location) : base(name)
        {
            Capital = capital;
            Continent = continent;
            Location = location;
        }

        public override void Describe()
        {
            Console.WriteLine($"Государство: {Name}, столица: {Capital}, континент: {Continent}");
            Location.DisplayCoordinates();
        }
    }
}


