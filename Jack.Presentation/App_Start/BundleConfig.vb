Imports System.Web.Optimization

Public Module BundleConfig

    Public Sub RegisterBundles(bundles As BundleCollection)

        bundles.Add(New StyleBundle("~/Content/Basic").Include("~/Content/Jack.css",
                                                               "~/Content/bootstrap.min.css",
                                                               "~/Content/bootstrap-theme.min.css",
                                                               "~/Content/toastr.min.css",
                                                               "~/Content/awesomplete.css",
                                                               "~/Content/css/select2.css"))
        'all
        bundles.Add(New ScriptBundle("~/bundles/Basic").Include("~/Scripts/jquery-2.1.4.min.js",
                                                                "~/Scripts/toastr.min.js",
                                                                "~/Scripts/bootstrap.min.js",
                                                                "~/Scripts/awesomplete.js",
                                                                "~/Scripts/select2.js"))

        bundles.Add(New ScriptBundle("~/bundles/Angular").Include("~/Scripts/angular.min.js"))
        'pages
        bundles.Add(New ScriptBundle("~/bundles/engine").Include("~/engine/geral/mensagens.js", "~/engine/geral/util.js"))
        bundles.Add(New ScriptBundle("~/bundles/familia").Include("~/engine/familia/familia.js", "~/engine/familia/familia.controller.js", "~/engine/familia/familia.presentation.js"))
        bundles.Add(New ScriptBundle("~/bundles/status").Include("~/engine/geral/status.js"))

    End Sub

End Module
