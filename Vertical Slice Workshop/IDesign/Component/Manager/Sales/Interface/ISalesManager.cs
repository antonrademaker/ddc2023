using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace IDesign.Manager.Sales.Interface.Online
{
    [ServiceContract]
    public interface ISalesManager : IService
    {
        [OperationContract]
        Task SearchAsync(SearchCriteria searchCriteria);
    }
    [DataContract]
    public class SearchCriteria : SearchCriteriaBase
    {
        public SearchCriteria(string location)
        {
            Location = location;
        }

        [DataMember]
        public string Location { get; set; }
    }

    public abstract class SearchCriteriaBase
    {

    }
}

namespace IDesign.Manager.Sales.Interface.Restaurant
{
    [ServiceContract]
    public interface ISalesManager : IService
    {
        [OperationContract]
        Task SearchAsync(SearchCriteria searchCriteria);
    }

    [DataContract]
    public class SearchCriteria : SearchCriteriaBase
    {
        public SearchCriteria(string term)
        {
            Term = term;
        }

        [DataMember]
        public string Term { get; }
    }

    public abstract class SearchCriteriaBase
    {

    }
}
