using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;

namespace docnet.Renderers
{
    public class FileSystemTemplateManager : ITemplateManager
    {
        private IRazorEngineService _razorservice = null;
        public FileSystemTemplateManager(IRazorEngineService razorservice)
        {
            _razorservice = razorservice;
        }

        public const string VIEW_ROOT = "Views";
        public void AddDynamic(ITemplateKey key, ITemplateSource source)
        {
            Debugger.Launch();

            // You can disable dynamic templates completely. 
            // This just means all convenience methods (Compile and RunCompile) with
            // a TemplateSource will no longer work (they are not really needed anyway).
            throw new NotImplementedException("dynamic templates are not supported!");
        }

        public ITemplateKey GetKey(string name, ResolveType resolveType, ITemplateKey context)
        {
            // If you can have different templates with the same name depending on the 
            // context or the resolveType you need your own implementation here!
            // Otherwise you can just use NameOnlyTemplateKey.
            return new NameOnlyTemplateKey(name, resolveType, context);
            // template is specified by full path
            //return new FullPathTemplateKey(name, fullPath, resolveType, context);
        }

        public ITemplateSource Resolve(ITemplateKey key)
        {
            string file = Path.Combine(VIEW_ROOT, key.Name);
            string template = File.ReadAllText(file);

            // Resolve your template here (ie read from disk)
            // if the same templates are often read from disk you propably want to do some caching here.
            //string template = "Hello @Model.Name, welcome to RazorEngine!";
            // Provide a non-null file to improve debugging
            return new LoadedTemplateSource(template, file);
        }
    }
}
