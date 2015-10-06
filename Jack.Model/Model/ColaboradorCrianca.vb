<Serializable()> _
Public Class ColaboradorCrianca

#Region "Construtor"

    Public Sub New()
        Crianca = 0
        Colaborador = 0
    End Sub


#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Colaborador As Integer
    Public Overridable Property Crianca As Integer
    Public Overridable Property Ano As Integer
    Public Overridable Property NumeroSacola As Integer
    Public Overridable Property IsDevolvida As String
    Public Overridable Property NomeCrianca As String
    Public Overridable Property NomeColaborador As String

    Public Overridable Property NumeroIdade As Integer
    Public Overridable Property MedidaIdade As String

    Public Overridable Property Calcado As Integer
    Public Overridable Property Roupa As String

    Public Overridable ReadOnly Property Idade As String
        Get
            If MedidaIdade = "A" Then
                Return NumeroIdade.ToString() + " Anos"
            Else
                Return NumeroIdade.ToString() + " Meses"
            End If
        End Get
    End Property

End Class