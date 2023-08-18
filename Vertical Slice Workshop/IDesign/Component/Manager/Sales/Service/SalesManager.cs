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

using Online = IDesign.Manager.Sales.Interface.Online;  
using Restaurant = IDesign.Manager.Sales.Interface.Restaurant;
using System;
using System.Linq;
using System.Net.Cache;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Manager.Sales.Service
{
    [ApplicationManifest("IDesign.Microservice.Sales", "SalesManager")]
    public class SalesManager : ServiceBase, Online.ISalesManager, Restaurant.ISalesManager
    {
        public SalesManager(StatelessServiceContext context) : base(context)
        { }
        async Task Online.ISalesManager.SearchAsync(Online.SearchCriteria searchCriteria)
        {
            Engine.Validation.Interface.Sales.IValidationEngine validationProxy = Proxy.ForComponent<Engine.Validation.Interface.Sales.IValidationEngine>(this);
            var validationResult = await validationProxy.ValidateAsync(new ValidationCriteria(searchCriteria.Location));

            IRestaurantAccess restaurantProxy = Proxy.ForComponent<IRestaurantAccess>(this);

            var restaurantCriteria = new RestaurantCriteria(searchCriteria.Location);
            var restaurants = await restaurantProxy.FilterAsync(restaurantCriteria);

            // We may skip this if there is no information required from the restaurant access
            // Should map restaurants to the ordering criteria using the following properties
            // restaurant.Id
            // Maybe payment options?

            Engine.Ordering.Interface.Ordering.IOrderingEngine orderingProxy = Proxy.ForComponent<Engine.Ordering.Interface.Ordering.IOrderingEngine>(this);
            await orderingProxy.MatchAsync();

            // Should map restaurants to the menuing criteria using the following properties
            // restaurant.Id
            // Maybe payment options?

            Engine.Ordering.Interface.Menuing.IMenuingEngine menuingProxy = Proxy.ForComponent<Engine.Ordering.Interface.Menuing.IMenuingEngine>(this);
            await menuingProxy.MatchAsync();

            // Should map restaurants to pricing criteria using the following properties
            // restaurant.Id
            // Maybe payment options?

            Engine.Pricing.Interface.IPricingEngine pricingProxy = Proxy.ForComponent<Engine.Pricing.Interface.IPricingEngine>(this);
            await pricingProxy.CalculateAsync();
        }

        async Task Restaurant.ISalesManager.SearchAsync(Restaurant.SearchCriteria searchCriteria)
        {
            // NOTE: search criteria is different from online search criteria

            // get restaurant id from ambient context
            var restaurantId = Guid.Empty;

            // NOTE: single restaurant, so no much use for displaying a list of restaurants 
            // only search for items

            IRestaurantAccess restaurantProxy = Proxy.ForComponent<IRestaurantAccess>(this);

            // shared criteria object
            var restaurantCriteria = new RestaurantCriteria(new Guid[] { restaurantId });
            var restaurants = await restaurantProxy.FilterAsync(restaurantCriteria);

            var restaurant = restaurants.FirstOrDefault();

            // Note (possible) criteria:
            // restaurant.Id
            // by searchCriteria.term
            // by searchCriteria.category
            // could share criteria object

            Engine.Ordering.Interface.Menuing.IMenuingEngine menuingProxy = Proxy.ForComponent<Engine.Ordering.Interface.Menuing.IMenuingEngine>(this);
            await menuingProxy.MatchAsync();


            Engine.Pricing.Interface.IPricingEngine pricingProxy = Proxy.ForComponent<Engine.Pricing.Interface.IPricingEngine>(this);
            await pricingProxy.CalculateAsync();

            // transform to search result:


        }

    }
}
