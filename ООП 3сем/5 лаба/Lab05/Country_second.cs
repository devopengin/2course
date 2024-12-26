using System;

namespace Geography
{
    public partial class Country
    {
        public void DisplayCapital()
        {
            Console.WriteLine($"Столица государства {Name}: {Capital}");
        }
    }
}
