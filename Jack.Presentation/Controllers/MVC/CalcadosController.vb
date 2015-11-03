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
                CalcadoRetorno = New List(Of Model.Calcado)
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 1, .NumeroFim = 6, .Sexo = "M", .MedidaIdade = "M"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 6, .NumeroFim = 12, .Sexo = "M", .MedidaIdade = "M"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 1, .NumeroFim = 2, .Sexo = "M", .MedidaIdade = "A"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 2, .NumeroFim = 3, .Sexo = "M", .MedidaIdade = "A"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 4, .NumeroFim = 5, .Sexo = "M", .MedidaIdade = "A"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 1, .NumeroFim = 6, .Sexo = "F", .MedidaIdade = "M"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 6, .NumeroFim = 12, .Sexo = "F", .MedidaIdade = "M"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 1, .NumeroFim = 2, .Sexo = "F", .MedidaIdade = "A"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 2, .NumeroFim = 3, .Sexo = "F", .MedidaIdade = "A"})
                CalcadoRetorno.Add(New Model.Calcado With {.Codigo = 1, .Numero = 20, .NumeroInicio = 4, .NumeroFim = 5, .Sexo = "F", .MedidaIdade = "A"})
                'fake end
                'CalcadoRetorno = CalcadoBusiness.LoadAll()

            Catch ex As Exception
                CalcadoRetorno = New List(Of Model.Calcado)
            Finally
                CalcadoBusiness = Nothing
            End Try

            Return View(CalcadoRetorno)

        End Function
    End Class
End Namespace