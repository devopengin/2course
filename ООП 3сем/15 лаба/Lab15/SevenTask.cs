using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15
{
    public static partial class Tasker
    {
        public static class Storage
        {
            static BlockingCollection<string> storage = new();
            static Random random = new();
            static CancellationTokenSource cts = new();

            static readonly string[] products = { "Чашечка вискарика", "Балльзам на душу", "Носок", "Вода", "Курсач" };
            static readonly string[] buyerNames = { "Игорь", "Андрюша", "Аркаша", "Семен", "Боря", "Пипеткин", "Геннадий", "Жорик", "Алик", "Василий" };

            public static void Start()
            {
                for (int i = 1; i <= 5; i++)
                {
                    string supplierName = $"Поставщик {i}";
                   Thread.Sleep(200);
                    int initialSpeed = random.Next(1000, 3000);
                    Task.Run(() => Seller(supplierName, initialSpeed, cts.Token));
                }
                for (int i = 0; i < buyerNames.Length; i++)
                {
                    string buyerName = buyerNames[i];
                    Task.Run(() => Buyer(buyerName, cts.Token));
                }

                Thread.Sleep(6000);
                cts.Cancel();

                while (!storage.IsCompleted && storage.Count > 0)
                {
                    Thread.Sleep(500);
                }
                DisplayStorageState();
            }

            static void Seller(string name, int initialSpeed, CancellationToken cancellationToken)
            {
                int speed = initialSpeed;
                while (!cancellationToken.IsCancellationRequested)
                {
                    Thread.Sleep(speed);
                    string product = products[random.Next(products.Length)];
                    storage.Add(product);
                    PrintColored(ConsoleColor.Magenta, $"{name} добавил на склад: {product}");
                    Thread.Sleep(200);
                    speed = Math.Max(500, speed - 100);
                    DisplayStorageState();
                }
            }

            static void Buyer(string name, CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested || storage.Count > 0)
                {
                    if (storage.TryTake(out string product))
                    {
                        PrintColored(ConsoleColor.Green, $"{name} купил: {product}");
                    }
                    else if (!cancellationToken.IsCancellationRequested)
                    {
                        PrintColored(ConsoleColor.Red, $"{name}: Товара нет, уходит");
                    }
                    Thread.Sleep(random.Next(1000, 2000));
                    DisplayStorageState();
                }
            }

            static void DisplayStorageState()
            {
                Console.WriteLine($"Состояние склада: {(storage.Count > 0 ? string.Join(", ", storage) : "Пусто")}");
            }

            static void PrintColored(ConsoleColor color, string text)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(text);
                    Console.ResetColor();
                }
            }
        }

    }
}