using System;
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
        Task<Restaurant[]> FilterAsync(RestaurantCriteria criteria);
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

        public RestaurantCriteria(Guid[] restaurantIDs)
        {
            RestaurantIDs = restaurantIDs;
        }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public Guid[] RestaurantIDs { get; set; }
    }

    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Location Location { get; set; }

        [DataMember]
        public OpeningHours OpeningHours { get; set; }

        [DataMember]
        public CuisineTypes CuisineTypes { get; set; }

        [DataMember]
        public SupportedFeatures SupportedFeatures { get; set; }

    }

    [DataContract]
    public class SupportedFeatures
    {
        public bool Delivery { get; set; }
        public bool Pickup { get; set; }
        public bool Vouchers { get; set; }
        public bool StampCards { get; set; }
        public bool Discounts { get; set; }
    }
    [DataContract]
    public class OpeningHours
    {
        // to do
    }
    [DataContract]
    public class CuisineTypes
    {
        // to do
    }


    [DataContract]
    public class Location
    {
        [DataMember]
        public string StreetAddress { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Lng { get; set; }

        [DataMember]
        public string TimeZone { get; set; }
    }
}
