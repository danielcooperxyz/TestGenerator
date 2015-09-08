using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TestGenerator.Website
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                         "~/Scripts/jquery-{version}.min.js",
                         "~/Scripts/bootstrap.min.js",
                         "~/Scripts/prism.js",
                         "~/Scripts/Site.js"));
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                         "~/Content/*.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}