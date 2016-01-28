using System.Web.Optimization;

namespace Jack.Presentation.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Basic").Include("~/Content/Jack.css", "~/Content/bootstrap.min.css", "~/Content/bootstrap-theme.min.css", "~/Content/toastr.min.css", "~/Content/awesomplete.css", "~/Content/css/select2.css"));
            //all
            bundles.Add(new ScriptBundle("~/bundles/Basic").Include("~/Scripts/jquery-2.1.4.min.js", "~/Scripts/toastr.min.js", "~/Scripts/bootstrap.min.js", "~/Scripts/awesomplete.js", "~/Scripts/select2.js"));

            bundles.Add(new ScriptBundle("~/bundles/Angular").Include("~/Scripts/angular.min.js"));
            //pages
            bundles.Add(new ScriptBundle("~/bundles/engine").Include("~/engine/geral/mensagens.js", "~/engine/geral/util.js"));
            bundles.Add(new ScriptBundle("~/bundles/familia").Include("~/engine/familia/familia.js", "~/engine/familia/familia.controller.js", "~/engine/familia/familia.presentation.js"));
            bundles.Add(new ScriptBundle("~/bundles/status").Include("~/engine/geral/status.js"));
            bundles.Add(new ScriptBundle("~/bundles/chamada").Include("~/engine/geral/chamada.js", "~/engine/geral/chamada.controller.js"));

        }

    }
}
