using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab09
{
    public class Program
    {
        static void Main(string[] args)
        {
            Services service1 = new Services("gggg", "fffff", 10);
            Services service2 = new Services("fffff", "kgkdfgd", 30);
            Services service3 = new Services("fgfhf", "dfdfgdfg", 100);
            myCollection<Services, string> Collection1 = new myCollection<Services, string>
            {
                { service1, "Service1" },
                { service2, "Service2" },
                { service3, "Service3" }
            };

            Console.WriteLine("Количество элементов в коллекции: " + Collection1.Count);

            Collection1.WatchAll();  // Просмотр всех элементов

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Удаление 3 элемента");
            Collection1.Remove(service3);
            Collection1.WatchAll();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine(Collection1.Contains(service2));
            Console.WriteLine("-------------------------------------");

            var element = Collection1[service1];
            Console.WriteLine($"Найден элемент: {element}");

            Console.WriteLine("-------------------------------------");

            myCollection<int, int> collectionInt = new myCollection<int, int>
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 3 },
                { 4, 4 }
            };
            collectionInt.WatchAll();

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Коллекция после удаления n элементов: ");
            int n = 2;
            while (n > 0)
            {
                collectionInt.Remove(n);
                n--;
            }
            collectionInt.WatchAll();

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Коллекция после добавления элементов: ");
            collectionInt.Clear();
            collectionInt.Add(2, 2);
            collectionInt.Add(3, 3);
            for (int i = 4; i < 10; i++)
            {
                collectionInt.Add(i, i);
            }
            collectionInt.Insert(3, 5, 6);
            collectionInt[8] = 188;
            collectionInt.WatchAll();

            List<int> list = new List<int>();
            foreach (var item in collectionInt.Values)
            {
                list.Add((int)item);
            }
            Console.WriteLine("Элементы скопированы в список:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------------");
            int a = 6;

            foreach (int item in list)
            {
                if (item == a)
                {
                    Console.WriteLine("Элемент найден");
                }
            }
            static void SomeMethod(object value, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine("Добавлен новый элемент");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine("Элемент удален");
                        break;
                }
            }

            Console.WriteLine("------------------------------------");

            ObservableCollection<Services> collection5 = new ObservableCollection<Services>();
            Services service5 = new Services("апдвпд", "апвпа", 30);
            Services service6 = new Services("лиаиал", "зукук", 100);
            collection5.CollectionChanged += SomeMethod;
            collection5.Add(service5);
            collection5.Add(service6);
            collection5.Remove(service6);

        }
    }


}