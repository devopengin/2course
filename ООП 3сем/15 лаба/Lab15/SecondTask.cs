using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15
{
    public static partial class Tasker
    {
        public static void SecondTask()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            int size = 100000000;
            int[] vector = new int[size];
            Random random = new();
            for (int i = 0; i < size; i++)
            {
                vector[i] = random.Next(1, 100);
            }

            const int mult = 9;

            void MultiplyArray()
            {
                for (int i = 0; i < size; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана внутри цикла");
                        return;
                    }

                    vector[i] *= mult;

                    if (i % 100000 == 0)
                    {
                        Console.WriteLine($"Обработано {i} элементов");
                        Thread.Sleep(1);
                    }
                }

                Console.WriteLine("Задача завершена успешно");
            }

            Task task = new Task(MultiplyArray, token);

            Console.WriteLine("Начало выполнения");
            task.Start();

            Thread.Sleep(50);
            cancelTokenSource.Cancel();

            task.Wait();

            Console.WriteLine($"Статус задачи: {task.Status}");
        }
    }
}
