Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class TipoItemController
        Inherits ApiController

        <HttpGet>
        Public Function GetValues() As IList(Of Model.TipoItem)

            Dim lstRetorno As List(Of Model.TipoItem) = Nothing
            Dim oBusiness As Business.TipoItem

            Try
                oBusiness = New Business.TipoItem()
                lstRetorno = oBusiness.LoadAll()

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function

        <HttpGet>
        Public Function GetValue(<FromUri> ID As Integer) As Model.TipoItem

            Dim oRetorno As Model.TipoItem
            Dim oBusiness As Business.TipoItem

            Try
                oBusiness = New Business.TipoItem()
                oRetorno = oBusiness.Find(ID)

            Catch ex As Exception
                oRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return oRetorno

        End Function

        <HttpPost>
        Public Sub Salvar(<FromUri> oFamily As Model.TipoItem)

            Dim oBusiness As Business.TipoItem
            Try
                oBusiness = New Business.TipoItem()
                oBusiness.Update(oFamily)
            Finally
                oBusiness = Nothing
            End Try

        End Sub

        <HttpDelete>
            Public Sub Delete(<FromUri> ID As Integer)
            Dim oBusiness As Business.TipoItem
            Dim oDelete As Model.TipoItem
            Try
                oBusiness = New Business.TipoItem()
                oDelete = New Model.TipoItem()
                oDelete.Codigo = ID
                    oBusiness.Delete(oDelete)

                Finally
                    oBusiness = Nothing
                End Try

            End Sub
        End Class
End Namespace