using System.Runtime.Serialization;

namespace Api.Collector.Tests.Models
{
    [DataContract]
    public class SimpleResult<T>
    {
        public SimpleResult()
        {
        }

        public SimpleResult(T data)
        {
            Data = data;
        }

        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
}
