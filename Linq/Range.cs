using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Range
    {
        public static void Main10(string[] args)
        {
            //range function use
            var collection = Enumerable.Range(1, 6);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }


            //repeat function use
            var names = Enumerable.Repeat("hello c#", 5);

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

            //firstordefault
            var list = new int[] { 1, 2, 3, 4, 5 };

            int ok=list.FirstOrDefault();

            Console.WriteLine(ok);



            //last ordefault
            int last = list.LastOrDefault();

            Console.WriteLine(last);


            //element at method
            int ele = list.ElementAt(3);
            Console.WriteLine(ele);

        }
    }
}
