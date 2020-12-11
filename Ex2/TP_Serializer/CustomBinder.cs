using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace TP_Serializer
{
    class CustomBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            return assembly.GetType(typeName);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            Assembly serializedTypeAssembly = serializedType.Assembly;
            assemblyName = serializedTypeAssembly.FullName;
            typeName = serializedType.FullName;

        }
    }
}
