Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class CalcadoController
        Inherits ApiController
        <HttpGet>
        Public Function GetValues() As IList(Of Model.Calcado)

            Dim lstRetorno As List(Of Model.Calcado) = Nothing
            Dim oBusiness As Business.Calcado

            Try
                oBusiness = New Business.Calcado()
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