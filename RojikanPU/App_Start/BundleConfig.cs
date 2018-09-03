﻿using System.Web;
using System.Web.Optimization;

namespace RojikanPU
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/thirdparty").Include(
                        "~/Scripts/bootstrap-treeview.min.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                        "~/Scripts/smartmenus/jquery.smartmenus.min.js",
                        "~/Scripts/smartmenus/addons/bootstrap/jquery.smartmenus.bootstrap.js",
                        "~/Scripts/Chart.min.js",
                        "~/Scripts/bootstrap-multiselect/js/bootstrap-multiselect.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Scripts/bootstrap-dropdown/css/animate.css",
                      "~/Scripts/bootstrap-dropdown/css/bootstrap-dropdownhover.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Scripts/smartmenus/addons/bootstrap/jquery.smartmenus.bootstrap.css",
                      "~/Scripts/bootstrap-multiselect/css/bootstrap-multiselect.css"));
        }
    }
}
