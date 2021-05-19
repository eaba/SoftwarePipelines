using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using PipelineLib;

namespace PipeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CalculateSpeedBenchMark>();
            Console.ReadKey();
        }
    }
    [SimpleJob(RunStrategy.Throughput, targetCount: 50, warmupCount: 5)]
    public class CalculateSpeedBenchMark
    {
        [Benchmark]
        public void Calculate_Speed()
        {
            var cal = new Kilometers().CalculateSpeed(new InputData(DateTime.Now.Ticks, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
        
        }
    }
}
