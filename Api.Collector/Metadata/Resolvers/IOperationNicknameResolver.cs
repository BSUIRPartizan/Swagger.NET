using System;
using System.Collections.Generic;
using System.Reflection;
using Api.Collector.Metadata.Models;

namespace Api.Collector.Metadata.Resolvers
{
    public interface IOperationNicknameResolver
    {
        string GetOperationNickname(Type type, MethodInfo method, List<MetaDataOperationParameter> parameters);
    }
}