using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using docnet.MetadataReaders;
using DryIoc;

namespace docnet.Infrastructure
{
    public static class Bootstrap
    {
        public static Container @Container { get; } = new Container();

        public static void WireThingsUp()
        {
            @Container.Register<IAssemblyReader, AssemblyReader>(Reuse.InThread);
            @Container.Register<INamespaceReader, NamespaceReader>(Reuse.InThread);
        }
    }
}
