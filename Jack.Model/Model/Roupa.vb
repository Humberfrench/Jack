<Serializable()>
Public Class Roupa

    Public Sub New()

        Codigo = 0
        Tamanho = String.Empty
        Idade = 0
        MedidaIdade = String.Empty

    End Sub

    Public Overridable Property Codigo As Integer
    Public Overridable Property Tamanho As String
    Public Overridable Property Idade As Integer
    Public Overridable Property MedidaIdade As String

    Public Overridable ReadOnly Property IdadeString As String
        Get
            If MedidaIdade = "M" Then
                Return Idade.ToString() + " meses"
            Else
                Return Idade.ToString() + " anos"
            End If
        End Get
    End Property

End Class
