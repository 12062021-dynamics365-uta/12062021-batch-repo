using System;
using System.IO;

namespace TextReader1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = File.CreateText("D:\\File2.txt"))
            {
                tw.WriteLine("this is my c# file");
                tw.WriteLine("textreader class and text writer class example");

            }
            using (TextReader tr = File.OpenText("D:\\File2.txt"))
            {
                Console.WriteLine(tr.ReadToEnd());

            }

        }
    }
}
