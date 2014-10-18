﻿using System;
using System.IO;
using Gopher.ImportExport.Parsers;
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

        [TestMethod]
        public void EccubeImport()
        {
            string inputFileName = @"F:\Projects\gopher-project\data\eccube.csv";
            string outputFileName = @"F:\Projects\gopher-project\data\output.csv";

            using (var input = new FileStream(inputFileName, FileMode.Open))
            using (var output = new FileStream(outputFileName, FileMode.Create))
            {
                var parser = new EccubeParser();
                parser.Parse(input, output);
            }
        }

        [TestMethod]
        public void TempoVisorImport()
        {
            string inputFileName = @"F:\Projects\gopher-project\data\tempo-visor.csv";
            string outputFileName = @"F:\Projects\gopher-project\data\output.csv";

            using (var input = new FileStream(inputFileName, FileMode.Open))
            using (var output = new FileStream(outputFileName, FileMode.Create))
            {
                var parser = new TempoVisorParser();
                parser.Parse(input, output);
            }
        }
    }
}
