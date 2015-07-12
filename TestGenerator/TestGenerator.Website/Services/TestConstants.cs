using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.Services
{
    public static class TestConstants
    {
        /* FILE SUMMARY */
        public const string Indentation = "    ";

        private static readonly string OpenNamespace = string.Format("namespace {0}{{{0}", Environment.NewLine);
        private static readonly string CloseNamespace = "}";

        private static readonly string Usings = string.Format(
            "{0}using System;{1}{0}using System.Collections.Generic;{1}{0}using System.Diagnostics.CodeAnalysis;{1}{0}using System.Linq;{1}" +
            "{0}using System.Text;{1}{0}using System.Threading.Tasks{1}{0}using Moq;{1}{0}using NUnit.Framework;{1}{1}",
            Indentation,
            Environment.NewLine);

        private static readonly string ClassSummary = string.Format(
        "{0}/// <summary>{1}{0}/// Tests for the{1}{0}/// </summary>{1}{0}[ExcludeFromCodeCoverage]{1}",
        Indentation,
        Environment.NewLine);

        private static readonly string ClassDefinition = string.Format("{0}public class {1}{0}{{{1}", Indentation, Environment.NewLine);
        private static readonly string CloseClass = string.Format("{0}}}{1}", Indentation, Environment.NewLine);

        public static readonly string FileTop = OpenNamespace + Usings + ClassSummary + ClassDefinition;
        public static readonly string FileBottom = CloseClass + CloseNamespace;

        /* METHOD SUMMARY */
        public static readonly string SummaryStart = string.Format("{0}/// <summary>{1}{0}/// Test that the ", Indentation + Indentation, Environment.NewLine);

        public static readonly string SUMMARY_END = string.Format(" field is get and set correctly{0}{1}/// </summary>{0}", Environment.NewLine, Indentation + Indentation);
        public static readonly string TEST_DEC_START = Indentation + Indentation + "[Test]\n" + Indentation + Indentation + "public void ";
        public static string TEST_DEC_END = "_GetAndSet_WorksCorrectly()\n" + Indentation + Indentation + "{\n\n" + Indentation + Indentation + "}\n\n";
    }
}