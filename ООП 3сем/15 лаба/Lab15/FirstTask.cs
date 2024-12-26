using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public static partial class Tasker
    {
        public static void FirstTask()
        {
            Stopwatch stopWatch = new();
            int size = 100000000;

            int[] vector = new int[size];
            Random random = new();
            for (int i = 0; i < size; i++)
            {
                vector[i] = random.Next(1, 100);
            }

            const int mult = 9;

            Task task = new(() =>
            {
                for (int i = 0; i < size; i++)
                {
                    vector[i] *= mult;
                }
            });

            Console.WriteLine($"Статус до запуска: {task.Status}");


            stopWatch.Start();
            task.Start();

            Console.WriteLine($"task id: {task.Id}");
            Console.WriteLine($"task is completed: {task.IsCompleted}");
            Console.WriteLine($"Статус после запуска: {task.Status}");

            task.Wait();

            stopWatch.Stop();

            Console.WriteLine($"Статус после окончания: {task.Status}");
            Console.WriteLine($"Время выполнения задачи: {stopWatch.ElapsedMilliseconds} миллисекунд");

            Console.WriteLine("Первые 10 элементов после умножения:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(vector[i]);
            }

        }
    }
}
