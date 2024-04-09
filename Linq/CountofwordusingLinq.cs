using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class CountofwordusingLinq
    {
        public static void Main(string[] args)
        {
            String text = " this is sample text, to check occurence of word sample in sample text ! Thank you";

            String searchword = "sample";

            String[] textArray = text.Split(new char[] { ' ', ',', '.' });

            var query = from word in textArray
                        where word.Equals(searchword)
                        select word;

            Console.WriteLine("count of word sample = " + query.Count());


            //extracting only numbers from string

            String str = "abcd12-3-d-468$";

            var result=from ch in str
                       where char.IsDigit(ch)
                       select ch;

            foreach( var ch in result ) {
                Console.WriteLine(ch);
                    }
        }
    }
}
