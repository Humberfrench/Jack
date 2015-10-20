Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class StatusController
        Inherits ApiController

        Dim lstRetorno As List(Of Model.Status) = Nothing

        Public Function GetValues() As IList(Of Model.Status)
            LoadData()
            Return lstRetorno

        End Function

        Sub LoadData()
            lstRetorno = New List(Of Model.Status)

            lstRetorno.Add(New Model.Status(1, "OK"))
            lstRetorno.Add(New Model.Status(1, "Ressalva"))
            lstRetorno.Add(New Model.Status(1, "Problema"))
            lstRetorno.Add(New Model.Status(1, "Erro"))
        End Sub


    End Class
End Namespace