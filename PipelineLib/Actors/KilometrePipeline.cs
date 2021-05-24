using Akka.Actor;

namespace PipelineLib.Actors
{
    public class KilometrePipeline: ReceiveActor
    {
        private readonly Kilometers _kilo;
        public KilometrePipeline()
        {
            _kilo = new Kilometers();
            Receive<InputData>(i=> 
            { 
                
            });
        }
    }
}
