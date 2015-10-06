<Serializable()> _
Public Class TipoItem

#Region "Construtor"

    Public Sub New()
        Codigo = 0
        Descricao = String.Empty
    End Sub

    Public Sub New(strDescricao As String)
        Codigo = 0
        Descricao = strDescricao
    End Sub

    Public Sub New(intCodigo As Integer, strDescricao As String)
        Codigo = intCodigo
        Descricao = strDescricao
    End Sub

#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Descricao As String
    Public Overridable Property IsOpcional As String

    Public Overridable ReadOnly Property Opcional As String
        Get
            If IsOpcional = "S" Then
                Return "Opcional"
            Else
                Return "Não"
            End If
        End Get
    End Property

End Class
