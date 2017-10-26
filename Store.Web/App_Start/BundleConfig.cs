using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Store.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/bootstrap/css").Include("~/Content/bootstrap.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}