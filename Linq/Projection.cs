using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Projection
    {
        public static void Main6(String[] args)
        {
            var words = new String[] { "an", "apple", "a", "day" };

            string[] senetnces = { "an apple a day", "the quick brown fox jumps" };

            //get first words only and form a list
            var first = from word in words
                        select word.Substring(0, 1);
                     
            foreach(var word in first) {
                Console.WriteLine(word);
            }



            //extract words from both bo senetences and create new list

            var newlist=from sentence in senetnces
                        from word in sentence.Split(" ")
                        select word;


            foreach (var word in newlist)
            {
                Console.Write(word+" ");
            }




            //zip expresiion

            var list1 = new int[]{ 1, 2, 3, 4, 5, 6 };

            var list2 = new string[] { "a", "b", "c", "d", "e" };

          var query= Enumerable.Zip(list1, list2,(num,letter)=>num.ToString()+letter);

            foreach(var word in query)
            {
                Console.WriteLine(word);
            }



        }
    }
}
