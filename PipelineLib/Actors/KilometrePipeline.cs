using System;
using System.Collections.Concurrent;
using System.Text.Json;
using Akka.Actor;

namespace PipelineLib.Actors
{
    public class KilometrePipeline: ReceiveActor
    {
        private readonly Kilometers _kilo;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly BlockingCollection<string> _queue;
        public KilometrePipeline(BlockingCollection<string> queue)
        {
            _queue = queue;
            _kilo = new Kilometers();
            _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
            Receive<InputData>(i=> 
            {
                var result = JsonSerializer.Serialize(_kilo.CalculateSpeed(i), options: _jsonSerializerOptions );
                _queue.Add(result);
            });
        }
        public static Props Prop(BlockingCollection<string> queue)
        {
            return Props.Create(() => new KilometrePipeline(queue));
        }
    }
}
