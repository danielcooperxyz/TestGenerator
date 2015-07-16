using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.TestParts
{
    public class NullParameter
    {
        /* METHOD SUMMARY */
        public static readonly string Summary = Components.CreateSummary(
            "Test that the constructor throws an exception when passed a null parameter");

        public static readonly string TestDeclarationStart = string.Format(
            "{0}[Test]{1}{0}public void Constructor_Null",
            Components.GetIndents(2),
            Environment.NewLine);

        public static readonly string TestDeclarationEnd = string.Format(
            "_ThrowsException(){0}{1}{{{0}",
            Environment.NewLine,
            Components.GetIndents(2));

        public static readonly string TestStart = string.Format(
            "{0}Assert.Throws<ArgumentNullException>(() => { this.",
            Components.GetIndents(3));

        public static readonly string TestMiddle = " = new ";

        public static readonly string TestEnd = string.Format(
            "); });{0}{1}}}{0}{0}",
            Environment.NewLine,
            Components.GetIndents(2));
    }
}