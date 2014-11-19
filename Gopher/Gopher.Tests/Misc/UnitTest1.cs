using System;
using System.IO;
using Gopher.ImportExport;
using Gopher.ImportExport.Domain;
using Gopher.ImportExport.Parsers;
using Gopher.ImportExport.Tools;
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

        [TestMethod]
        public void AutomaticImportTempoVisor()
        {
            string inputFileName = @"F:\Projects\gopher-project\data\tempo-visor.csv";
            string outputFileName = @"F:\Projects\gopher-project\data\output.csv";

            using (var input = new FileStream(inputFileName, FileMode.Open))
            using (var output = new FileStream(outputFileName, FileMode.Create))
            {
                Import.GenerateBulkInsertFile(input, output);
            }

        }

        [TestMethod]
        public void AutomaticImportEccube()
        {
            string inputFileName = @"F:\Projects\gopher-project\data\eccube.csv";
            string outputFileName = @"F:\Projects\gopher-project\data\output.csv";

            using (var input = new FileStream(inputFileName, FileMode.Open))
            using (var output = new FileStream(outputFileName, FileMode.Create))
            {
                Import.GenerateBulkInsertFile(input, output);
            }

        }

        [TestMethod]
        public void MergeIntoSingleColumn()
        {
            string[] array = {
                 "a",
                 "b",
                 "c",
                 "d",
                 "e",
                 "f"
            };

            string expected = "c d e";

            string actual = Format.MergeIntoString(array, 2, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNullableEnum_ExistingValue()
        {
            string value = "1";

            Sex? expected = Sex.Male;

            Sex? actual = Format.GetNullableEnum<Sex>(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNullableEnum_MissingValue()
        {
            string value = "";

            Sex? actual = Format.GetNullableEnum<Sex>(value);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void HalfKana_ToFullKana_Works()
        {
            string half = "ﾆｯﾎﾟﾝ";
            string full = "ニッポン";

            string actual = KanaHelper.ToFullKana(half);

            Assert.AreEqual(full, actual);
        }
    }
}
