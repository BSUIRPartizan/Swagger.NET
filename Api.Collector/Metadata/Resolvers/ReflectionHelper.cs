using System;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace Api.Collector.Metadata.Resolvers
{
    public class ReflectionHelper : IReflectionHelper
    {
        public bool IsClass(Type type)
        {
            bool isSwaggerPrimitive;
            if (IsValueType(type))
                return false;
            
            GetSwaggerPrimitiveParameterType(type, out isSwaggerPrimitive);
            if (isSwaggerPrimitive)
            {
                return false;
            }

            return type.IsClass;
        }

        private bool IsValueType(Type type)
        {
            return InTypes(type, new Type[]{
                typeof(bool),
                typeof(byte),
                typeof(char),
                typeof(decimal),
                typeof(double),
//typeof(enum)
                typeof(float),
                typeof(int),
                typeof(long),
                typeof(sbyte),
                typeof(short),
//typeof(struct
                typeof(uint),
                typeof(ulong),
                typeof(ushort)});
        }

        private bool InTypes(Type type, Type[] types)
        {
            return types.Any(x => x == type);
        }

        public String GetSwaggerPrimitiveParameterType(Type type)
        {
            bool isSwaggerPrimitive;
            return GetSwaggerPrimitiveParameterType(type, out isSwaggerPrimitive);
        }

        public String GetSwaggerPrimitiveParameterType(Type type, out bool isSwaggerPrimitive)
        {
            isSwaggerPrimitive = false;
            if (type == typeof(Int32) || type == typeof(Int16) || type == typeof(Int64))
            {
                //return "integer";
                isSwaggerPrimitive = true;
                return "int";
            }

            if (type == typeof(String))
            {
                isSwaggerPrimitive = true;
                return "string";
            }

            //            throw new Exception(String.Format("Type is undefined. {0}", type.ToString()));
            return type.Name;

        }
    }
}