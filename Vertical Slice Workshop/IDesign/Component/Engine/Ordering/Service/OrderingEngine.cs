using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Engine.Ordering.Interface.Ordering;
using IDesign.Engine.Ordering.Interface.Menuing;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Engine.Ordering.Service
{
   [ApplicationManifest("IDesign.Microservice.Sales","OrderingEngine")]
   public class OrderingEngine : ServiceBase, Interface.Ordering.IOrderingEngine, IMenuingEngine
   {
      public OrderingEngine(StatelessServiceContext context) : base(context)
      {}

        Task IOrderingEngine.MatchAsync()
        {
            return Task.CompletedTask;
        }

        Task IMenuingEngine.MatchAsync()
        {
            return Task.CompletedTask;

        }
    }
}
