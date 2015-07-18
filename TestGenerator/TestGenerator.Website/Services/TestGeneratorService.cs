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
            var summaryText = string.Format("Tests for the <see cref=\"{0}\"/> class.",
                typeOfClassToTest);

            var fileTop = string.Concat(
                Components.OpenNamespace,
                Components.Usings,
                Components.CreateSummary(summaryText, 1),
                Components.ClassDefinition);

            return string.Format(
                "{0}{1}Test{2}{3}{{{2}",
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
                    "{0}private {1} {2};",
                    Components.GetIndents(2),
                    kp.Key,
                    kp.Value);

                parameterDefinitions += string.Format(
                    "{0}{1}{2}{2}",
                    Components.CreateSummary(summaryText, 2),
                    definition,
                    Environment.NewLine);
            }

            return parameterDefinitions;
        }

        public string CreateTestFileEnd()
        {
            return string.Concat(Components.CloseClass + Components.CloseNamespace);
        }

        public string CreateSetup(IDictionary<string,string> parameters)
        {
            var summary = Components.CreateSummary("Setup objects for use during tests.", 2);

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
            "{0}{1}{2}{3}}}{4}{4}",
            summary,
            methodDec,
            inits,
            Components.GetIndents(2),
            Environment.NewLine);
        }

        public string CreateGetInstance(string typeToTest, IList<string> parameterNames)
        {
            var summary = Components.CreateSummary("Create an instance to test.", 2);

            var methodDec = string.Format(
                "{0}private {1} GetInstance(){2}{0}{{{2}",
                Components.GetIndents(2),
                typeToTest,
                Environment.NewLine);

            var parametersToUse = "";

            for (int i = 0; i < parameterNames.Count; i++)
            {
                var param = string.Format(
                    "{0}this.{1}",
                    Components.GetIndents(4),
                    parameterNames[i]);

                if (i < parameterNames.Count - 1)
                {
                    param = string.Concat(param, ",", Environment.NewLine);
                }

                parametersToUse += param;
            }
            
            var inner = string.Format(
                "{0}return new {1}({2}{3});",
                Components.GetIndents(3),
                typeToTest,
                Environment.NewLine,
                parametersToUse);

            return string.Format(
                "{0}{1}{2}{3}{4}}}{3}",
                summary,
                methodDec,
                inner,
                Environment.NewLine,
                Components.GetIndents(2));
        }

        public string CreateNullParamTests(IDictionary<string, string> parameters)
        {
            var tests = "";

            foreach (var kp in parameters)
            {
                tests += string.Concat(CreateNullParamTest(kp), Environment.NewLine, Environment.NewLine);
            }

            return tests;
        }

        private string CreateNullParamTest(KeyValuePair<string, string> parameter)
        {
            var testStart = string.Concat(NullParameter.Summary, NullParameter.TestDeclarationStart);

            var testDec = string.Format(
                "{0}{1}{2}",
                testStart,
                parameter.Key,
                NullParameter.TestDeclarationEnd);

            var inner = string.Format(
                "{0}this.{1} = null;{2}{0}Assert.Throws<ArgumentNullException>(() => {{ this.GetInstance(); }});{2}",
                Components.GetIndents(3),
                parameter.Value,
                Environment.NewLine);

            return string.Format(
                "{0}{1}{2}}}",
                testDec,
                inner,
                Components.GetIndents(2));
        }
    }
}