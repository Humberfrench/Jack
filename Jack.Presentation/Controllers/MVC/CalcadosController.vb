Imports System.Web.Mvc

Namespace Controllers.MVC
    Public Class CalcadosController
        Inherits Controller

        ' GET: Calcados
        Function Index() As ActionResult

            Dim CalcadoBusiness As Business.Calcado = Nothing
            Dim CalcadoRetorno As List(Of Model.Calcado) = Nothing

            Try

                CalcadoBusiness = New Business.Calcado()
                'fake init
                'CalcadoRetorno = New List(Of Model.Calcado)
                'CalcadoRetorno.Add(New Model.Calcado)
                'CalcadoRetorno.Add(New Model.Calcado)
                'CalcadoRetorno.Add(New Model.Calcado)
                'CalcadoRetorno.Add(New Model.Calcado)
                'CalcadoRetorno.Add(New Model.Calcado)
                'fake end
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