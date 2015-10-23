Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class RoupaController
        Inherits ApiController
        <HttpGet>
        Public Function GetValues() As IList(Of Model.Roupa)

            Dim lstRetorno As List(Of Model.Roupa) = Nothing
            Dim oBusiness As Business.Roupa

            Try
                oBusiness = New Business.Roupa()
                lstRetorno = oBusiness.LoadAll()

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function

    End Class
End Namespace