Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class StatusController
        Inherits ApiController

        <HttpGet>
        Public Function LoadForChildrem() As IList(Of Model.Status)

            Dim lstRetorno As List(Of Model.Status) = Nothing
            Dim oBusiness As Business.Status = Nothing
            Try
                oBusiness = New Business.Status()
                lstRetorno = oBusiness.LoadForCriancas()

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno


        End Function

        <HttpGet>
        Public Function LoadForFamily() As IList(Of Model.Status)

            Dim lstRetorno As List(Of Model.Status) = Nothing
            Dim oBusiness As Business.Status = Nothing
            Try
                oBusiness = New Business.Status()
                lstRetorno = oBusiness.LoadForFamilia()

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function

    End Class
End Namespace