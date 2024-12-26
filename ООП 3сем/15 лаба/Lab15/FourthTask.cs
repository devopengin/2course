using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
   public static partial class Tasker
    {
        public static void FourthTaskCont()
        {
            Task task1 = new(() => {
                Console.WriteLine($"Текущая задача: {Task.CurrentId}");
            });

            Task task2 = task1.ContinueWith(task => 
            Console.WriteLine($"Теккущая задача: {Task.CurrentId} Предыдущая задача: {task.Id}")
            );

            Task task3 = task2.ContinueWith(task =>
            Console.WriteLine($"Теккущая задача: {Task.CurrentId} Предыдущая задача: {task.Id}")
            );

            Task task4 = task3.ContinueWith(task =>
            Console.WriteLine($"Теккущая задача: {Task.CurrentId} Предыдущая задача: {task.Id}")
            );

            task1.Start();
            task4.Wait();

            Console.WriteLine("Конец метода");
        }

        public static void FourthTaskGet() {
            Task task1 = new(() =>
            {
                Console.WriteLine("Задача 1 завершена");
            });

            Task task2 = new(() =>
            {
                Console.WriteLine("Задача 2 завершена");
            });

            Task task3 = new(() =>
            {
                Console.WriteLine("Задача 3 завершена");
            });

            Task task4 = new(() =>
            {
                Console.WriteLine("Задача 4 завершена");
            });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            task1.GetAwaiter().GetResult();
            task2.GetAwaiter().GetResult();
            task3.GetAwaiter().GetResult();
            task4.GetAwaiter().GetResult();

            Console.WriteLine("Конец метода метода");
        }
    }
}
