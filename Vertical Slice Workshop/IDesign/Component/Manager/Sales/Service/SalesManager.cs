using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Access.Restaurant.Interface;
using IDesign.Engine.Validation.Interface;
using IDesign.Engine.Validation.Interface.Sales;
using IDesign.Engine.Ordering.Interface;
using IDesign.Engine.Pricing.Interface;
using IDesign.Manager.Sales.Interface;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Manager.Sales.Service
{
    [ApplicationManifest("IDesign.Microservice.Sales", "SalesManager")]
    public class SalesManager : ServiceBase, ISalesManager
    {
        public SalesManager(StatelessServiceContext context) : base(context)
        { }
        async Task ISalesManager.FindItemAsync()
        {
            Engine.Validation.Interface.Sales.IValidationEngine validationProxy = Proxy.ForComponent<Engine.Validation.Interface.Sales.IValidationEngine>(this);
            await validationProxy.ValidateAsync();

            IRestaurantAccess restaurantProxy = Proxy.ForComponent<IRestaurantAccess>(this);
            await restaurantProxy.FilterAsync();
        }
    }
}
