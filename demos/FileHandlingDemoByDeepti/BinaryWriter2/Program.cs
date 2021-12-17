using System;
using System.IO;


namespace BinaryWriter2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "D:\\File3.txt";
            using (BinaryWriter bw = new BinaryWriter(File.Open(s,FileMode.Create)))
            {
                bw.Write("My File using Binary Writer");
                
            }
            using (BinaryReader brr = new BinaryReader(File.Open("D:\\File3.txt", FileMode.Open)))
            {
                Console.WriteLine(brr.ReadString());
            }
         }
    }
}
