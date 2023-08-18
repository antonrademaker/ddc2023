﻿using System.ServiceModel;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace IDesign.Engine.Validation.Interface
{
   [ServiceContract]
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
        Task ValidateAsync();
    }
}
