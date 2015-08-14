using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.TestParts
{
    public static class Components
    {
        /* FILE SUMMARY */
        public const string Indentation = "    ";
        public const string SummaryStart = "/// <summary>";
        public const string SummaryMid = "/// ";
        public const string SummaryEnd = "/// </summary>";
        public const string ReturnsOpen = "/// <returns>";
        public const string ReturnsClose = "</returns>";
        public const string TestAttr = "[Test]";
        public const string SetupAttr = "[SetUp]";

        /* FILE PARTS */
        public static readonly string OpenNamespace = string.Format(
            "namespace {0}{{{0}",
            Environment.NewLine);

        public static readonly string CloseNamespace = "}";

        public static readonly string UsingString = "{0}using System;{1}{0}using System.Collections.Generic;{1}{0}using System.Diagnostics.CodeAnalysis;{1}{0}using System.Linq;{1}" +
            "{0}using System.Text;{1}{0}using System.Threading.Tasks;{1}{0}using Moq;{1}{0}using NUnit.Framework;{1}{1}";
        
        public static readonly string Usings = string.Format(
            UsingString,
            Indentation,
            Environment.NewLine);

        public static readonly string ClassDefinition = string.Format(
            "{0}[ExcludeFromCodeCoverage]{1}{0}public class ", 
            Indentation,
            Environment.NewLine);

        public static readonly string CloseClass = string.Format(
            "{0}}}{1}",
            Indentation,
            Environment.NewLine);

        public static string GetIndents(int number)
        {
            var indents = "";

            for (int i = 0; i < number; i++)
            {
                indents += Indentation;
            }

            return indents;
        }

        public static string CreateSummary(string summaryText, int numberOfIndents, string returns = null)
        {
            var summary = string.Format(
                    "{0}{1}{2}{0}{3}{4}{2}{0}{5}{2}",
                    Components.GetIndents(numberOfIndents),
                    Components.SummaryStart,
                    Environment.NewLine,
                    Components.SummaryMid,
                    summaryText,
                    Components.SummaryEnd);

            if (!string.IsNullOrEmpty(returns))
            {
                summary = string.Format("{0}{1}", summary, CreateReturns(returns, numberOfIndents));
            }

            return summary;
        }

        private static string CreateReturns(string returnsText, int numberOfIndents)
        {
            return string.Format("{0}{1}{2}{3}{4}",
                Components.GetIndents(numberOfIndents),
                ReturnsOpen,
                returnsText,
                ReturnsClose,
                Environment.NewLine);
        }
    }
}