using System;


namespace Global
{
    public class Program
    {
        public int PipkaMarina = 5;
        public enum Pipka
        {
            Day,
            PipkaMarina
        }
        static void Main(string[] args)
        {
          foreach(Pipka i in Enum.GetValues(typeof(int)))
            {
                Console.WriteLine(i);
            }

        /*const string? classPerson = "Global.Programmer";*//*
        const string? classPerson = "Global.Person";
        Console.WriteLine("Информация о сборке");
        Reflector.GetNameAssembly(classPerson);
        Console.WriteLine("---------------------------");

        Reflector.GetInfoConstructor(classPerson);

        Console.WriteLine("---------------------------");

        Console.WriteLine("Публичные методы класса: ");
        IEnumerable<string> methods = Reflector.GetPublicMethodsOfClass(classPerson);
        foreach (string method in methods)
        {
            Console.WriteLine(method);
        }

        Console.WriteLine("---------------------------");
        Console.WriteLine("Получение информации о полях и свойствах");
        IEnumerable<string> things = Reflector.GetInfoOfFieldsAndProperties(classPerson);

        foreach (string field in things)
        {
            Console.WriteLine(field);
        }

        Console.WriteLine("---------------------------");
        Console.WriteLine("Получение списка реализованных интерфейсов:");
        IEnumerable<string> interfaces = Reflector.GetInterfaces(classPerson);
        foreach (string interf in interfaces)
        {
            Console.WriteLine(interf);
        }

        Console.WriteLine("---------------------------");
        string parametr = "String";
        string res = Reflector.GetNameOfMethodsWithParametr(classPerson, parametr);
        Console.WriteLine(res);

        Console.WriteLine("---------------------------");
        string file = @"D:\Лабораторные\ООП\11 лаба\Lab11\Parametrs.txt";
        Reflector.Invoke(typeof(Person), "SayMessage", file);



        // 2
        Console.WriteLine("---------------------------");
        Console.WriteLine("Создание экземпляра класса Programmer:");

        var instance = Reflector.Create<Programmer>();
        if (instance != null)
        {
            Console.WriteLine("Созданный объект:");
            Console.WriteLine(instance);
        }
        Console.WriteLine("---------------------------");
        instance.ShowInf(); */

    }
}

}

