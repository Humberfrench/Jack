Imports System.Web.Mvc

Namespace Controllers.MVC
    Public Class RoupasController
        Inherits Controller

        ' GET: Roupas
        Function Index() As ActionResult
            Dim RoupaBusiness As Business.Roupa = Nothing
            Dim RoupaRetorno As List(Of Model.Roupa) = Nothing

            Try

                RoupaBusiness = New Business.Roupa()
                'fake init
                RoupaRetorno = New List(Of Model.Roupa)
                RoupaRetorno.Add(New Model.Roupa)
                RoupaRetorno.Add(New Model.Roupa)
                RoupaRetorno.Add(New Model.Roupa)
                RoupaRetorno.Add(New Model.Roupa)
                RoupaRetorno.Add(New Model.Roupa)
                'fake end
                'RoupaRetorno = RoupaBusiness.LoadAll()

            Catch ex As Exception
                RoupaRetorno = New List(Of Model.Roupa)
            Finally
                RoupaBusiness = Nothing
            End Try

            Return View(RoupaRetorno)

        End Function
    End Class
End Namespace