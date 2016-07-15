using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using docnet.Models;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace docnet.Renderers
{
    public class TemplateRenderer
    {
        public const string VIEW_ROOT = "Views";
        public const string OUT_DIR = "out";

        //private const string LAYOUT_TEMPLATE_KEY = "layout";
        //private const string ASSEMBLY_TEMPLATE_KEY = "assembly";
        //private const string NAMESPACE_TEMPLATE_KEY = "namespace";

        private const string LAYOUT_VIEW = "Layout.cshtml";
        private const string ASSEMBLY_VIEW = "Assembly.cshtml";
        private const string NAMESPACE_VIEW = "Namespace.cshtml";


        private IRazorEngineService _razorEngine;

        public TemplateRenderer()
        {
            var config = new TemplateServiceConfiguration();
            config.DisableTempFileLocking = true;
            config.Language = RazorEngine.Language.CSharp;
            config.TemplateManager = new ResolvePathTemplateManager(new string[] { VIEW_ROOT });

            _razorEngine = RazorEngineService.Create(config);
        }

        public void RenderAll(AssemblyMetadata metadata)
        {
            if (Directory.Exists(OUT_DIR))
            {
                //clean dir
                Parallel.ForEach(Directory.GetFiles(OUT_DIR), (file) => File.Delete(file));
            }
            else
            {
                Directory.CreateDirectory(OUT_DIR);
            }

            RenderAssembly(metadata);
        }

        private void RenderAssembly(AssemblyMetadata metadata)
        {
            string content = _razorEngine.RunCompile(GetTemplatePath(ASSEMBLY_VIEW), typeof(AssemblyMetadata), metadata);
            WriteContentToFile(content, metadata.LinkUrl);

            foreach (var item in metadata.Namespaces)
            {
                RenderNamespaces(item);
            }
        }

        private void RenderNamespaces(NamespaceMetadata metadata)
        {
            string content = _razorEngine.RunCompile(GetTemplatePath(NAMESPACE_VIEW), typeof(NamespaceMetadata), metadata);
            WriteContentToFile(content, metadata.LinkUrl);
        }

        private string GetTemplatePath(string templateName)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dir = Path.GetDirectoryName(path);
            dir = Path.Combine(dir, VIEW_ROOT);
            return Path.Combine(dir, templateName);
        }

        private void WriteContentToFile(string content, string hash)
        {
            

            string file = $"{Path.Combine(OUT_DIR, hash)}.htm";
            File.WriteAllText(file, content);
        }
    }
}
