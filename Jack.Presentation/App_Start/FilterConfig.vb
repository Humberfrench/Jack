Imports System.Web.Mvc

Public Module FilterConfig


    Public Sub RegisterGlobalFilters(filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub


End Module
