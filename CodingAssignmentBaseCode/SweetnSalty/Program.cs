using System;
using System.Collections.Generic;

namespace CodeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 1;
            int max = 1000;
            int rows, cols = 1;

            // iteriate through a max value of a 1000
            for (int i = 1; i <= max; i++)
            {
                //if divisble by 20 print all number and space after 20
                if (i % 20 == 0)
                {
                    Console.Write(i + " ");

                }
                string swee = "sweet";
                //print sweet if the number is divisble by 3
                if (i % 3 == 0)
                {
                    Console.Write(swee);

                }
                //print "salty" if the number is  divisble by 5
                if (i % 5 == 0)
                {

                    Console.Write("salty");

                }
                // print "sweet'nSalty" if divisible by 3 and 5
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("sweet'nSalty");
                }



                else
                {
                    Console.Write(i);
                }






            }

        }
    }
}