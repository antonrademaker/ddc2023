using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IDesign.iFX.Service.Engines
{
    [DataContract]
    public class Response<T>
    {
        public Response(T result)
        {
            Result = result;
            Errors = Enumerable.Empty<ErrorInfo>();
        }

        public Response(IEnumerable<ErrorInfo> errors)
        {
            Result = default(T);
            Errors = errors;
        }
        [DataMember]
        public T Result { get; set; }
        [DataMember]
        public IEnumerable<ErrorInfo> Errors { get; set; }
    }
    [DataContract]

    public class ErrorInfo
    {
        public ErrorInfo(int code, string description) {
            Code = code;
            Description = description;
        }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
