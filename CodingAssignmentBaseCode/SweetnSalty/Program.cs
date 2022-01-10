using System;

namespace SweetnSaltyConsole
{
    class Program
    {
        // print sweet of multiples of 3
        // print salty for multiples of 5
        // print sweetNSalty for multipes of 3 and 5
        static void Main(string[] args)
        {
            int sweet = 0;
            int salty = 0;
            int sweetNSalty = 0;


            // loop through from 1 - 1000 and print the results to the console
            for (int i = 1; i <= 1000; i++)
            {

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine(i + " sweetNSalty");
                    sweetNSalty++;
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(i + " sweet");
                    sweet++;
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i + " salty");
                    salty++;
                }

                // only print number that have assigned value sweet, salty, sweetNSalty
                else
                {
                }




            }
            Console.WriteLine("The sweet count is " + sweet);
            Console.WriteLine("The salty count is " + salty);
            Console.WriteLine("The sweetNSalty count is " + sweetNSalty);
        }
    }
}
