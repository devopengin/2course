using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<string> StringCollection = new CollectionType<string>();
                CollectionType<Stack> CollectionStack = new CollectionType<Stack>();
                CollectionType<GeographicalEntity> EntityCollection = new CollectionType<GeographicalEntity>();

                Stack myStack = new Stack();
                myStack = myStack + 10;
                myStack = myStack + 7;
                CollectionStack.Add(myStack);
                CollectionStack.See();
                Console.WriteLine("------------------------------");

                Stack myStack2 = new Stack();
                myStack2 = myStack2 + 15;
                myStack2 = myStack2 + 67;
                CollectionStack.Add(myStack2);
                CollectionStack.See();
                Console.WriteLine("------------------------------");
                string str = new string("gfgffgfgf");
                StringCollection.Add(str);
                StringCollection.See();
                Console.WriteLine("------------------------------");

                Ocean ocean1 = new Ocean("Pacific Ocean", 10020, 23445);
                Continent continent = new Continent("Europe", 435335);
                EntityCollection.Add(ocean1);
                EntityCollection.Add(continent);
                EntityCollection.See();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Поиск географических объектов с длиной названия > 5:");
                var foundEntities = EntityCollection.FindByPredicate(entity => entity.Name.Length > 7);

                foreach (var entity in foundEntities)
                {
                    Console.WriteLine(entity);
                }
                Console.WriteLine("------------------------------");

                EntityCollection.WriteToFile();
                Console.WriteLine("Коллекция успешно записана");

                Console.WriteLine("------------------------------");
                EntityCollection.ReadFromFile();
                Console.WriteLine("Коллекция успешно прочитана");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при выполнении кода : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Весь код завершил свою работу");

            }

        }
    }


}
