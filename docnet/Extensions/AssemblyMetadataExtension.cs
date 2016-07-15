using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using docnet.Models;

namespace docnet.Extensions
{
    public static class AssemblyMetadataExtension
    {
        public static void IncludeTypeInNamespace(this AssemblyMetadata metadata, Type type, string namespaceName)
        {

            var ns = metadata.Namespaces.FirstOrDefault(n => n.NamespaceName == namespaceName);
            if (ns == null)
            {
                //call namespace reader
                ns = new NamespaceMetadata(namespaceName);
                metadata.Namespaces.Add(ns);
            }

            ns.AddType(type);
        }
    }
}
