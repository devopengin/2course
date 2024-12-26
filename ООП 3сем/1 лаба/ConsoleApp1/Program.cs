

//using System;



//Console.WriteLine("Hello, World!");


//1-a
//sbyte q = 2;
//short w = 4;
//int e = 5;
//long r = 34;
//byte t = 56;
//ushort y = 76;
//uint u = 78;
//ulong i = 875765;
//char o = 'q';
//bool p = true;
//float a = 34.3F;
//double s = 34.34;
//decimal d = 213.23M;
//string stringValue = "Hello, World!";
//object objectValue = 12345;



//// sbyte
//Console.Write("Введите sbyte: ");
//sbyte sbytes = Convert.ToSByte(Console.ReadLine());
//Console.WriteLine(sbytes);

//// short
//Console.Write("Введите short: ");
//short shorts = Convert.ToInt16(Console.ReadLine());
//Console.WriteLine(shorts);

//// int
//Console.Write("Введите int: ");
//int ints = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine(ints);

//// long
//Console.Write("Введите long: ");
//long longs = Convert.ToInt64(Console.ReadLine());
//Console.WriteLine(longs);

//// byte
//Console.Write("Введите byte: ");
//byte bytes = Convert.ToByte(Console.ReadLine());
//Console.WriteLine(bytes);

//// ushort
//Console.Write("Введите ushort: ");
//ushort ushorts = Convert.ToUInt16(Console.ReadLine());
//Console.WriteLine(ushorts);

//// uint
//Console.Write("Введите uint: ");
//uint uints = Convert.ToUInt32(Console.ReadLine());
//Console.WriteLine(uints);

//// ulong
//Console.Write("Введите ulong: ");
//ulong ulongs = Convert.ToUInt64(Console.ReadLine());
//Console.WriteLine(ulongs);

//// char
//Console.Write("Введите символ (char): ");
//char chars = Convert.ToChar(Console.ReadLine());
//Console.WriteLine(chars);

//// bool
//Console.Write("Введите bool (true/false): ");
//bool bools = Convert.ToBoolean(Console.ReadLine());
//Console.WriteLine(bools);

//// float
//Console.Write("Введите float: ");
//float floats = Convert.ToSingle(Console.ReadLine());
//Console.WriteLine(floats);

//// double
//Console.Write("Введите double: ");
//double doubles = Convert.ToDouble(Console.ReadLine());
//Console.WriteLine(doubles);

//// decimal
//Console.Write("Введите decimal: ");
//decimal decimals = Convert.ToDecimal(Console.ReadLine());
//Console.WriteLine(decimals);

//string
//Console.Write("Введите строку: ");
//string inputString = Console.ReadLine();
//Console.WriteLine("Введенная строка: " + inputString);

//object
//Console.Write("Введите что-то (будет сохранено как object): ");
//object inputObject = Console.ReadLine();
//Console.WriteLine("Введенное значение как object: " + inputObject);

//string objectAsString = (string)inputObject;
//Console.WriteLine("Объект приведен к строке: " + objectAsString);


////1-b
//// Неявное приведение
//int ab = 100;
//long bf = ab;
//float c = 10.5F;
//double dl = c;
//byte ea = 200;
//int f = ea;
//short g = 12345;
//int hp = g;
//char il = 'A';
//int j = il;

//// Явное приведение
//double x = 123.456;
//int yp = (int)x;
//long m = 10000;
//short n = (short)m;
//float pq = 10.7F;
//byte qw = (byte)pq;
//int ro = 256;
//byte sa = (byte)ro;
//decimal tm = 123.45M;
//double ul = (double)tm;

//// Использование класса Convert
//string strNumber = "123";
//int intNumber = Convert.ToInt32(strNumber);
//Console.WriteLine(intNumber);

//double doubleNumber = 45.67;
//int intFromDouble = Convert.ToInt32(doubleNumber);
//Console.WriteLine(intFromDouble);

