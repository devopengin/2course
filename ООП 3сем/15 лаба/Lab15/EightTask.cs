using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15
{
    public static partial class Tasker
    {
        public static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Факториал равен = {result}");
        }

        
        public static async Task FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync");
            await Task.Run(() => Factorial());
            Console.WriteLine("Конец метода FactorialAsync");
        }

        public static async Task EightTask()
        {
            FactorialAsync();
            Console.WriteLine("Введите число: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен: {n * n}");
            Console.Read();
        }
    }
}
