namespace Linq
{
  internal class Program
    {
        public static void Main1(String[] args)
        {
            //Datasource
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Query expression 
            var result = from num in arr
                         where (num % 2 == 0)
                         select num;

            //lambda expression
            var res = arr.Where(x=>x%2 == 0);   

            //query execution
            foreach(var num in res)
            {
                Console.Write(num   +" ");
            }
        }
    }
}