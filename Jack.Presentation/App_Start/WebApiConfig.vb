Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        'config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )

        config.Routes.MapHttpRoute(
            name:="ObtemVazios1",
            routeTemplate:="api/{controller}/Get/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )

        'config.Routes.MapHttpRoute(
        '    name:="ActionApi2",
        '    routeTemplate:="api/{controller}/{MasterID}/{DetailID}",
        '    defaults:=New With {.MasterID = RouteParameter.Optional, .DetailID = RouteParameter.Optional}
        ')

        'config.Routes.MapHttpRoute(
        '    name:="ActionApi2",
        '    routeTemplate:="api/{controller}/{MasterID}/{DetailID}",
        '    defaults:=New With {.MasterID = RouteParameter.Optional, .DetailID = RouteParameter.Optional}
        ')

        config.Formatters.Remove(config.Formatters.XmlFormatter)
        config.Formatters.JsonFormatter.Indent = True

    End Sub
End Module
