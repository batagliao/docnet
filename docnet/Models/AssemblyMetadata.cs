using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docnet.Models
{
    public class AssemblyMetadata : MetadataBase
    {
        public List<NamespaceMetadata> Namespaces = new List<NamespaceMetadata>();
    }
}
