Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class ChamadaController
        Inherits ApiController

        <HttpGet>
        Public Function ObterChamada(intReuniao As Integer) As IList(Of Model.Familia)
            Dim oChamada As Business.Familia = New Business.Familia()
            Dim oReturn As List(Of Model.Familia)

            oReturn = oChamada.ObterChamada(intReuniao)
            oChamada = Nothing

            Return oReturn
        End Function

    End Class
End Namespace