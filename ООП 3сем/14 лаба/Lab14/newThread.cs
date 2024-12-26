using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public static class NewThread
    {
 
        public static void PrintNumbers(object? num)
        {
            int numb = Convert.ToInt32(num);
            string filePath = "PrimeNumbers.txt";
            using StreamWriter writer = new(filePath, false);

            Console.WriteLine($"Перечисление чисел от 1 до {numb} в потоке: {Thread.CurrentThread.Name}");
            for (int i = 2; i <= numb; i++)
            {

                if (IsPrimeNumber(i))
                {
                    Console.WriteLine(i);
                    writer.WriteLine(i);
                }

                Thread.Sleep(500);

            }

            Console.WriteLine($"Результаты сохранены в {filePath}");

        }
        public static bool IsPrimeNumber(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static void CreateThread(int n)
        {
            Thread myThread = new(new ParameterizedThreadStart(PrintNumbers));
            myThread.Start(n);
            myThread.Name = ("CreateThread");
            Console.WriteLine("Имя потока: " + myThread.Name + 
                "\nПриоритет: " + myThread.Priority + 
                "\nЧисловой идентификатор: " + myThread.ManagedThreadId + 
                "\nСостояние потока: " + myThread.ThreadState);
            myThread.Join();
            Console.WriteLine("Поток завершён");
        }


    }
}
