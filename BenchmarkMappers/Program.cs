using BenchmarkDotNet.Running;

namespace BenchmarkMappers
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<BenchmarkRunnerOnSampleList>();
        }
    }
}
