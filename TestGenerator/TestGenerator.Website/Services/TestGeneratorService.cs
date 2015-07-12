using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestGenerator.Website.TestParts;

namespace TestGenerator.Website.Services
{
    public class TestGeneratorService
    {
        public string CreateTestFileStart(string typeOfClassToTest) 
        {
            var fileTop = string.Concat(
                TestConstants.OpenNamespace,
                TestConstants.Usings,
                TestConstants.ClassSummary,
                TestConstants.ClassDefinition);

            return string.Format(
                "{0}{1}{2}{3}{{{2}",
                fileTop,
                typeOfClassToTest,
                Environment.NewLine,
                TestConstants.Indentation);
        }

        public string CreateTestFileEnd()
        {
            return string.Concat(TestConstants.CloseClass + TestConstants.CloseNamespace);
        }

        public string CreateNullParamTest(string paramType, string parameters)
        {
            var testStart = string.Concat(NullParameter.Summary, NullParameter.TestDeclarationStart);

            var testDec = string.Format(
                "{0}{1}{2}",
                testStart,
                paramType,
                NullParameter.TestDeclarationEnd);

            return testDec;
        }
    }
}