//string strBool = "true";
//bool boolValue = Convert.ToBoolean(strBool);
//Console.WriteLine(boolValue);

////1-c
//// Упаковка
//object boxedQ = q;
//object boxedW = w;
//object boxedE = e;
//object boxedR = r;
//object boxedT = t;
//object boxedY = y;
//object boxedU = u;
//object boxedI = i;
//object boxedO = o;
//object boxedP = p;
//object boxedA = a;
//object boxedS = s;
//object boxedD = d;

//// Распаковка
//sbyte unboxedQ = (sbyte)boxedQ;
//short unboxedW = (short)boxedW;
//int unboxedE = (int)boxedE;
//long unboxedR = (long)boxedR;
//byte unboxedT = (byte)boxedT;
//ushort unboxedY = (ushort)boxedY;
//uint unboxedU = (uint)boxedU;
//ulong unboxedI = (ulong)boxedI;
//char unboxedO = (char)boxedO;
//bool unboxedP = (bool)boxedP;
//float unboxedA = (float)boxedA;
//double unboxedS = (double)boxedS;
//decimal unboxedD = (decimal)boxedD;

////1-d
//var intVar = 10;        
//Console.WriteLine("Значение intVar: " + intVar);

//// 1-e
//int? nullableInt = null;
//double? nullableDouble = 3.14;
//bool? nullableBool = null;

//// Вывод значений nullable переменных
//Console.WriteLine("Nullable int: " + nullableInt); // null
//Console.WriteLine("Nullable double: " + nullableDouble); // 3.14
//Console.WriteLine("Nullable bool: " + nullableBool); // null

//if (nullableBool == true)
//{
//    Console.WriteLine("Значение nullableBool: true");
//}

//int? xty = null;
//int yxt = xty ?? 1; // применяется для установки значений по умолчанию для типов значений и ссылочных типов, которые допускают значение null


//// 1-f
//var let = 4;
////let = bool; //В C#, переменные, объявленные с использованием ключевого слова var, являются статически типизированными. Это значит, что тип переменной определяется компилятором на этапе компиляции на основе первого присвоенного значения. После этого тип переменной нельзя изменить, и любые попытки присвоить значение другого типа приведут к ошибке компиляции.


//2-a

//string str1 = "Hello";
//string str2 = "World";
//string str3 = "Hello";

//// Сравнение строк с помощью оператора ==
//Console.WriteLine($"str1 == str2: {str1 == str2}"); // False
//Console.WriteLine($"str1 == str3: {str1 == str3}"); // True

//// Сравнение строк с помощью метода Equals()
//Console.WriteLine($"str1.Equals(str2): {str1.Equals(str2)}"); // False
//Console.WriteLine($"str1.Equals(str3): {str1.Equals(str3)}"); // True

//// Сравнение строк с помощью метода CompareTo()
//Console.WriteLine($"str1.CompareTo(str2): {str1.CompareTo(str2)}"); // Отрицательное число (str1 < str2)
//Console.WriteLine($"str1.CompareTo(str3): {str1.CompareTo(str3)}"); // 0 (str1 == str3)


////2-b
//string str1 = "Hello";
//string str2 = "World";
//string str3 = "C# Programming";

//// Сцепление строк
//string concatenated = str1 + ", " + str2 + "!";
//Console.WriteLine($"Сцепление строк: {concatenated}");

//// Копирование строки
//string copied = string.Copy(str3);
//Console.WriteLine($"Копирование строки: {copied}");

//// Выделение подстроки
//string substring = str3.Substring(0, 5); // Выделение первых 5 символов
//Console.WriteLine($"Подстрока: {substring}");

//// Разделение строки на слова
//string[] words = str3.Split(' '); // Разделение по пробелам
//Console.WriteLine("Разделение строки на слова:");
//foreach (var word in words)
//{
//    Console.WriteLine(word);
//}

