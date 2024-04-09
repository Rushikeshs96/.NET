using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Partitioning
    {
        public static void Main7(string[] args)
        {
            int[] list1 = { 1, 2, 3, 4, 5 };


            //skiping first 3 numbers and prining only one number
            var query = list1.Skip(3).Take(1);

            foreach(var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();




            //skip until specific number
            var query2 = list1.SkipWhile(i => i != 3);

            foreach(var item in query2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
