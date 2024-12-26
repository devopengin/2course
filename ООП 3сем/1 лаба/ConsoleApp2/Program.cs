using lab1;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {


            Task1 task1 = new Task1();
            task1.Execute();
            Console.ReadKey();

            Task2 task2 = new Task2();
            task2.Execute();
            Console.ReadKey();

            Task3 task3 = new Task3();
            task3.Execute();
            Console.ReadKey();

            Task4 task4 = new Task4();
            task4.Execute();
            Console.ReadKey();

            ////5
            int[] arr = { 1, 2, 3, 4, 5 };
            string str = "wbfwfowqf";
            (int, int, int, char) func(int[] arr, string str)
            {
                int max = arr[0], min = arr[0], sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                        max = arr[i];
                    else if (arr[i] < min)
                        min = arr[i];
                    sum += arr[i];
                }
                return (min, max, sum, str[0]);
            }
            Console.WriteLine(func(arr, str));
            /////6
            int funcUnchecked()
            {
                int temp;
                unchecked
                {
                    temp = int.MaxValue;
                };
                return temp;
            }
            int funcChecked()
            {
                int temp;
                checked
                {
                    temp = int.MaxValue;
                };
                return temp;
            }
            funcUnchecked();
            funcChecked();
        }
    }
    }