//// Вставка подстроки в заданную позицию
//string inserted = str1.Insert(5, " Beautiful");
//Console.WriteLine($"Вставка подстроки: {inserted}");

//// Удаление заданной подстроки
//string removed = inserted.Remove(5, 10); // Удаление " Beautiful"
//Console.WriteLine($"Удаление подстроки: {removed}");

//// Интерполяция строк
//int year = 2024;
//string interpolated = $"Welcome to {str2}, {str1}! The year is {year}.";
//Console.WriteLine($"Интерполяция строки: {interpolated}");

//2-c
// Создание пустой строки и строки со значением null
//string emptyString = string.Empty;
//string nullString = null;

//// Использование метода string.IsNullOrEmpty
//Console.WriteLine($"emptyString: {string.IsNullOrEmpty(emptyString)}"); // True
//Console.WriteLine($"nullString: {string.IsNullOrEmpty(nullString)}");   // True

//// Проверка на null и пустоту перед выполнением операций
//if (!string.IsNullOrEmpty(emptyString))
//{
//    Console.WriteLine($"Длина пустой строки: {emptyString.Length}");
//}
//else
//{
//    Console.WriteLine("Пустая строка пустая или null.");
//}

//if (!string.IsNullOrEmpty(nullString))
//{
//    Console.WriteLine($"Длина строки со значением null: {nullString.Length}");
//}
//else
//{
//    Console.WriteLine("Строка со значением null пустая или null.");
//}

//// Попытка выполнения операций с null и пустой строкой
//try
//{
//    // Операция с пустой строкой
//    string result = emptyString.ToUpper();
//    Console.WriteLine($"Преобразование пустой строки в верхний регистр: '{result}'");

//    // Попытка выполнения операции с null строкой (будет ошибка)
//    string upperNull = nullString.ToUpper(); // Это вызовет NullReferenceException
//    Console.WriteLine($"Преобразование строки со значением null в верхний регистр: '{upperNull}'");
//}
//catch (NullReferenceException e)
//{
//    Console.WriteLine($"Исключение: {e.Message}");
//}

//// Альтернативный способ работы с null строками
//string safeNullString = nullString ?? "Строка по умолчанию";
//Console.WriteLine($"Замена null строки: '{safeNullString}'");



//3-a
//// Создание двумерного массива
//int rows = 3;
//int cols = 4;
//int[,] matrix = new int[rows, cols];

//Random random = new Random();
//for (int i = 0; i < rows; i++)
//{
//    for (int j = 0; j < cols; j++)
//    {
//        matrix[i, j] = random.Next(1, 10);
//    }
//}

//Console.WriteLine("Матрица:");
//for (int i = 0; i < rows; i++)
//{
//    for (int j = 0; j < cols; j++)
//    {
//        Console.Write($"{matrix[i, j],4} ");
//    }
//    Console.WriteLine();
//}

//3-b
//// Создание одномерного массива строк
//string[] stringArray = { "Первый", "Второй", "Третий", "Четвертый", "Пятый" };

//// Вывод содержимого массива и его длины
//Console.WriteLine("Содержимое массива:");
//for (int i = 0; i < stringArray.Length; i++)
//{
//    Console.WriteLine($"{i}: {stringArray[i]}");
//}

//Console.WriteLine($"\nДлина массива: {stringArray.Length}");

//// Запрос у пользователя позиции и нового значения для элемента массива
//Console.Write("\nВведите индекс элемента для изменения (от 0 до {0}): ", stringArray.Length - 1);
//int index = int.Parse(Console.ReadLine());

//if (index >= 0 && index < stringArray.Length)
//{
//    Console.Write("Введите новое значение: ");
//    string newValue = Console.ReadLine();

//    // Изменение значения в указанной позиции
//    stringArray[index] = newValue;

//    // Вывод обновленного массива
//    Console.WriteLine("\nОбновленное содержимое массива:");
//    for (int i = 0; i < stringArray.Length; i++)
//    {
//        Console.WriteLine($"{i}: {stringArray[i]}");
//    }
//}
//else
//{
//    Console.WriteLine("Некорректный индекс.");
//}

