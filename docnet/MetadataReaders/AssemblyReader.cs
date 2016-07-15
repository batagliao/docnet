using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.Extensions;
using docnet.Models;

namespace docnet.MetadataReaders
{
    public class AssemblyReader : IAssemblyReader
    {
        public AssemblyMetadata Read(Assembly assembly)
        {
            var metadata = new AssemblyMetadata();
            metadata.AssemblyName = assembly.GetName().Name;

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                string typeNamespace = type.Namespace;
                metadata.IncludeTypeInNamespace(type, typeNamespace);
                //TODO: read namespace
            }
            return metadata;
        }

        
    }
}
