using System;
using System.IO;

namespace FileStream1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("D:\\File1.txt", FileMode.OpenOrCreate);
            
         StreamWriter f1 = new StreamWriter(fs);

           
            Console.WriteLine("The content of the file");

            fs.Close();
            //f1.Close();
            FileStream f2 =new FileStream("D:\\File1.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(f2);


            string data = SR.ReadLine();
            Console.WriteLine("the data in the file is as follows");
            Console.WriteLine(data);
           
            SR.Close();
            f2.Close();


        }
    }
}
