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
        Task<IEnumerable<Restaurant>> FilterAsync();
        [OperationContract]
        Task StoreAsync();
    }

    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int Rating { get; set; }
    }

}
