using System.Collections.Generic;
using System.Web.Optimization;

namespace Jack.Presentation.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/basic").Include("~/Content/Jack.css", 
                                                                   "~/Content/bootstrap.min.css", 
                                                                   "~/Content/bootstrap-theme.min.css",
                                                                   "~/Content/toastr.min.css"));
            //all
            bundles.Add(new ScriptBundle("~/bundles/basic").Include("~/Scripts/jquery-{version}.js", 
                                                                    "~/Scripts/toastr.min.js", 
                                                                    "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.min.js"));

            //pages
            bundles.Add(new ScriptBundle("~/bundles/engine").Include("~/engine/geral/mensagens.js", 
                                                                     "~/engine/geral/util.js"));

            bundles.Add(new ScriptBundle("~/bundles/familia").Include("~/engine/familia/familia.js", 
                                                                      "~/engine/familia/familia.controller.js", 
                                                                      "~/engine/familia/familia.presentation.js"));

            bundles.Add(new ScriptBundle("~/bundles/familiacrianca").Include("~/engine/familia/familia.js", 
                                                                             "~/engine/familiacrianca/familiacrianca.js", 
                                                                             "~/engine/familiacrianca/familiacrianca.controller.js", 
                                                                             "~/engine/familiacrianca/familiafamiliacrianca.presentation.js"));
            bundles.Add(new ScriptBundle("~/bundles/status").Include("~/engine/geral/status.js"));

            bundles.Add(new ScriptBundle("~/bundles/util").Include("~/engine/geral/util.js"));

            bundles.Add(new ScriptBundle("~/bundles/chamada").Include("~/engine/chamada/chamada.js",
                                                                      "~/engine/chamada/chamada.controller.js", 
                                                                      "~/engine/chamada/chamada.presentation.js"));

            bundles.Add(new ScriptBundle("~/bundles/reuniao").Include("~/engine/reuniao/reuniao.js"));


            //// Adicionando jQuery
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //// Adicionando Validação, e Globalização
            //// Utilizando ordenação manual
            //var valBundle = new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.validate.js",
            //    "~/Scripts/globalize.js",
            //    "~/Scripts/jquery.validate.globalize.js");

            //valBundle.Orderer = new AsIsBundleOrderer();

            //bundles.Add(valBundle);
        }

    }
}

public class AsIsBundleOrderer : IBundleOrderer
{
    public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
    {
        return files;
    }
}