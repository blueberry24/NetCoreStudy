using System;
using System.Threading;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fishingRod = new FishingRod();

            var jeff = new FishingMan("杰夫");

            jeff.FishingRod = fishingRod;


            while(jeff.FishCount <10)
            {
                jeff.Fishing();
                Console.WriteLine("----------------------------------------------");

                Thread.Sleep(2000);
            }

            Console.ReadKey();
        }

    }
}
