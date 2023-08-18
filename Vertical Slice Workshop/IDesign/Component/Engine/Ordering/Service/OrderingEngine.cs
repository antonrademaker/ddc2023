using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Engine.Ordering.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Engine.Ordering.Service
{
   [ApplicationManifest("IDesign.Microservice.Sales","OrderingEngine")]
   public class OrderingEngine : ServiceBase, IOrderingEngine
   {
      public OrderingEngine(StatelessServiceContext context) : base(context)
      {}
   }
}
