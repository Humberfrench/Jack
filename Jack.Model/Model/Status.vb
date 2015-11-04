<Serializable()> _
Public Class Status

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


    Public Sub New(intCodigo As Integer, strDescricao As String, strPermiteSacola As String, strNivelStatus As String)
        Codigo = intCodigo
        Descricao = strDescricao
        PermiteSacola = strPermiteSacola
        NivelStatus = strNivelStatus
    End Sub

#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Descricao As String
    Public Overridable Property PermiteSacola As String
    Public Overridable Property NivelStatus As String

    Public ReadOnly Property PermiteSacolaDesc As String
        Get
            If PermiteSacola = "S" Then
                Return "Sim"
            Else
                Return "Não"
            End If
        End Get
    End Property
    Public ReadOnly Property NivelStatusDesc As String
        Get
            If NivelStatus = "F" Then
                Return "Família"
            ElseIf NivelStatus = "C" Then
                Return "Criança"
            Else
                Return "Todos"
            End If
        End Get
    End Property

End Class
