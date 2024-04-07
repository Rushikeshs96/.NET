using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Quantifiers
    {
        public static void Main(string[] args)
        {
            var Markets = new[]
            {
                new{MarektName="MarketA", Fruits=new String[]{"kiwi","cherry","banana"}},
                new{MarektName="MarketB", Fruits=new String[]{"melon","mango","olive"}},
                new{MarektName="MarketC", Fruits=new String[]{"kiwi","apple","orange"}}
            };

            //checking weather all fruits length ==5
            var names= from market in Markets
                       where market.Fruits.All(fruit=>fruit.Length==5)
                       select market.MarektName;

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //checking weather any fruit name starting with o
            var oname=from market in Markets
                      where market.Fruits.Any(x=>x.Substring(0,1)=="o")
                      select market.MarektName;

           
            foreach (var name in oname)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            //checking weather awhich market contains fruit kiwi
            var kiwi = from market in Markets
                        where market.Fruits.Contains("kiwi")
                        select market.MarektName;


            foreach (var name in kiwi)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }
    }
}
 