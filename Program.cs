using System;
using System.Collections.Generic;
using MyMath;
using MyUtilities;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTimer timer = new MyTimer();

            //long NumberToCheck = 54996816813;
            long NumberToCheck = 5791;
            timer.Start();
            Console.WriteLine("Factorizing:\t{0:N0}", NumberToCheck);
            List<long> NumberFactors = Factorization.Factorize(NumberToCheck);

            Console.WriteLine("Factorization is:");
            int counter = NumberFactors.Count;
            foreach (int factor in NumberFactors)
            {
                counter--;
                Console.Write(factor);
                if (counter != 0)
                {
                    Console.Write("x");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Calculation took: {0}", timer.Elapsed);

            Console.Read();
        }
    }
}
