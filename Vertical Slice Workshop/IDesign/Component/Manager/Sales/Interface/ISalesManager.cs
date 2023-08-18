using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace IDesign.Manager.Sales.Interface
{
   [ServiceContract]
   public interface ISalesManager : IService
   {
      [OperationContract]
      Task FindItemAsync(FindItemRequest findItemRequest);
   }
    [DataContract]
    public class FindItemRequest
    {
        public FindItemRequest(string location)
        {
            Location = location;
        }
        [DataMember]
        public string Location { get; set; }
    }
}
