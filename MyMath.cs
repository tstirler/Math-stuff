using System;
using System.Collections.Generic;
using System.Threading;
using MyUtilities;

namespace MyMath
{
    class FindPrimes
    {
        public static List<long> myPrimes = new List<long>();
        public static long primeCounter = 0;
        private long _n;
        private ManualResetEvent _doneEvent;

        public FindPrimes(long n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }

        public static List<long> FindPrimesInNumber(long Number)
        {
            FindPrimes primeCalc = new FindPrimes(Number,);
            MyTimer primeTimer = new MyTimer();
            long numberToCheckTo = (Number / 2) + 1;

            primeTimer.Start();
            myPrimes.Add(2);
            myPrimes.Add(Number);
            for (int primeCheck = 1; primeCheck < numberToCheckTo; primeCheck += 2)
            {
                if(primeCounter % 1000 == 0)
                {
                    Console.SetCursorPosition(63, 0);
                    Console.Write("{0}s", primeTimer.Elapsed);
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("Current number:\t{0:N0}",primeCheck);
                }

                if (isNumberPrime(primeCheck))
                {
                    myPrimes.Add(primeCheck);
                    primeCounter++;
                }
            }
            primeTimer.Stop();
            myPrimes.Sort();
            return myPrimes;
        }

        private static bool isNumberPrime(long Number)
        {
            long OriginalNumber = Number;
            // Test whether the parameter is a prime number.
            if ((Number & 1) == 0)
            {
                if (Number == 2)
                {
                    myPrimes.Add(OriginalNumber);
                    primeCounter++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= Number; i += 2)
            {
                if (Number % i == 0)
                {
                    return false;
                }
            }

            return Number != 1;
        }
    }

    class Factorization
    {
        public static List<long> Factorize(long Number)
        {
            long OriginalNumber = Number;
            List<long> _Factors = new List<long>();
            List<long> _primesInNumber = FindPrimes.FindPrimesInNumber(Number);
            int i = 0;
            do
            {
            if (Number % _primesInNumber[i] == 0)
                {
                    _Factors.Add(_primesInNumber[i]);
                    Number = Number / _primesInNumber[i];
                }
                else
                {
                    i++;
                }
            } while (Number > 1);

            return _Factors;
        }
    }
}
