using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class SetOperations
    {
        public static void Main(String[] args)
        {
            int[] list1 = { 1, 2, 3, 4, 5 };
            int[] list2 = { 4,5,6, 7, 8, 9 };

//Union operations
            //query syntax
            var union= from value in list1.Union(list2)
                       select value;

            //lamda
            var uni=list1.Union(list2);

            foreach(var item in uni)
            {
                Console.Write(item+" ");    
            }
            Console.WriteLine();


//Intersection operations
            //query syntax
            var intersection =from value in list1.Intersect(list2)
                              select value;

            //lambda
            var inter= list1.Intersect(list2);
          
            foreach (var item in inter)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

//Distinct operations
            //query syntax
            var distinct = from value in list2.Distinct()
                               select value;

            //lambda
            var dist = list1.Distinct();

            foreach (var item in dist)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
//Except operations
            //query syntax
            var except = from value in list1.Except(list2)
                           select value;

            //lamda

            var exe=list1.Except(list2);

            foreach (var item in exe)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
