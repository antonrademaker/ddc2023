using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Access.Restaurant.Interface;
using System.Collections;
using System.Collections.Generic;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Access.Restaurant.Service
{
    [ApplicationManifest("IDesign.Microservice.Sales", "RestaurantAccess")]
    public class RestaurantAccess : ServiceBase, IRestaurantAccess
    {
        public RestaurantAccess(StatelessServiceContext context) : base(context)
        { }

        async Task<IEnumerable<Interface.Restaurant>> IRestaurantAccess.FilterAsync()
        {
            return new List<Interface.Restaurant>();
        }
        async Task IRestaurantAccess.StoreAsync()
        { }
    }
}
