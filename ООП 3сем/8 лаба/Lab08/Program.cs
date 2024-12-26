using System;



namespace Lab08
{

    class Program
    {
        static void Main(string[] args)
        {

            Programmer language1 = new Programmer("C#", 13, "Высокоуровневый");
            language1.ShowInf();

            language1.LanguageNameEvent += (name) => Console.WriteLine($"Произошло событие: Смена имени на {name}");
            language1.ClassificationEvent += (classification) => Console.WriteLine($"Произошло событие: Смена классификации на {classification}");

            language1.ChangeNameOfLanguage("Чебурек2.0");
            language1.ChangeClassificationOfLanguage("Для пацанов");
            language1.ShowInf();


            string str = new string("Випка,    Бибка!");
            Console.WriteLine($"Начальная строка: {str}");

            Func<string, string> bobik;
            string result;

            bobik = MethodsWithString.DeleteMarks;
            result = bobik(str);
            Console.WriteLine($"Строка после удаления знаков препинания: {result}");

            bobik += MethodsWithString.AddMarks;
            result = bobik(result);
            Console.WriteLine($"Строка после добавления символов: {result}");

            bobik += MethodsWithString.StringToUpperCase;
            result = bobik(result);
            Console.WriteLine($"Строка после замены на верхний регистр: {result}");

            bobik += MethodsWithString.DeleteSpaces;
            result = bobik(result);
            Console.WriteLine($"Строка после удаления пробелов: {result}");

            bobik += MethodsWithString.DeleteString;
            result = bobik(result);
            Console.WriteLine($"Строка после удаления: {result}");

            Action<string> sharik = MethodsWithString.NumberOfLetters;
            sharik(str);

            Predicate<string> barsik = MethodsWithString.IsNull;
            Console.WriteLine($"Строка пустая - {barsik(str)}");

        }
    }
}

