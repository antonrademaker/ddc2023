using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Engine.Pricing.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Engine.Pricing.Service
{
   [ApplicationManifest("IDesign.Microservice.Sales","PricingEngine")]
   public class PricingEngine : ServiceBase, IPricingEngine
   {
      public PricingEngine(StatelessServiceContext context) : base(context)
      {}
   }
}
