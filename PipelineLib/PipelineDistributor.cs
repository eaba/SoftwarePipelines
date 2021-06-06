using System.Collections.Concurrent;
using Akka.Actor;
using Akka.Routing;
using PipelineLib.Actors;

namespace PipelineLib
{
    public class PipelineDistributor: ReceiveActor
    {
        private readonly IActorRef _router;
        public PipelineDistributor(string routStrategy, BlockingCollection<string> queue)
        {
            //Router "Pools" are routers that create their own worker actors, that is;
            //you provide the number of instances as a parameter to the router and the router will handle routee creation by itself.
            _router =  RouterFactory(routStrategy, queue);
            Receive<InputData>(inp => _router.Tell(inp));

         }
        private IActorRef RouterFactory(string routerStrategy, BlockingCollection<string> queue)
        {
            var resizer = new DefaultResizer(lower: 4, upper: 8, pressureThreshold: 1, rampupRate: 0.2, backoffThreshold: 0.3, backoffRate: 0.1, messagesPerResize: 1000);
            IActorRef routerActor;
            switch (routerStrategy.ToLower())
            {
                case "consistenthashing":
                    routerActor = Context.System.ActorOf(KilometrePipeline.Prop(queue).WithRouter(new ConsistentHashingPool(4).WithResizer(resizer)), "ConsistentHashing");
                    break;
                case "smallestmailbox":
                    routerActor = Context.System.ActorOf(KilometrePipeline.Prop(queue).WithRouter(new SmallestMailboxPool(4).WithResizer(resizer)), "SmallestMailbox");
                    break;
                default:
                    routerActor = Context.System.ActorOf(KilometrePipeline.Prop(queue).WithRouter(new RoundRobinPool(4).WithResizer(resizer)), "RoundRobin");
                    break;
            }
            //var t = Context.System.ActorOf(Props..Create<KilometrePipeline>().WithRouter(new ConsistentHashingPool(4).WithResizer(resizer)), "ConsistentHashing");
            return routerActor;
        }
        public static Props Prop(string routeStrategy, BlockingCollection<string> queue)
        {
            return Props.Create(() => new PipelineDistributor(routeStrategy, queue));
        }
    }
}
