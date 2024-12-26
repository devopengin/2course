using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Task2
    {
        public void Execute()
        {
            ////a
            string str1 = "easfwe";
            string str2 = "seklw";
            Console.WriteLine("Строки" + $" {(str1 == str2 ? "равны" : "не равны")}");
            ////b
            string str3 = "Hello my friend!";
            Console.WriteLine($"Сцепление {str1 + str2}");
            string str4 = (string)str3.Clone();///копирование
            Console.WriteLine($"Выделение подстроки с 2 по 5 символы {str4.Substring(1, 4)}");
            Console.WriteLine($"Удаление подстроки {str4.Remove(1, 4)}");
            string[] str5 = str3.Split(' ');
            Console.Write("Разделение строки на подстроки ");
            Console.WriteLine(string.Join(", ", str5));
            Console.WriteLine($"Вставка подстроки в указанную позицию {str3.Insert(6, str5[0])}");
            Console.WriteLine($"Удаление подстроки {str4.Remove(0, 5)}");
            /////c
            string str6 = "";
            string str7 = null;
            Console.WriteLine($"str6 IsNull...: {string.IsNullOrEmpty(str6)}");
            Console.WriteLine($"str7 IsNull...: {string.IsNullOrEmpty(str7)}");
            Console.WriteLine($"str6 IsNullorWhiteSpace...: {string.IsNullOrWhiteSpace(str6)}");
            Console.WriteLine($"str7 IsNullorWhiteSpace...: {string.IsNullOrWhiteSpace(str7)}");
            Console.WriteLine(string.Compare(str6, str7, false));
            ////d
            StringBuilder sb = new StringBuilder(str3);
            sb.Append(" How are u?");
            sb.Insert(0, "Letter: ");
            sb.Remove(0, 8);
        }
    }
}


