using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Task1
    {
        public void Execute()
        {
            /////Task a
            bool a = true;
            byte b = 255;
            sbyte c = 127;
            char d = 'd';
            decimal e = 55;
            double f = 6.32131321;
            float g = 5.313232f;
            int i = 228;
            uint j = 1543462346;
            nint k = 32132132;
            nuint l = 321243214;
            long m = 9223372036854775807;
            ulong n = 18446744073709551615;
            short s = 32767;
            ushort t = 65535;
            string stringV = "Hello, World!";
            object objectV = 12345;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
            Console.WriteLine(g);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.WriteLine(k);
            Console.WriteLine(l);
            Console.WriteLine(m);
            Console.WriteLine(n);
            Console.WriteLine(s);
            Console.WriteLine(t);
            Console.WriteLine(t);
            Console.WriteLine(stringV);
            Console.WriteLine(objectV);

            ///////Task b
            long li = i;
            ulong uli = j;
            double df = g;
            int bytei = b;
            float gi = g;

            int iu = (int)n;
            string si = Convert.ToString(i);
            string ss = Convert.ToString(s);
            int bi = Convert.ToInt32(a);
            float fd = (float)f;

            /////Task c
            object obj1 = i;//упаковка
            i = (int)obj1;//распаковка

            ////Task d
            var temp = 2;
            var temp1 = "Hello world!";
            var temp2 = (int)d;

            ////Task e
            int? nullableTemp = null;
            Console.WriteLine(Convert.ToInt32(nullableTemp));

            ////Task f
            var temp3 = 2;
            //temp3 = "f";
        }
    }
}
