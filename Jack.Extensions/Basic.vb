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

    '<Extension()>
    'Public Function ToString(Of T)(obj As T) As String

    '    Dim tipoEntidade As Type = GetType(T)
    '    Return ""
    'End Function

    '<System.Runtime.CompilerServices.Extension>
    'Public Shared Function ToXml(Of T)(lista As IEnumerable(Of T)) As String
    '    Dim sw As New StringWriter()
    '    Dim xml As XmlWriter = New XmlTextWriter(sw)

    '    xml.WriteStartElement("DocumentElement")
    '    For Each itemLista As T In lista.Where(Function(itemLista) DirectCast(itemLista, Object) IsNot Nothing)
    '        xml.WriteStartElement("Tabela")
    '        Dim tipoEntidade As Type = GetType(T)
    '        Dim camposClasse As List(Of FieldInfo) = tipoEntidade.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance).ToList()
    '        If tipoEntidade.BaseType IsNot Nothing Then
    '            camposClasse.AddRange(tipoEntidade.BaseType.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance))
    '        End If

    '        For Each infoCampo As FieldInfo In camposClasse.Where(Function(infoCampo) infoCampo IsNot Nothing)
    '            Dim valor As Object = infoCampo.GetValue(itemLista).TrataValores()
    '            Dim nomeField As String = infoCampo.Name

    '            If infoCampo.Name.Equals("_id") Then
    '                nomeField = "id"
    '            End If

    '            If valor IsNot Nothing Then
    '                xml.WriteElementString(nomeField, valor.ToString())

    '            End If
    '        Next
    '        xml.WriteEndElement()
    '    Next

    '    xml.WriteEndElement()

    '    Return sw.ToString()
    'End Function
End Module
