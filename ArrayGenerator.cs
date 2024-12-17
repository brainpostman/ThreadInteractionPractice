using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadInteractionPractice
{
    public static class ArrayGenerator

    {
        public static int[] GenerateArrayOfIRandomInts(int count, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] randomInts = new int[count];
            for (var  i = 0; i < count; i++)
            {
                randomInts[i] = rand.Next(minValue, maxValue + 1);
            }
            return randomInts;
        }
    }
}
