Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class FamiliaCriancaController
        Inherits ApiController
        Public Function ObterCriancas(ID As Integer) As IList(Of Model.Criancas)

            Dim lstRetorno As List(Of Model.Criancas) = Nothing
            Dim oBusiness As Business.FamiliaCrianca

            Try
                oBusiness = New Business.FamiliaCrianca()
                lstRetorno = oBusiness.ObterCriancasByFamilia(ID)

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function


        Public Function ObterCriancasByRepresentante(ID As Integer) As IList(Of Model.Criancas)

            Dim lstRetorno As List(Of Model.Criancas) = Nothing
            Dim oBusiness As Business.FamiliaCrianca

            Try
                oBusiness = New Business.FamiliaCrianca()
                lstRetorno = oBusiness.ObterCriancasByFamiliaWithRep(ID)

            Catch ex As Exception
                lstRetorno = Nothing
            Finally
                oBusiness = Nothing
            End Try

            Return lstRetorno

        End Function

    End Class
End Namespace