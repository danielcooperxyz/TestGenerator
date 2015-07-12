using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.TestParts
{
    public class NullParameter
    {
        /* METHOD SUMMARY */
        private static readonly string TwoIndentations = string.Concat(
            TestConstants.Indentation,
            TestConstants.Indentation);

        public static readonly string Summary = string.Format(
            "{0}{1}{2}{0}/// Test that the constructor throws an exception when passed a null parameter{2}{0}{3}{2}",
            TwoIndentations,
            TestConstants.SummaryStart,
            Environment.NewLine,
            TestConstants.SummaryEnd);

        public static readonly string TestDeclarationStart = string.Format(
            "{0}[Test]{1}{0}public void Constructor_Null",
            TwoIndentations,
            Environment.NewLine);

        public static readonly string TestDeclarationEnd = string.Format(
            "_ThrowsException(){0}{1}{{{0}",
            Environment.NewLine,
            TwoIndentations);

        private static readonly string ThreeIndentations = string.Concat(
            TwoIndentations, 
            TestConstants.Indentation);

        public static readonly string TestStart = string.Format(
            "{0}Assert.Throws<ArgumentNullException>(() => { this.",
            ThreeIndentations);

        public static readonly string TestMiddle = " = new ";

        public static readonly string TestEnd = string.Format(
            "); });{0}{1}}}{0}{0}",
            Environment.NewLine, 
            TwoIndentations);
    }
}