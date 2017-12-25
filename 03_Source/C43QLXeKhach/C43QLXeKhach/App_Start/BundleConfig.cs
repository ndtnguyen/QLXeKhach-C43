﻿using System.Web;
using System.Web.Optimization;

namespace C43QLXeKhach
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/datePicker").Include(
           "~/Scripts/moment.min.js",
           "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                     "~/Content/bootstrap-datetimepicker.min.css"));
            //datatable
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                     "~/Content/datatables/dataTables.bootstrap4.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
           "~/Scripts/datatables/jquery.dataTables.js",
           "~/Scripts/datatables/dataTables.bootstrap4.js",
           "~/Scripts/datatables/sb-admin-datatables.min.js"));
            //select
            bundles.Add(new StyleBundle("~/Content/select").Include(
                     "~/Content/select/bootstrap-select.css"));
            bundles.Add(new ScriptBundle("~/bundles/select").Include(
           "~/Scripts/select/bootstrap-select.js"));
        }
    }
}
