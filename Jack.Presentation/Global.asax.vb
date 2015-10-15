﻿Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        'AreaRegistration.RegisterAllAreas()
        'GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        'RouteConfig.RegisterRoutes(RouteTable.Routes)

        AreaRegistration.RegisterAllAreas()

        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ValueProviderFactories.Factories.Add(New JsonValueProviderFactory())

    End Sub
End Class