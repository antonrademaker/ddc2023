using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using IDesign.iFX.Service.Engines;
using ServiceModelEx;
using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace IDesign.Engine.Validation.Interface
{
   // [ServiceContract]
    public interface IValidationEngine : IService
    {

    }
}

namespace IDesign.Engine.Validation.Interface.Sales
{
    [ServiceContract]
    public interface IValidationEngine : IService
    {
        [OperationContract]
        Task<Response<bool>> ValidateAsync(ValidationCriteria criteria);
    }

    [DataContract]
    public class ValidationCriteria
    {
        public ValidationCriteria(string location)
        {
            Location = location;
        }
        [DataMember]
        public string Location { get; set; }
    }    
}
