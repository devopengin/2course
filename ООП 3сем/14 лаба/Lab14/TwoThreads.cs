using System;
using System.IO;
using System.Threading;

namespace Lab14
{
    public class TwoThreads
    {
        public const string filePath = "EvenAndOddNumbers.txt";
        private static readonly object lockObject = new();
        private static bool even = true;

        public static void WriteToFile(int number)
        {
            lock (lockObject)
            {
                using StreamWriter writer = new(filePath, append: true);
                writer.WriteLine(number);
            }
        }

        public static void PrintEvenNumbersWithSync(int n)
        {
            for (var i = 0; i <= n; i++)
            {
                lock (lockObject)
                {
                    while (!even)
                    {
                        Monitor.Wait(lockObject);
                    }

                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                        WriteToFile(i);
                    }

                    even = false;
                    Monitor.Pulse(lockObject);
                }
                Thread.Sleep(500);
            }
        }

        public static void PrintOddNumbersWithSync(int n)
        {
            for (var i = 0; i <= n; i++)
            {
                lock (lockObject)
                {
                    while (even) 
                    {
                        Monitor.Wait(lockObject);
                    }

                    if (i % 2 != 0)
                    {
                        Console.Write(i + " ");
                        WriteToFile(i);
                    }

                    even = true; 
                    Monitor.Pulse(lockObject); 
                }
                Thread.Sleep(300);
            }
        }


        public static void FirstEvenThenOdd(int n)
        {
            Thread evenThread = new(() => PrintEven(n))
            {
                Priority = ThreadPriority.Highest
            };
            Thread oddThread = new(() => PrintOdd(n))
            {
                Priority = ThreadPriority.Lowest
            };

            evenThread.Start();
            evenThread.Join();

            oddThread.Start();
            oddThread.Join();

            Console.WriteLine("\nСначала чётные, потом нечётные");
        }

        public static void PrintEven(int n)
        {
            for (var i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                    WriteToFile(i);
                }
                Thread.Sleep(500);
            }
        }

        public static void PrintOdd(int n)
        {
            for (var i = 0; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                    WriteToFile(i);
                }
                Thread.Sleep(300);
            }
        }

        public static void PrintOneByOne(int n)
        {
            Thread evenThread = new(() => PrintEvenNumbersWithSync(n));
            Thread oddThread = new(() => PrintOddNumbersWithSync(n));

            evenThread.Start();
            oddThread.Start();

            evenThread.Join();
            oddThread.Join();

            Console.WriteLine("\nЧередование чётных и нечётных чисел закончилось");
        }
    }
}
