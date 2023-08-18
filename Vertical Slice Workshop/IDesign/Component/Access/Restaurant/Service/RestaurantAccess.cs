using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Access.Restaurant.Interface;
using System.Collections;
using System.Collections.Generic;
using System;

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

        async Task<Interface.Restaurant[]> IRestaurantAccess.FilterAsync(RestaurantCriteria criteria)
        {
            if (criteria.RestaurantIDs != null && criteria.RestaurantIDs.Length > 0)
            {
                return new Interface.Restaurant[] { 
                    new Interface.Restaurant() {
                    Id = criteria.RestaurantIDs[0],
                    Name = "Brisket",
                    Location = new Location()
                }
                };
            }
            return Array.Empty<Interface.Restaurant>();
        }
        async Task IRestaurantAccess.StoreAsync()
        { }
    }
}
