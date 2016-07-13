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
        public List<NamespaceMetadata> Namespaces { get; set; } = new List<NamespaceMetadata>();
        private Assembly _assembly;

        public AssemblyReader(Assembly assembly)
        {
            _assembly = assembly;
        }

        public void Read()
        {
            var types = _assembly.GetTypes();

            foreach (var type in types)
            {
                string typeNamespace = type.Namespace;
                IncludeTypeInNamespace(type, typeNamespace);
            }
        }

        private void IncludeTypeInNamespace(Type type, string namespaceName)
        {
            var ns = Namespaces.FirstOrDefault(n => n.NamespaceName == namespaceName);
            if(ns == null)
            {
                ns = new NamespaceMetadata(namespaceName);
                Namespaces.Add(ns);
            }

            ns.AddType(type);
        }
    }
}
