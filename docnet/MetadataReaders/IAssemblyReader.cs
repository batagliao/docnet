using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.Models;

namespace docnet.MetadataReaders
{
    public interface IAssemblyReader
    {
        AssemblyMetadata Read(Assembly assembly);
    }
}
