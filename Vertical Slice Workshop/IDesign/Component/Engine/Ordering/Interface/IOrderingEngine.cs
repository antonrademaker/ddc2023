using System.ServiceModel;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace IDesign.Engine.Ordering.Interface.Ordering
{
    [ServiceContract]
    public interface IOrderingEngine : IService
    {
        [OperationContract]
        Task MatchAsync();
    }
}

namespace IDesign.Engine.Ordering.Interface.Menuing
{
    [ServiceContract]
    public interface IMenuingEngine : IService
    {
        [OperationContract]

        Task MatchAsync();
    }
}