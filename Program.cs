//последовательный расчёт суммы
using System.Diagnostics;
using ThreadInteractionPractice;

var sw = new Stopwatch();

var ints100k = ArrayGenerator.GenerateArrayOfIRandomInts(100_000, 0, 100);
var ints1kk = ArrayGenerator.GenerateArrayOfIRandomInts(1_000_000, 0, 100);
var ints10kk = ArrayGenerator.GenerateArrayOfIRandomInts(10_000_000, 0, 100);
var ints100kk = ArrayGenerator.GenerateArrayOfIRandomInts(100_000_000, 0, 100);

int numOfThreads = 4;

Console.WriteLine("Суммы чисел от 0 до 100.\n");
Console.WriteLine("Последовательное вычисление:");
CalcTester.RunSum(ints100k, ArrayExtensions.SequentialSum);
CalcTester.RunSum(ints1kk, ArrayExtensions.SequentialSum);
CalcTester.RunSum(ints10kk, ArrayExtensions.SequentialSum);
CalcTester.RunSum(ints100kk, ArrayExtensions.SequentialSum);

Console.WriteLine();
Console.WriteLine($"Параллельное вычисление c Thread (число потоков: {numOfThreads}):");
CalcTester.RunSum(ints100k, (int[] arr) => arr.ParallelSum(numOfThreads));
CalcTester.RunSum(ints1kk, (int[] arr) => arr.ParallelSum(numOfThreads));
CalcTester.RunSum(ints10kk, (int[] arr) => arr.ParallelSum(numOfThreads));
CalcTester.RunSum(ints100kk, (int[] arr) => arr.ParallelSum(numOfThreads));

Console.WriteLine();
Console.WriteLine($"Параллельное вычисление LINQ (число потоков: {numOfThreads}):");
CalcTester.RunSum(ints100k, (int[] arr) => arr.ParallelLinqSum(numOfThreads));
CalcTester.RunSum(ints1kk, (int[] arr) => arr.ParallelLinqSum(numOfThreads));
CalcTester.RunSum(ints10kk, (int[] arr) => arr.ParallelLinqSum(numOfThreads));
CalcTester.RunSum(ints100kk, (int[] arr) => arr.ParallelLinqSum(numOfThreads));


Console.WriteLine();
Console.WriteLine($"Параллельное вычисление LINQ (число потоков: по умолчанию):");
CalcTester.RunSum(ints100k, (int[] arr) => arr.ParallelLinqSum());
CalcTester.RunSum(ints1kk, (int[] arr) => arr.ParallelLinqSum());
CalcTester.RunSum(ints10kk, (int[] arr) => arr.ParallelLinqSum());
CalcTester.RunSum(ints100kk, (int[] arr) => arr.ParallelLinqSum());


