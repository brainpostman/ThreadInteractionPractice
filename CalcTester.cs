using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadInteractionPractice
{
    public static class CalcTester
    {
        public static void RunSum(int[] intArray, Func<int[], long> sumFunc)
        {
            Console.WriteLine($"Сумма {intArray.Length} чисел:");
            Stopwatch sw = Stopwatch.StartNew();
            long sum = sumFunc(intArray);
            sw.Stop();
            Console.WriteLine($"Сумма: {sum}, Вычисление заняло: {sw.ElapsedMilliseconds} мс");
        }
    }
}
