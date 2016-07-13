using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.Extensions;

namespace docnet.Models
{
    public class TypeMetadata : MetadataBase
    {
        private Type type;

        public TypeCategoryEnum Category { get; set; }

        public TypeMetadata(Type type)
        {
            this.type = type;
            TypeInfo = type.GetTypeInfo();
            Category = type.GetCategory();
        }

        public TypeInfo TypeInfo { get; set; }

        
    }

}