//3-c
//// Создание ступенчатого массива с 3 строками разной длины
//double[][] array = new double[3][]
//{
//    new double[2], // Первая строка с 2 столбцами
//    new double[3], // Вторая строка с 3 столбцами
//    new double[4]  // Третья строка с 4 столбцами
//};

//// Ввод значений для первой строки
//Console.WriteLine("Введите значения для первой строки (2 значения):");
//for (int i = 0; i < array[0].Length; i++)
//{
//    Console.Write($"Введите значение {i + 1}: ");
//    array[0][i] = Convert.ToDouble(Console.ReadLine());
//}

//// Ввод значений для второй строки
//Console.WriteLine("Введите значения для второй строки (3 значения):");
//for (int i = 0; i < array[1].Length; i++)
//{
//    Console.Write($"Введите значение {i + 1}: ");
//    array[1][i] = Convert.ToDouble(Console.ReadLine());
//}

//// Ввод значений для третьей строки
//Console.WriteLine("Введите значения для третьей строки (4 значения):");
//for (int i = 0; i < array[2].Length; i++)
//{
//    Console.Write($"Введите значение {i + 1}: ");
//    array[2][i] = Convert.ToDouble(Console.ReadLine());
//}

//// Вывод содержимого ступенчатого массива
//Console.WriteLine("\nСодержимое ступенчатого массива:");
//for (int i = 0; i < array.Length; i++)
//{
//    Console.Write($"Строка {i + 1}: ");
//    for (int j = 0; j < array[i].Length; j++)
//    {
//        Console.Write($"{array[i][j]} ");
//    }
//    Console.WriteLine();
//}

//3-d
//// Создание неявно типизированной переменной для массива целых чисел
//var intArray = new[] { 1, 2, 3, 4, 5 };

//// Создание неявно типизированной переменной для строки
//var message = "Привет, мир!";

//// Вывод содержимого массива
//Console.WriteLine("Содержимое массива:");
//foreach (var item in intArray)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine(); // Для перевода строки

//// Вывод строки
//Console.WriteLine("Сообщение:");
//Console.WriteLine(message);


//4-a
//var tuple = (42, "Hello", 'A', "World", 1234567890UL);
//4-b
//Console.WriteLine("Весь кортеж:");
//Console.WriteLine(tuple);

//// Вывод выборочных элементов кортежа
//Console.WriteLine("\nВыборочные элементы кортежа:");
//Console.WriteLine($"Первый элемент: {tuple.Item1}");
//Console.WriteLine($"Третий элемент: {tuple.Item3}");
//Console.WriteLine($"Четвертый элемент: {tuple.Item4}");


//4-c
//// Полная распаковка
//var (number, greeting, letter, name, bigNumber) = tuple;
//Console.WriteLine("Распакованные переменные:");
//Console.WriteLine($"number: {number}");
//Console.WriteLine($"greeting: {greeting}");
//Console.WriteLine($"letter: {letter}");
//Console.WriteLine($"name: {name}");
//Console.WriteLine($"bigNumber: {bigNumber}");

//// Частичная распаковка
//var (_, greet, _, nm, _) = tuple;
//Console.WriteLine("\nЧастично распакованные переменные:");
//Console.WriteLine($"greeting: {greet}");
//Console.WriteLine($"name: {nm}");

//// Игнорирование ненужных переменных
//var (num, _, let, _, bNum) = tuple;
//Console.WriteLine("\nИгнорирование ненужных переменных:");
//Console.WriteLine($"num: {num}");
//Console.WriteLine($"letter: {let}");
//Console.WriteLine($"bigNumber: {bNum}");

//// Распаковка в ссылочные переменные
//int n;
//string greetText;
//char l;
//string nmText;
//ulong bN;

