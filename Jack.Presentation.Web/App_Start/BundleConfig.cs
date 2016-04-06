using System.Collections.Generic;
using System.Web.Optimization;

namespace Jack.Presentation.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var basicBundle = new StyleBundle("~/Content/basic");
            basicBundle.Include("~/Content/Jack.css");
            basicBundle.Include("~/Content/bootstrap.min.css");
            basicBundle.Include("~/Content/bootstrap.min.css");
            basicBundle.Include("~/Content/bootstrap-theme.min.css");
            basicBundle.Include("~/Content/toastr.min.css");
            basicBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(basicBundle);

            var basicStyleBundle = new ScriptBundle("~/bundles/basic");
            basicStyleBundle.Include("~/Scripts/jquery-{version}.js");
            basicStyleBundle.Include("~/Scripts/toastr.min.js");
            basicStyleBundle.Include("~/Scripts/bootstrap.min.js");
            basicStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(basicStyleBundle);

            var angularStyleBundle = new ScriptBundle("~/bundles/angular");
            angularStyleBundle.Include("~/Scripts/angular.min.js");
            angularStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(angularStyleBundle);

            var engineStyleBundle = new ScriptBundle("~/bundles/engine");
            engineStyleBundle.Include("~/engine/geral/mensagens.js");
            engineStyleBundle.Include("~/engine/geral/util.js");
            basicBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(engineStyleBundle);

            var familiaStyleBundle = new ScriptBundle("~/bundles/familia");
            familiaStyleBundle.Include("~/engine/familia/familia.js");
            familiaStyleBundle.Include("~/engine/familia/familia.controller.js");
            familiaStyleBundle.Include("~/engine/familia/familia.presentation.js");
            familiaStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(familiaStyleBundle);

            var familiacriancaBundle = new ScriptBundle("~/bundles/familiacrianca");
            familiacriancaBundle.Include("~/engine/familia/familia.js");
            familiacriancaBundle.Include("~/engine/familiacrianca/familiacrianca.js");
            familiacriancaBundle.Include("~/engine/familiacrianca/familiacrianca.controller.js");
            familiacriancaBundle.Include("~/engine/familiacrianca/familiafamiliacrianca.presentation.js");
            familiacriancaBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(familiacriancaBundle);

            var statusStyleBundle = new ScriptBundle("~/bundles/status");
            statusStyleBundle.Include("~/engine/geral/status.js");
            statusStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(statusStyleBundle);

            var utilStyleBundle = new ScriptBundle("~/bundles/util");
            utilStyleBundle.Include("~/engine/geral/util.js");
            utilStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(utilStyleBundle);

            var chamadaStyleBundle = new ScriptBundle("~/bundles/chamada");
            chamadaStyleBundle.Include("~/engine/chamada/chamada.js");
            chamadaStyleBundle.Include("~/engine/chamada/chamada.controller.js");
            chamadaStyleBundle.Include("~/engine/chamada/chamada.presentation.js");
            chamadaStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(chamadaStyleBundle);

            var reuniaoStyleBundle = new ScriptBundle("~/bundles/reuniao");
            reuniaoStyleBundle.Include("~/engine/chamada/reuniao.js");
            reuniaoStyleBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(reuniaoStyleBundle);

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