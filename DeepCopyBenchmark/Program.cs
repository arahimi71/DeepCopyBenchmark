using BenchmarkDotNet.Running;

namespace DeepCopyBenchmark;

internal class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<CloningBenchmarks>();
        Console.WriteLine(summary);
    }
}