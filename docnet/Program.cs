using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.MetadataReaders;
using docnet.Models;
using docnet.Renderers;

namespace docnet
{
    class Program
    {
        //const string path = @"C:\C5WorkingCopy\acrux\rc151468-fmwk\BibliotecasWeb\5.0\Consinco.Framework.dll";
        const string path = @"C:\C5WorkingCopy\tecnologia\rc151269\Framework\Source\Consinco.Framework\bin\Release\Consinco.Framework.dll";

        static void Main(string[] args)
        {

            try
            {
                var assembly = Assembly.LoadFrom(path);
                var reader = new AssemblyReader(assembly);
                reader.Read();

                var renderer = new TemplateRenderer();
                renderer.RenderAll(reader.Metadata);

                //foreach (var item in reader.Namespaces)
                //{
                //    //TODO: call generators/transformers/formatters (any name you want)
                //    Console.WriteLine($"NAMESPACE: {item.NamespaceName} - {item.HashId} - ({item.Types.Count} tipos)");

                //    foreach (var type in item.Types)
                //    {
                //        Console.WriteLine($"\t{type.TypeInfo.Name} - {item.HashId}");
                //    }
                //}
            }
            catch (ReflectionTypeLoadException ex)
            {
                Console.WriteLine(ex.LoaderExceptions.First().ToString());
            }


            
        }
    }
}
