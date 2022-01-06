using System;
using System.Threading.Tasks;

namespace Async_Await_Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task t3 = AsyncMethods.MethodAsync3();
            Console.WriteLine("waiting 3 seconds in main.");

            Task t1 = AsyncMethods.MethodAsync1();
            Console.WriteLine("waiting 1 second in main.");

            Task t2 = AsyncMethods.MethodAsync2();
            Console.WriteLine("waiting 2 seconds in main.");

            await t1;
            Console.WriteLine("After awaiting t1");
            await t3;
            Console.WriteLine("After awaiting t3");
            await t2;
            Console.WriteLine("After awaiting t2");


            await AsyncMethods.MethodAsync1();
            Console.WriteLine("waiting 1 second in main.");

            await AsyncMethods.MethodAsync2();
            Console.WriteLine("waiting 2 seconds in main.");

            await AsyncMethods.MethodAsync3();
            Console.WriteLine("waiting 3 seconds in main.");







        }
    }
}
