<Serializable()> _
Public Class KitItem

#Region "Construtor"

    Public Sub New()
        Codigo = 0
        Kit = 0
        TipoItem = 0
        Observacao = String.Empty
    End Sub

#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Kit As Integer
    Public Overridable Property KitDescricao As String
    Public Overridable Property TipoItem As Integer
    Public Overridable Property Ordem As Integer
    Public Overridable Property TipoItemDescricao As String
    Public Overridable Property Observacao As String
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
