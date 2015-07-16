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
                Components.OpenNamespace,
                Components.Usings,
                Components.ClassSummary,
                Components.ClassDefinition);

            return string.Format(
                "{0}{1}{2}{3}{{{2}",
                fileTop,
                typeOfClassToTest,
                Environment.NewLine,
                Components.Indentation);
        }

        public string CreateParameters(IDictionary<string, string> parameters)
        {
            var parameterDefinitions = "";
            
            foreach (var kp in parameters)
            {
                var summaryText = string.Format(
                    "The <see cref=\"{0}\"/> to use during tests",
                    kp.Key);


                var definition = string.Format(
                    "{0}private readonly {1} {2};",
                    Components.GetIndents(2),
                    kp.Key,
                    kp.Value);

                parameterDefinitions += string.Format(
                    "{0}{1}{2}{1}{1}",
                    Components.CreateSummary(summaryText),
                    Environment.NewLine,
                    definition);
            }

            return parameterDefinitions;
        }

        public string CreateTestFileEnd()
        {
            return string.Concat(Components.CloseClass + Components.CloseNamespace);
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

        public string CreateSetup(IDictionary<string,string> parameters)
        {
            var summary = Components.CreateSummary("Setup objects for use during tests.");

            var methodDec = string.Format(
                "{0}{1}{2}{0}public void Setup(){2}{0}{{{2}",
                Components.GetIndents(2),
                Components.SetupAttr,
                Environment.NewLine);

            var inits = "";

            foreach (var kp in parameters)
            {
                inits += string.Format(
                    "{0}this.{1} = new Mock<{2}>().Object;{3}",
                    Components.GetIndents(3),
                    kp.Value,
                    kp.Key,
                    Environment.NewLine);
            }

            return string.Format(
            "{0}{1}{2}{3}}}{3}",
            summary,
            methodDec,
            inits,
            Environment.NewLine);
        }

        public string CreateGetInstance(string typeToTest, ICollection<string> parameterNames)
        {
            var summary = Components.CreateSummary("Create an instance to test.");

            var methodDec = string.Format(
                "{0}private {1} GetInstance(){2}{0}{{{2}",
                Components.GetIndents(2),
                typeToTest,
                Environment.NewLine);

            var parametersToUse = "";

            foreach (var p in parameterNames)
            {
                parametersToUse += string.Format(
                    "this.{0},{1}",
                    p,
                    Environment.NewLine);
            }

            var inner = string.Format(
                "return new {0}({1}{2});",
                typeToTest,
                Environment.NewLine,
                parametersToUse);

            return string.Format(
                "{0}{1}{2}{3}}}{3}",
                summary,
                methodDec,
                inner,
                Environment.NewLine);
        }
    }
}