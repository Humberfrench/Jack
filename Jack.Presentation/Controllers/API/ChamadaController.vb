Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class ChamadaController
        Inherits ApiController

        <HttpGet>
        Public Function ObterChamada() As IList(Of Model.Familia)
            Return New List(Of Model.Familia)
        End Function

    End Class
End Namespace