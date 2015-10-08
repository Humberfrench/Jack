Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Web.Script.Serialization

Public Module Basic

    <Extension()>
    Public Function ToJSON(obj As Object) As String
        Dim serializer As New JavaScriptSerializer()
        Return serializer.Serialize(obj)
    End Function

    <Extension()>
    Public Function JsonToObject(Of T)(obj As String) As T
        Dim serializer As New JavaScriptSerializer()
        Return DirectCast(serializer.Deserialize(Of T)(obj), T)
    End Function

    <Extension()>
    Public Function ExceptionTratada(ex As Exception) As String
        Dim mensagem As String
        Try
            mensagem = ex.Message.ToString()
        Catch generatedExceptionName As Exception
            Return ex.Message
        End Try
        Return mensagem

    End Function

    <Extension()>
    Public Function IsNumeric(text As String) As Boolean
        Try
            Convert.ToInt32(text)
            Return True
        Catch
            Return False
        End Try
    End Function

End Module
