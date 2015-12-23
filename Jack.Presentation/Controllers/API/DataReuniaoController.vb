Imports System.Net
Imports System.Web.Http

Namespace Controllers.API
    Public Class DataReuniaoController
        Inherits ApiController

        <HttpGet>
        Public Function GetValues(intAno As Integer) As IList(Of Model.Reuniao)
            Dim oReuniao As Business.Reuniao = New Business.Reuniao()
            Dim oReturn As List(Of Model.Reuniao)

            oReturn = oReuniao.LoadByAnoCorrente(intAno)
            oReuniao = Nothing

            Return oReturn

        End Function


    End Class
End Namespace