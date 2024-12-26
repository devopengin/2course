using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    class MethodsWithString
    {

        public static string DeleteMarks(string str)
        {
            char[] marks = { ',', '.', '!', '?' };
            StringBuilder newString = new StringBuilder();
            foreach (char ch in str)
            {

                if (!marks.Contains(ch))
                {
                    newString.Append(ch);
                }
            }

            return newString.ToString();
        }

        public static string AddMarks(string str)
        {
            return str += "Иииииииииииииииииииииииииииииииииииии";
        }
        public static string StringToUpperCase(string str)
        {
            return str.ToUpper();
        }
        public static string DeleteSpaces(string str)
        {
            return str.Replace(" ", "");
        }
        public static string DeleteString(string str)
        {
            return str.Replace(str, "");
        }
        public static void NumberOfLetters(string str)
        {
            Console.WriteLine($"Количество символов в строке: {str.Length}");
        }
        public static bool IsNull(string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
    }

}
