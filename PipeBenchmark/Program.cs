using System;
using System.Collections.Concurrent;
using Akka.Actor;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using PipelineLib;
using PipelineLib.Actors;

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
    [Config(typeof(MicroBenchmarkConfig))]
    [SimpleJob(RunStrategy.Throughput, targetCount: 50, warmupCount: 5)]
    public class CalculateSpeedBenchMark
    {
        public const int Operations = 1_000_000;
        private TimeSpan timeout;
        private ActorSystem _system;
        private IActorRef _pipe;
        private IActorRef _distributor;
        private BlockingCollection<string> _queue;
        [GlobalSetup]
        public void Setup()
        {
            _queue = new BlockingCollection<string>();
            timeout = TimeSpan.FromMinutes(1);
            _system = ActorSystem.Create("system");
            _pipe = _system.ActorOf(KilometrePipeline.Prop(_queue));
            _distributor = _system.ActorOf(PipelineDistributor.Prop("roundrobin", _queue));
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _system.Dispose();
        }

        [Benchmark]
        public void Measure_KilometrePipeline_TPS()
        {
            _pipe.Tell(new InputData(DateTime.Now.Ticks, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            _ = _queue.Take();
            //var take = _queue.Take();
            //Console.WriteLine(take);
        }

        [Benchmark]
        public void Measure_Distributor_TPS()
        {
            _distributor.Tell(new InputData(DateTime.Now.Ticks, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            _ = _queue.Take();
            //var take = _queue.Take();
            //Console.WriteLine(take);
        }
    }
    public class MicroBenchmarkConfig : ManualConfig
    {
        public MicroBenchmarkConfig()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            AddColumn(StatisticColumn.AllStatistics);
        }
    }
}
