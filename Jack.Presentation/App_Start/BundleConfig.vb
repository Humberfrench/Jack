Imports System.Web.Optimization

Public Module BundleConfig

    Public Sub RegisterBundles(bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/familia").Include("~/engine/familia.js"))

    End Sub

End Module
