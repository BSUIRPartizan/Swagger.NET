﻿using System.Runtime.Serialization;

namespace Api.Collector.Tests.Models
{
    [DataContract]
    public class ApiResponseWrapper<T>
    {
        [DataMember(Name = "data")]
        public T Data { get; set; }

        [DataMember(Name = "metadata")]
        public ApiResponseMetadata Metadata { get; set; }
    }
}