using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab15
{
    public static partial class Tasker
    {
        public static void FifthTask()
        {
            int arraySize = 1000000;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int[] sequentialArray1 = new int[arraySize];
            int[] sequentialArray2 = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                sequentialArray1[i] = i;
                sequentialArray2[i] = i * 2;
            }

            stopwatch.Stop();
            Console.WriteLine($"Время генерации массивов обычным циклом: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Restart();

            int[] parallelArray1 = new int[arraySize];
            int[] parallelArray2 = new int[arraySize];

            Parallel.For(0, arraySize, i =>
            {
                parallelArray1[i] = i;
                parallelArray2[i] = i * 2;
            });

            stopwatch.Stop();
            Console.WriteLine($"Время генерации массивов с Parallel.For: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Restart();

            int[] parallelArray3 = new int[arraySize];
            int[] parallelArray4 = new int[arraySize];
            int[] indexes = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                indexes[i] = i;
            }

            Parallel.ForEach(indexes, i =>
            {
                parallelArray3[i] = i;
                parallelArray4[i] = i * 2;
            });

            stopwatch.Stop();
            Console.WriteLine($"Время генерации массивов с Parallel.ForEach: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
