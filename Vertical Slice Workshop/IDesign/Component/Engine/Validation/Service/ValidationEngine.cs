using System.Threading.Tasks;
using ServiceModelEx.ServiceFabric;

using IDesign.iFX.Service;
using MethodModelEx.Microservices;

using IDesign.Engine.Validation.Interface;
using IDesign.iFX.Service.Engines;
using System.Collections.Generic;

#if ServiceModelEx_ServiceFabric
using ServiceModelEx.Fabric;
#else
using System.Fabric;
#endif

namespace IDesign.Engine.Validation.Service
{
    [ApplicationManifest("IDesign.Microservice.Sales", "ValidationEngine")]
    public class ValidationEngine : ServiceBase, IValidationEngine, Interface.Sales.IValidationEngine
    {
        public ValidationEngine(StatelessServiceContext context) : base(context)
        { }

        async Task<Response<bool>> Interface.Sales.IValidationEngine.ValidateAsync(Interface.Sales.ValidationCriteria criteria)
        {
            if (string.IsNullOrWhiteSpace(criteria.Location))
            {
                var response = new Response<bool>(new List<ErrorInfo> { new ErrorInfo(1, "No location provided") });
                return response;
            }

            var noValidationErrors = new Response<bool>(true);
            return noValidationErrors;
        }
    }
}
