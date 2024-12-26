using System;
using System.Collections;
using System.Collections.Generic;


namespace Lab07
{
    public class Stack
    {
        int length = 0;
        public List<int> elements = new List<int>();

        public class Production
        {
            public int Id { get; set; }
            public string Organization { get; set; }
        }

        public class Developer
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Department { get; set; }
        }

        // перегруженный оператор + для добавления элемента в стек
        public static Stack operator +(Stack stack, int element)
        {
            stack.elements.Add(element);
            return stack;
        }

        // перегруженный оператор -- для извлечения элемента из стека
        public static Stack operator --(Stack stack)
        {
            if (stack.elements.Count > 0)
            {
                stack.elements.RemoveAt(stack.elements.Count - 1);
            }
            return stack;
        }

        // перегрузка операторов true и false для проверки стека
        public static bool operator true(Stack stack)
        {
            return stack.elements.Count == 0;
        }

        public static bool operator false(Stack stack)
        {
            return stack.elements.Count > 0;
        }

        // перегрузка оператора > для копирования стека с сортировкой
        public static bool operator >(Stack stack1, Stack stack2)
        {
            stack2.elements = new List<int>(stack1.elements);
            stack2.elements.Sort();
            return true;
        }

        public static bool operator <(Stack stack1, Stack stack2)
        {
            return false;
        }

        // метод для вывода элементов стека
        public string Print()
        {
            return string.Join(" ", elements) + "\n";
        }
        public override string ToString()
        {
            return Print();
        }
    }

    public static class StatisticOperation
    {
        // метод для подсчета суммы элементов стека
        public static int Sum(Stack stack)
        {
            return stack.elements.Sum();
        }

        // метод для нахождения разницы между максимальным и минимальным элементами
        public static int Difference(Stack stack)
        {
            return stack.elements.Max() - stack.elements.Min();
        }

        // метод для подсчета количества элементов
        public static int Count(Stack stack)
        {
            return stack.elements.Count();
        }

        // метод расширения для подсчета количества предложений в строке
        public static int SentenceCount(this string str)
        {
            var sentences = str.Split(new[] { '.', '!', '?' });
            var nonEmptySentences = sentences.Where(s => !string.IsNullOrWhiteSpace(s));
            return nonEmptySentences.Count();
        }

        // метод расширения для удаления цифр из строки
        public static string RemoveDigits(this string str)
        {
            return new string(str.Where(c => !char.IsDigit(c)).ToArray());
        }

        // метод расширения для нахождения среднего значения элементов стека
        public static double AverageElement(this Stack stack)
        {
            if (stack.elements.Count == 0)
                return 0;
            return stack.elements.Average();
        }

        // метод расширения для нахождения максимального элемента в стеке
        public static int MaxElement(this Stack stack)
        {
            if (stack.elements.Count == 0)
                return int.MinValue;
            return stack.elements.Max();
        }
    }
}
