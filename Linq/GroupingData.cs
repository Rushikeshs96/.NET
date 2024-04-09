using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class GroupingData
    {
        public static void Main(string[] args)
        {
            var numbers = new[]
            {
                new{Number="one",Type="odd"},
                 new{Number="two",Type="even"},
                  new{Number="three",Type="odd"},
                   new{Number="four",Type="even"},
                    new{Number="five",Type="odd "},
            };


            var query = from number in numbers
                        group number by number.Type into g
                        select new { Type = g.Key, Count = g.Count() };

            foreach( var number in query)
            {
                Console.WriteLine(number.Type+" "+number.Count);
            }



            // default if empty opeartaion returns default value if value is not present
            var list = new int[] { };

            foreach( var number in list.DefaultIfEmpty())
            {
                Console.WriteLine(number);
            }
        }
    }
}
