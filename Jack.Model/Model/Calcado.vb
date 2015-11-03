<Serializable()> _
Public Class Calcado

    Public Sub New()

        Codigo = 0
        Numero = 0
        Sexo = String.Empty
        NumeroInicio = 0
        NumeroFim = 0
        MedidaIdade = String.Empty

    End Sub

    Public Overridable Property Codigo As Integer
    Public Overridable Property Numero As Integer
    Public Overridable Property Sexo As String
    Public Overridable Property NumeroInicio As Integer
    Public Overridable Property NumeroFim As Integer
    Public Overridable Property MedidaIdade As String

    Public Overridable ReadOnly Property IdadeInicial As String
        Get
            If MedidaIdade = "M" Then
                Return NumeroInicio.ToString() + " meses"
            Else
                Return NumeroInicio.ToString() + " anos"
            End If
        End Get
    End Property

    Public Overridable ReadOnly Property IdadeFinal As String
        Get
            If MedidaIdade = "M" Then
                Return NumeroFim.ToString() + " meses"
            Else
                Return NumeroFim.ToString() + " anos"
            End If
        End Get
    End Property

    Public Overridable ReadOnly Property SexoDescricao As String
        Get
            If Sexo = "M" Then
                Return "<span style='color:MidnightBlue;'>Masculino</span>"
            Else
                Return "<span style='color:Red;'>Feminino</span>"
            End If
        End Get
    End Property

End Class
