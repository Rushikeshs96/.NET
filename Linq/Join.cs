using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Join
    {
        public static void Main8(String[] args)
        {
            var products = new[]
            {
                new{ProductName="Cola", CategoryId=0},
                 new{ProductName="Tea", CategoryId=0},
                  new{ProductName="Apple", CategoryId=1},
                   new{ProductName="Kiwi", CategoryId=1},
                    new{ProductName="Carrot", CategoryId=2},
            };

            var Categories = new[]
            {
                new{CategoryId=0,CategoryName="Bevarage"},
                new{CategoryId=1,CategoryName="Fruit"},
                new{CategoryId=2,CategoryName="Vegetable"},
            };

            var query = from product in products
                        join category in Categories on product.CategoryId equals category.CategoryId
                        select new { product.ProductName, category.CategoryName };

            foreach(var item in query)
            {
                Console.WriteLine(item.ProductName+" "+item.CategoryName);
            }
        }
    }
}
