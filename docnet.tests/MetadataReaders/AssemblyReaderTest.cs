using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.MetadataReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace docnet.tests.MetadataReaders
{
    [TestClass]
    public class AssemblyReaderTest
    {
        [TestMethod]
        public void ReadTest()
        {
            var assembly = Assembly.GetExecutingAssembly();
            IAssemblyReader reader = new AssemblyReader();
            var metadata = reader.Read(assembly);
            Assert.AreEqual(assembly.GetName().Name, metadata.AssemblyName);
            Assert.IsTrue(metadata.Namespaces.Count > 0);
        }
    }
}
