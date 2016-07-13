using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docnet.Models
{
    public class NamespaceMetadata : MetadataBase
    {
        public string NamespaceName { get; set; }

        //TODO: agroup hierarchical namespaces

        //TODO: join with doc.xml
        //Namespaces has ///summary and ///remarks

        public List<TypeMetadata> Types { get; set; }

        public NamespaceMetadata(string name)
        {
            NamespaceName = name;
            Types = new List<TypeMetadata>();
        }

        public TypeMetadata AddType(Type type)
        {
            TypeMetadata metadata = new TypeMetadata(type);
            Types.Add(metadata);
            return metadata;
        }

    }
}
