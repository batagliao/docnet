using System;
using docnet.Extensions;
using docnet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace docnet.tests.Extensions
{
    [TestClass]
    public class TypeExtensionsTest
    {
        #region Types for test
        class TestClass { }

        interface TestInterface { }

        enum TestEnum { }

        struct TestStruct { }

        delegate void TestDelegate();
        #endregion

        [TestMethod]
        public void GetCategoryTest()
        {
            var type = typeof(TestClass);
            Assert.AreEqual(TypeCategoryEnum.Class, type.GetCategory());

            type = typeof(TestInterface);
            Assert.AreEqual(TypeCategoryEnum.Interface, type.GetCategory());

            type = typeof(TestEnum);
            Assert.AreEqual(TypeCategoryEnum.Enumeration, type.GetCategory());

            type = typeof(TestStruct);
            Assert.AreEqual(TypeCategoryEnum.Strucutre, type.GetCategory());

            type = typeof(TestDelegate);
            Assert.AreEqual(TypeCategoryEnum.Delegate, type.GetCategory());
        }
    }
}