//(n, greetText, l, nmText, bN) = tuple;
//Console.WriteLine("\nРаспаковка в ссылочные переменные:");
//Console.WriteLine($"n: {n}");
//Console.WriteLine($"greetText: {greetText}");
//Console.WriteLine($"l: {l}");
//Console.WriteLine($"nmText: {nmText}");
//Console.WriteLine($"bN: {bN}");

//4-d
//// Создание двух кортежей
//var tuple1 = (1, "Hello", 'A', "World", 123456789UL);
//var tuple2 = (1, "Hello", 'A', "World", 123456789UL);
//var tuple3 = (2, "Hello", 'B', "World", 987654321UL);

//// Сравнение двух идентичных кортежей
//bool areEqual1 = tuple1.Equals(tuple2);  // true
//bool areNotEqual1 = !tuple1.Equals(tuple3);  // true

//// Сравнение кортежей с использованием операторов
//bool areEqual2 = tuple1 == tuple2;  // true
//bool areNotEqual2 = tuple1 != tuple3;  // true

//// Вывод результатов сравнения
//Console.WriteLine($"tuple1 и tuple2 равны: {areEqual1}");  // Вывод: true
//Console.WriteLine($"tuple1 и tuple3 не равны: {areNotEqual1}");  // Вывод: true
//Console.WriteLine($"tuple1 и tuple2 равны (операторы): {areEqual2}");  // Вывод: true
//Console.WriteLine($"tuple1 и tuple3 не равны (операторы): {areNotEqual2}");  // Вывод: true


//5
// Пример входных данных
//int[] numbers = { 5, 3, 9, 1, 7 };
//string text = "Hello, World!";

//// Вызов локальной функции и получение результата
//var result = ProcessData(numbers, text);

//// Вывод результата
//Console.WriteLine($"Max: {result.max}");
//Console.WriteLine($"Min: {result.min}");
//Console.WriteLine($"Sum: {result.sum}");
//Console.WriteLine($"First letter: {result.firstLetter}");

//// Локальная функция
//(int max, int min, int sum, char firstLetter) ProcessData(int[] nums, string str)
//{
//    // Определение максимального и минимального элементов
//    int maxElement = int.MinValue;
//    int minElement = int.MaxValue;
//    int sumElements = 0;

//    foreach (int num in nums)
//    {
//        if (num > maxElement) maxElement = num;
//        if (num < minElement) minElement = num;
//        sumElements += num;
//    }

//    // Получение первой буквы строки
//    char firstChar = string.IsNullOrEmpty(str) ? '\0' : str[0];

//    return (maxElement, minElement, sumElements, firstChar);
//}


//6
using System;

class Program
{
    static void Main()
    {
        // Вызов функции с проверкой переполнения
        try
        {
            Console.WriteLine("Результат в функции с checked:");
            CheckedFunction();
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Исключение в функции с checked: {ex.Message}");
        }

        // Вызов функции без проверки переполнения
        Console.WriteLine("\nРезультат в функции с unchecked:");
        UncheckedFunction();
    }

    // Локальная функция с блоком checked
    static void CheckedFunction()
    {
        // Объявление переменной с максимальным значением типа int
        int maxInt = int.MaxValue;

        try
        {
            // Блок checked для обнаружения переполнения
            checked
            {
                // Попытка увеличения значения, что вызовет переполнение
                int result = maxInt + 1;
                Console.WriteLine($"Результат проверки (checked): {result}");
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Исключение в checked: {ex.Message}");
        }
    }

    // Локальная функция с блоком unchecked
    static void UncheckedFunction()
    {
        // Объявление переменной с максимальным значением типа int
        int maxInt = int.MaxValue;

        // Блок unchecked для игнорирования переполнения
        unchecked
        {
            // Попытка увеличения значения, что вызовет переполнение
            int result = maxInt + 1;
            Console.WriteLine($"Результат проверки (unchecked): {result}");
        }
    }
}

