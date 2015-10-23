Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class FamiliaController
        Inherits ApiController

        <HttpGet>
        Public Function GetValues() As IList(Of Model.Familia)

            Dim temp As Model.Familia = Nothing
            Dim lstRetorno As List(Of Model.Familia) = Nothing
            lstRetorno = New List(Of Model.Familia)

            temp = New Model.Familia()
            temp.Codigo = 1
            temp.IsConsistente = "S"
            temp.Contato = "99934-4533"
            temp.DataAtualizacao = DateAndTime.Now
            temp.Familia = "Nome Qualquer1"
            temp.IsSacolinha = "N"
            temp.Status = 1
            temp.Nivel = 1

            lstRetorno.Add(temp)

            temp = New Model.Familia()
            temp.Codigo = 2
            temp.IsConsistente = "S"
            temp.Contato = "2232-3432"
            temp.DataAtualizacao = DateAndTime.Now
            temp.Familia = "Nome Qualquer 2"
            temp.IsSacolinha = "N"
            temp.Status = 1
            temp.Nivel = 99
            lstRetorno.Add(temp)

            temp = New Model.Familia()
            temp.Codigo = 3
            temp.IsConsistente = "S"
            temp.Contato = "93321-4367"
            temp.DataAtualizacao = DateAndTime.Now
            temp.Familia = "Nome Qualquer 3"
            temp.IsSacolinha = "S"
            temp.Status = 2
            temp.Nivel = 2
            lstRetorno.Add(temp)
            Return lstRetorno

        End Function

        <HttpPost>
        Public Sub Salvar(<FromUri> oFamily As Model.Familia)

            'atualizando datas
            oFamily.DataAtualizacao = DateTime.Now()

        End Sub

        <HttpDelete>
        Public Sub Delete(intFamilia As Integer)

        End Sub

    End Class
End Namespace