Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class FamiliaController
        Inherits ApiController

        <HttpGet>
        Public Function GetValues() As IList(Of Model.Familia)

            Dim lstRetorno As List(Of Model.Familia) = Nothing
            Dim oBusiness As Business.Familia

            Try
                oBusiness = New Business.Familia()
                lstRetorno = oBusiness.LoadAll()

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function

        <HttpGet>
        Public Function GetValue(<FromUri> ID As Integer) As Model.Familia

            Dim oRetorno As Model.Familia
            Dim oBusiness As Business.Familia

            Try
                oBusiness = New Business.Familia()
                oRetorno = oBusiness.Find(ID)

            Catch ex As Exception
                oRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return oRetorno

        End Function

        <HttpPost>
        Public Sub Salvar(<FromUri> oFamily As Model.Familia)

            'atualizando datas
            oFamily.DataAtualizacao = DateTime.Now()

        End Sub

        <HttpDelete>
        Public Sub Delete(<FromUri> ID As Integer)
            Dim oBusiness As Business.Familia
            Dim oDelete As Model.Familia
            Try
                oBusiness = New Business.Familia()
                oDelete = New Model.Familia()
                oDelete.Codigo = ID
                oBusiness.Delete(oDelete)

            Finally
                oBusiness = Nothing
            End Try

        End Sub

    End Class
End Namespace