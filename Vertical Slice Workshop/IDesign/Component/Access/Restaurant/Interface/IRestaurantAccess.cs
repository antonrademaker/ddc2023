using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace IDesign.Access.Restaurant.Interface
{
    [ServiceContract]
    public interface IRestaurantAccess : IService
    {
        [OperationContract]
        Task<IEnumerable<Restaurant>> FilterAsync(RestaurantCriteria criteria);
        [OperationContract]
        Task StoreAsync();
    }

    [DataContract]
    public class RestaurantCriteria
    {
        public RestaurantCriteria(string location)
        {
            Location = location;
        }
        [DataMember]
        public string Location { get; set; }
    }

    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}
