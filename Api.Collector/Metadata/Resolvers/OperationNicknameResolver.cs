using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Api.Collector.Metadata.Models;

namespace Api.Collector.Metadata.Resolvers
{
    public class OperationNicknameResolver : IOperationNicknameResolver
    {
        private Dictionary<Type, Dictionary<string, int>> uniqueNicknameMetric;

        public OperationNicknameResolver()
        {
            uniqueNicknameMetric = new Dictionary<Type, Dictionary<string, int>>();
        }

        public String GetOperationNickname(Type type, MethodInfo method, List<MetaDataOperationParameter> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return GetUniqueNickName(type, String.Format("{0}_{1}", type.Name, method.Name));
            
            var nickName = GetNickname(type, method ,parameters);
            return GetUniqueNickName(type, nickName);
        }

        private string GetUniqueNickName(Type type, string nickName)
        {
            int counterMetric = UpdateNicknameUniqueMertic(type, nickName);
            if (counterMetric == 1)
            {
                return nickName;
            }

            return String.Format("{0}_{1}", nickName, counterMetric);
        }

        private int UpdateNicknameUniqueMertic(Type type,  string nickName)
        {
            if (!uniqueNicknameMetric.ContainsKey(type))
            {
                uniqueNicknameMetric.Add(type, new Dictionary<String, int>());
            }
            
            if (!uniqueNicknameMetric[type].ContainsKey(nickName))
            {
                uniqueNicknameMetric[type].Add(nickName, 1);
            }
            else
            {
                uniqueNicknameMetric[type][nickName] = uniqueNicknameMetric[type][nickName]+1;
            }

            return uniqueNicknameMetric[type][nickName];
        }

        private string GetNickname(Type type, MethodInfo method, List<MetaDataOperationParameter> parameters)
        {
            return String.Format("{0}_{1}_{2}", type.Name, method.Name, GetNicknamePostfix(parameters));
        }

        private String GetNicknamePostfix(IEnumerable<MetaDataOperationParameter> parameters)
        {
            var stringBuilder = new StringBuilder();
            foreach (MetaDataOperationParameter metaDataOperationParameter in parameters)
            {
                stringBuilder.Append(GetParameterName(metaDataOperationParameter.Name));
            }

            return stringBuilder.ToString();
        }

        private String GetParameterName(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1);
        }
    }
}