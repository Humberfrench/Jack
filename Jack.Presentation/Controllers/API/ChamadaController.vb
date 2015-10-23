Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class ChamadaController
        Inherits ApiController

        <HttpGet>
        Public Function GetValues() As IList(Of Model.Familia)

            Dim lstRetorno As List(Of Model.Familia) = Nothing
            Dim oBusiness As Business.Familia

            Try
                oBusiness = New Business.Familia()
                lstRetorno = oBusiness.ObterChamada()

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function

    End Class
End Namespace