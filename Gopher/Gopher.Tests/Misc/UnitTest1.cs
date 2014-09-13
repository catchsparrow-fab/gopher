using System;
using Gopher.Model.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gopher.Tests.Misc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int value = 1;
            string language = LanguageHelper.GetLanguageName(value);
            Assert.Inconclusive(language);
        }
    }
}
