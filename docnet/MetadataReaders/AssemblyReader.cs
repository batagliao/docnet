using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.Models;

namespace docnet.MetadataReaders
{
    public class AssemblyReader
    {
        public AssemblyMetadata Metadata = null;
        private Assembly _assembly;

        public AssemblyReader(Assembly assembly)
        {
            _assembly = assembly;
        }

        public void Read()
        {
            Metadata = new AssemblyMetadata();

            var types = _assembly.GetTypes();

            foreach (var type in types)
            {
                string typeNamespace = type.Namespace;
                //TODO: ReadType
                IncludeTypeInNamespace(type, typeNamespace);

            }
        }

        private void IncludeTypeInNamespace(Type type, string namespaceName)
        {
            var ns = Metadata.Namespaces.FirstOrDefault(n => n.NamespaceName == namespaceName);
            if(ns == null)
            {
                ns = new NamespaceMetadata(namespaceName);
                Metadata.Namespaces.Add(ns);
            }

            ns.AddType(type);
        }
    }
}
