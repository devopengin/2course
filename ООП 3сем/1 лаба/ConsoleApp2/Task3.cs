using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Task3
    {
        public void Execute()
        {
            Random rand = new Random();
            ////a
            int[,] arr1 = new int[4, 3];
            for (int i = 0; i < arr1.GetLength(0); i++)//заполнение
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    arr1[i, j] = rand.Next(1, 100);
                }
            }

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (j == arr1.GetLength(1) - 1)
                        Console.WriteLine(arr1[i, j]);
                    else Console.Write(arr1[i, j] + " ");
                }

            }
            /////b
            string[] arr2 = { "1st string", "2nd string", "3rd string" };
            foreach (string s in arr2)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"Длина: {arr2.Length}");
            Console.WriteLine("Введите строку которую хотите поменять...");
            string input = Console.ReadLine();
            int num;
            while (!int.TryParse(input, out num) || num > arr2.Length)
            {
                Console.WriteLine("Введите корректный номер строки");
                input = Console.ReadLine();
            }
            Console.WriteLine("Введите новое содержимое строки");
            string newStr = Console.ReadLine();
            arr2[num - 1] = newStr;

            foreach (string s in arr2)
            {
                Console.WriteLine(s);
            }
            //////c
            double[][] stepArr = new double[3][];
            string buff;

            stepArr[0] = new double[2];
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine("Введите элемент массива");
                buff = Console.ReadLine();
                while (!double.TryParse(buff, out stepArr[0][j]))
                {
                    Console.WriteLine("Введите корректный элемент");
                    buff = Console.ReadLine();
                }
            }
            stepArr[1] = new double[3];
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Введите элемент массива");
                buff = Console.ReadLine();
                while (!double.TryParse(buff, out stepArr[1][j]))
                {
                    Console.WriteLine("Введите корректный элемент");
                }
            }
            stepArr[2] = new double[4];
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine("Введите элемент массива");
                buff = Console.ReadLine();
                while (!double.TryParse(buff, out stepArr[2][j]))
                {
                    Console.WriteLine("Введите корректный элемент");
                }
            }
            //////d
            
            var intArray = new[] { 1, 2, 3, 4, 5 };

            var message = "Привет, мир!";

            Console.WriteLine("Содержимое массива:");
            foreach (var item in intArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Сообщение:");
            Console.WriteLine(message);
        }
    }
}