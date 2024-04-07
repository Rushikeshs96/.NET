using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Sorting
    {
        public static void Main(string[] args)
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps" };
//1
            // sorting by length of word - query syntaxt
            var length = from word in words
                         orderby word.Length descending
                         select word;

            // lambda expression
            var len = words.OrderBy(x => x.Length);

            foreach(var word in len)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();

//2
            // sorting by length of word descending - query syntaxt
            var wordlen = from word in words
                         orderby word.Length descending
                         select word;

            // lambda expression
            var wordl = words.OrderByDescending(x => x.Length);

            foreach (var word in wordl)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();

//3
            // sorting on alphabetical order of first character
            var alphabet = from word in words
                          orderby word.Substring(0,1)
                          select word;

            // lambda expression
            var alpha = words.OrderBy(x=>x.Substring(0,1));

            foreach (var word in alpha)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();

//4
            // sorting on alphabetical order of first character and length
            var alphalen = from word in words
                           orderby word.Length, word.Substring(0,1)
                           select word;

            // lambda expression
            var lenalpha = words.OrderBy(x =>x.Length).ThenBy(x => x.Substring(0,1));

            foreach (var word in lenalpha)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();


        }
    }
}
