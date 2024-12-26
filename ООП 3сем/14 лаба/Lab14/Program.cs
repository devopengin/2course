using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Loader;

namespace Lab14
{

    public class Program
    {
        public static int secret;
        public static int userAnswer;
        public static Timer timer;

        public static void Startguessing()
        {
            Random random = new Random();
            secret = random.Next(1, 101);
            userAnswer = -1;
            Console.WriteLine("Угадайте число от 1 до 100");

            timer = new Timer(Podskazka, null, 0, 6000);
        }

        private static void CheckGuess()
        {
            if (userAnswer == secret)
            {
                Console.WriteLine("Наконец-то вы угадали число. Я бы справился лучше");
                timer.Dispose();
            }
            else
            {
                Console.WriteLine("Блин, мимо");
            }
        }

        private static void Podskazka(object state)
        {
            if (userAnswer == -1)
            {
                return;
            }

            if (userAnswer < secret)
            {
                Console.WriteLine("Загаданное число больше");
            }
            else if (userAnswer > secret)
            {
                Console.WriteLine("Загаданное число меньше");
            }
        }

        public static void Main(string[] args)
        {
            //1

            var allprocess = Process.GetProcesses();
            try
            {
                foreach (var process in allprocess)
                {
                    Console.WriteLine($"Id процесса: {process.Id}");
                    Console.WriteLine($"Имя процесса: {process.ProcessName}");
                    Console.WriteLine($"Время запуска: {process.StartTime}");
                    Console.WriteLine($"Приоритет: {process.BasePriority}");
                    Console.WriteLine($"Текущее состояние: {process.Responding}");
                    Console.WriteLine($"Время работы : {process.TotalProcessorTime}");
                }
            }
            catch
            {

            }

            //2
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя: {domain.FriendlyName} ");
            Console.WriteLine($"Base directory: {domain.BaseDirectory}");
            Console.WriteLine($"Домен текущего предложения: {domain.SetupInformation}");
            Console.WriteLine("Сборки, загруженные в домен:");

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }


            AppDomain newDomain = AppDomain.CreateDomain("New Domain");
            newDomain.Load(Assembly.GetExecutingAssembly().FullName);
            AppDomain.Unload(newDomain);


            //3
            //Console.WriteLine("Введите значение n для вычисления простых чисел:");
            //string? n = Console.ReadLine();
            //int number = int.Parse(n);
            //NewThread.CreateThread(number);

            //4
            Console.WriteLine("Введите n");


            string? input = Console.ReadLine();
            int n = int.Parse(input);

            Console.WriteLine("Выберите режим");
            Console.WriteLine("1.Сначала четные, потом нечетные");
            Console.WriteLine("2.Чередование четных и нечетных");

            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                TwoThreads.FirstEvenThenOdd(n);
            }
            else if (choice == "2")
            {
                TwoThreads.PrintOneByOne(n);
            }
            else
            {
                Console.WriteLine("Ошибка");
            }


            //5
            Startguessing();

            while (userAnswer != secret)
            {
                Console.Write("Введите ваше число: ");
                bool isValidInput = int.TryParse(Console.ReadLine(), out userAnswer);

                if (isValidInput)
                {
                    CheckGuess();
                }
                else
                {
                    Console.WriteLine("Не судьба поиграть");
                }
            }


        }
    }
}