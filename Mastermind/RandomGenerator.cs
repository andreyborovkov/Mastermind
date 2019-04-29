using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class RandomGenerator
    {
        public static int[] GetRandomGeneratedNumber(int first, int last, int arraySize)
        {
            var randomGeneratedArray = new int[arraySize];

            Random rnd = new Random();

            for (int i = 0; i < randomGeneratedArray.Length; i++)
            {
                //Assignes every member of the array a value of a random number between 1 and 6
                randomGeneratedArray[i] = rnd.Next(first, last); 
            }

            return randomGeneratedArray;
        }

    }
}
