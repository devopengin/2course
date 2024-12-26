using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Task4
    {
        public void Execute()
        {
            ///Task a
            ulong ul = 345;
            var t = (5, "String 1", "f", "String 2", ul);
            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
            Console.WriteLine(t.Item3);
            Console.WriteLine(t.Item4);
            Console.WriteLine(t.Item5);
            Console.WriteLine(t.ul);
            //Task c
            var (temp1, temp2, temp3, temp4, temp5) = t;
            var (only1, _, _, _, only5) = t;
            var t2 = (1, "", "f", "", ul);
            Console.WriteLine($"t==t2: {t == t2}");
        }
    }
}

