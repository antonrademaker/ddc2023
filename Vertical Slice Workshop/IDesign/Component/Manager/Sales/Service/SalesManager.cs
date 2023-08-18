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
        async Task ISalesManager.FindItemAsync(FindItemRequest findItemRequest)
        {
            Engine.Validation.Interface.Sales.IValidationEngine validationProxy = Proxy.ForComponent<Engine.Validation.Interface.Sales.IValidationEngine>(this);
            var validationResult = await validationProxy.ValidateAsync(new ValidationCriteria(findItemRequest.Location));

            IRestaurantAccess restaurantProxy = Proxy.ForComponent<IRestaurantAccess>(this);

            var restaurantCriteria = new RestaurantCriteria(findItemRequest.Location);
            var restaurants = await restaurantProxy.FilterAsync(restaurantCriteria);

            Engine.Ordering.Interface.Ordering.IOrderingEngine orderingProxy = Proxy.ForComponent<Engine.Ordering.Interface.Ordering.IOrderingEngine>(this);
            await orderingProxy.MatchAsync();

            Engine.Ordering.Interface.Menuing.IMenuingEngine menuingProxy = Proxy.ForComponent<Engine.Ordering.Interface.Menuing.IMenuingEngine>(this);
            await menuingProxy.MatchAsync();

            Engine.Pricing.Interface.IPricingEngine pricingProxy = Proxy.ForComponent<Engine.Pricing.Interface.IPricingEngine>(this);
            await pricingProxy.CalculateAsync();
        }
    }
}
