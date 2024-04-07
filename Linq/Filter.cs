using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Filter
    {
        public static void Main4(string[] args)
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            //filter by length and first character
            var length=from word in words
                       where word.Length==3 && word.Substring(0,1)=="f"
                       select word;

            //lamda
           // var len = words.Where(x => x.Length == 3)

            foreach(var word in length)
            {
                Console.WriteLine(word);
            }





        }
    }
}
