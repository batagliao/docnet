using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.Infrastructure;
using docnet.MetadataReaders;
using docnet.Models;
using docnet.Renderers;
using DryIoc;

namespace docnet
{
    class Program
    {
        // documentation for xmlDoc
        // https://msdn.microsoft.com/en-us/library/fsbx0t7x(v=vs.140).aspx

        //const string path = @"C:\C5WorkingCopy\acrux\rc151468-fmwk\BibliotecasWeb\5.0\Consinco.Framework.dll";
        const string path = @"C:\C5WorkingCopy\tecnologia\rc151269\Framework\Source\Consinco.Framework\bin\Release\Consinco.Framework.dll";

        static void Main(string[] args)
        {
            Bootstrap.WireThingsUp();

            //TODO: create assembly loader
            var assembly = Assembly.LoadFrom(path);
            var reader = Bootstrap.Container.Resolve<IAssemblyReader>();
            var assemblyMeta = reader.Read(assembly);

            var renderer = new TemplateRenderer();
            renderer.RenderAll(assemblyMeta);
        }
    }
}
