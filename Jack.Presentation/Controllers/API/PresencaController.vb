Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class PresencaController
        Inherits ApiController

        <HttpGet>
        Public Function GetValue(ID As Integer) As IList(Of Model.Familia)

            Dim lstRetorno As List(Of Model.Familia) = Nothing
            Dim oBusiness As Business.Presenca

            Try
                oBusiness = New Business.Presenca()
                lstRetorno = oBusiness.Load(ID)

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno
        End Function

        Public Function ObterPresencaPorMae(Familia As Integer, Ano As Integer) As List(Of FamiliaPresenca)

            Dim lstRetorno As List(Of FamiliaPresenca) = Nothing
            Dim oBusiness As IPresencaApp

            Try
                oBusiness = New PresencaApp()
                lstRetorno = oBusiness.ObterPresencaPorMae(Familia, Ano)

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno
        End Function

    End Class
End Namespace