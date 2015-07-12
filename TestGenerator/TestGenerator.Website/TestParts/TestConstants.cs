using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.TestParts
{
    public static class TestConstants
    {
        /* FILE SUMMARY */
        public const string Indentation = "    ";

        public const string SummaryStart = "/// <summary>";

        public const string SummaryEnd = "/// </summary>";

        public static readonly string OpenNamespace = string.Format(
            "namespace {0}{{{0}",
            Environment.NewLine);

        public static readonly string CloseNamespace = "}";

        public static readonly string UsingString = "{0}using System;{1}{0}using System.Collections.Generic;{1}{0}using System.Diagnostics.CodeAnalysis;{1}{0}using System.Linq;{1}" +
            "{0}using System.Text;{1}{0}using System.Threading.Tasks{1}{0}using Moq;{1}{0}using NUnit.Framework;{1}{1}";
        
        public static readonly string Usings = string.Format(
            UsingString,
            Indentation,
            Environment.NewLine);

        public static readonly string ClassSummary = string.Format(
            "{0}{1}{2}{0}/// Tests for the{2}{0}{3}{2}{0}[ExcludeFromCodeCoverage]{2}",
            Indentation,
            SummaryStart,
            Environment.NewLine,
            SummaryEnd);

        public static readonly string ClassDefinition = string.Format(
            "{0}public class {1}{0}{{{1}", 
            Indentation,
            Environment.NewLine);

        public static readonly string CloseClass = string.Format(
            "{0}}}{1}",
            Indentation,
            Environment.NewLine);
    }
}