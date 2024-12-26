using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public static partial class Tasker
    {
        public static void Print()
        {
            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");
            Thread.Sleep(3000);
        }
        public static void Square(int n)
        {
            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Результат {n * n}");
        }
        public static void SixthTask()
        {
            Parallel.Invoke(
                Print,
                () =>
                {
                    Console.WriteLine($"Выполняется задача: {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Square(5)
                );
        }
    }
}
