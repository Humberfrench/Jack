Imports System.Web.Mvc

Namespace Controllers.MVC
    Public Class FamiliaCriancaController
        Inherits Controller

        ' GET: FamiliaCrianca
        Function Index() As ActionResult
            Return View()
        End Function

        Function Representante() As ActionResult
            Return View()
        End Function

    End Class
End Namespace