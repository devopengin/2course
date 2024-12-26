using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    public class Services
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Services(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public override string ToString()
        {
            return $"Название услуги: {Name}, Описание услуги: {Description}, Цена: {Price}";
        }

    }

}
