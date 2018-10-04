﻿using System.Web;
using System.Web.Optimization;

namespace SimpleMVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js").Include("~/Scripts/jquery-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery", "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.4.js").Include("~/Scripts/jquery-{version}.js"));

            //<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css").Include("~/Content/bootstrap.css"));

            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;

            bundles.Add(new StyleBundle("~/Content/font-awesome", "http://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}