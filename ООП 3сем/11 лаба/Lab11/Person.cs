using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public interface IPersonActions
    {
        void SayHello();
    }
    public class Person : IPersonActions
    {
        public string? name { get; set; }
        public int age { get; set; }
        public int id { get; set; }
        public Person(string name, int age, int id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }
        public Person()
        {
            name = "fbgbbffbv";
            age = 3423;
            id = 4345345;
        }

        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
        public string SayMessage(string message)
        {
            return $"Моё имя - {message}";
        }
    }

}
