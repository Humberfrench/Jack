﻿Imports System.Web.Mvc

Namespace Controllers.MVC
    Public Class CalcadosController
        Inherits Controller

        ' GET: Calcados
        Function Index() As ActionResult

            Dim CalcadoBusiness As Business.Calcado = Nothing
            Dim CalcadoRetorno As List(Of Model.Calcado) = Nothing

            Try

                CalcadoBusiness = New Business.Calcado()
                CalcadoRetorno = CalcadoBusiness.LoadAll()

            Catch ex As Exception
                CalcadoRetorno = New List(Of Model.Calcado)
            Finally
                CalcadoBusiness = Nothing
            End Try

            Return View(CalcadoRetorno)

        End Function
    End Class
End Namespace