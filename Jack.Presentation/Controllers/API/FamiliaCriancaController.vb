Imports System.Web.Http
Imports Jack.Model.DTOs

Namespace Controllers.API
    Public Class FamiliaCriancaController
        Inherits ApiController
        Public Function ObterCriancas(ID As Integer) As IList(Of DTOCrianca)

            Dim lstRetorno As List(Of DTOCrianca) = Nothing
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


        Public Function ObterCriancasByRepresentante(ID As Integer) As IList(Of DTOCriancaRepresentante)

            Dim lstRetorno As List(Of DTOCriancaRepresentante) = Nothing
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