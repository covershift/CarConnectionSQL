using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectionSQL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Press 'Enter' to begin process of transformation");

            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                TransformInsert();
            }
        }


        async static void TransformInsert()
        {
            
        }
    }
}
