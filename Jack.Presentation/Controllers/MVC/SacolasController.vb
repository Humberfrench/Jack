Imports System.Web.Mvc

Namespace Controllers.MVC
    Public Class SacolasController
        Inherits Controller

        ' GET: Sacolas
        Function Index() As ActionResult
            Return View()
        End Function

        Function Livres() As ActionResult
            Return View()
        End Function

    End Class
End Namespace