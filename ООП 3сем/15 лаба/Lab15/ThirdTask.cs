using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
   public static partial class Tasker
    {
        public static void ThirdTask(){

            Task<int> task1 = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 1; i <= 10; i++)
                {
                    sum += i;
                }
                return sum;
            });

            Task<int> task2 = new Task<int>(() =>
            {
                int multiply = 1;
                for (int i = 1; i <= 10; i++)
                {
                    multiply *= i;
                }
                return multiply;
            });

            Task<int> task3 = new Task<int>(() =>
            {
                int kube = 1;
                for (int i = 1; i <= 5; i++)
                {
                    kube *= i*i;
                }
                return kube;
            });

            task1.Start();
            task2.Start();
            task3.Start();

            task1.Wait();
            task2.Wait();
            task3.Wait();
            int sum = task1.Result;
            int multipl = task2.Result;
            int cube = task3.Result;

            Task task4 = new(() =>
            {
                Console.WriteLine($"Сумма первых 10 чисел: {sum}");
                Console.WriteLine($"Произведение первых 10 чисел: {multipl}");
                Console.WriteLine($"Произведение квадратов чисел: {cube}");
            });

            task4.Start();
            task4.Wait();
        }
    }
}
