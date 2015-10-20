Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class StatusController
        Inherits ApiController

        Public Function GetValues() As IList(Of Model.Status)

            Dim lstRetorno As List(Of Model.Status) = LoadData()
            Return lstRetorno

        End Function

        Function LoadData() As IList(Of Model.Status)
            Dim lstRetorno1 As List(Of Model.Status) = Nothing

            lstRetorno1 = New List(Of Model.Status)()

            lstRetorno1.Add(New Model.Status(1, "OK", "S", "T"))
            lstRetorno1.Add(New Model.Status(2, "Ressalva", "S", "F"))
            lstRetorno1.Add(New Model.Status(3, "Problema", "N", "F"))
            lstRetorno1.Add(New Model.Status(4, "Ressalva", "S", "C"))
            lstRetorno1.Add(New Model.Status(5, "Problema", "N", "C"))
            lstRetorno1.Add(New Model.Status(6, "Erro", "N", "T"))
            lstRetorno1.Add(New Model.Status(99, "LoadData", "N", "T"))

            Return lstRetorno1

        End Function

        Public Function LoadForChildrem() As IList(Of Model.Status)

            Dim lstRetorno2 As List(Of Model.Status) = Nothing
            lstRetorno2 = LoadData.Where(Function(x) x.NivelStatus = "C" Or x.NivelStatus = "T").ToList()
            lstRetorno2.Add(New Model.Status(99, "LoadForChildrem", "N", "T"))

            Return lstRetorno2

        End Function

        Public Function LoadForFamily() As IList(Of Model.Status)

            Dim lstRetorno3 As List(Of Model.Status) = Nothing
            lstRetorno3 = LoadData.Where(Function(x) x.NivelStatus = "F" Or x.NivelStatus = "T").ToList()

            lstRetorno3.Add(New Model.Status(99, "LoadForFamily", "N", "T"))

            Return lstRetorno3

        End Function

    End Class
End Namespace