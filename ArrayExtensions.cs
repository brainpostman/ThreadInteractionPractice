using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadInteractionPractice
{
    public static class ArrayExtensions
    {
        public static long SequentialSum(this int[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static long ParallelSum(this int[] array, int numberOfThreads = 4)
        {
            Thread[] threads = new Thread[numberOfThreads];
            long[] threadResults = new long[numberOfThreads];

            int chunkSize = array.Length / numberOfThreads;
            int remainder = array.Length % numberOfThreads;
            int[,] ranges = new int[numberOfThreads, 2];
            int chunkStart = 0;
            for (var i = 0; i < numberOfThreads; i++)
            {
                ranges[i, 0] = chunkStart;
                chunkStart += chunkSize + (i < remainder ? 1 : 0);
                ranges[i, 1] = chunkStart - 1;
                threadResults[i] = 0;
            }

            for (var i = 0; i < numberOfThreads; i++)
            {
                var start = ranges[i, 0];
                var end = ranges[i, 1];
                var k = i;
                var thread = new Thread(() =>
                {
                    long localSum = 0;
                    for (int j = start; j <= end; j++)
                    {
                        localSum += array[j];
                    }
                    threadResults[k] = localSum;
                });
                threads[i] = thread;
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return threadResults.Sum();
        }

        public static long ParallelLinqSum(this int[] array, int? numberOfThreads = null)
        {
            return numberOfThreads != null ?
                array.AsParallel()
                    .WithDegreeOfParallelism(numberOfThreads.Value)
                    .Select(x => (long)x)
                    .Sum()
                :
                array.AsParallel()
                    .Select(x => (long)x)
                    .Sum();
        }

    }
}
