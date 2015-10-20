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
            Dim lstRetorno As List(Of Model.Status) = Nothing

            lstRetorno.Add(New Model.Status(1, "OK", "S", "T"))
            lstRetorno.Add(New Model.Status(2, "Ressalva", "S", "F"))
            lstRetorno.Add(New Model.Status(3, "Problema", "N", "F"))
            lstRetorno.Add(New Model.Status(4, "Ressalva", "S", "C"))
            lstRetorno.Add(New Model.Status(5, "Problema", "N", "C"))
            lstRetorno.Add(New Model.Status(6, "Erro", "N", "T"))

            Return lstRetorno.Where(Function(x) x.NivelStatus = "F" And x.NivelStatus = "T").ToList()

        End Function

        Public Function LoadForChildrem() As IList(Of Model.Status)

            Dim lstRetorno As List(Of Model.Status) = Nothing
            lstRetorno = LoadData.Where(Function(x) x.NivelStatus = "C" And x.NivelStatus = "T").ToList()

            Return lstRetorno

        End Function

        Public Function LoadForFamily() As IList(Of Model.Status)

            Dim lstRetorno As List(Of Model.Status) = Nothing
            lstRetorno = LoadData.Where(Function(x) x.NivelStatus = "F" And x.NivelStatus = "T").ToList()

            Return lstRetorno

        End Function

    End Class
End Namespace