<Serializable()> _
Public Class Criancas

    Public Sub New()
        Codigo = 0
        Nome = String.Empty
        Idade = 0
        DataNascimento = New DateTime()
        Sexo = String.Empty
        Kit = 0
        MedidaIdade = String.Empty
        Calcado = 99
        Roupa = "99"
        IsSacolinha = String.Empty
        IsConsistente = String.Empty
        IsNecessidadeEspecial = String.Empty
        IsMoralCrista = String.Empty
        Status = New Status
        Familia = String.Empty
        FamiliaRepresentante = String.Empty
        DataAtualizacao = New DateTime()

    End Sub

    Public Overridable Property Codigo As Integer
    Public Overridable Property Nome As String
    Public Overridable Property Idade As Integer
    Public Overridable Property MedidaIdade As String
    Public Overridable Property DataNascimento As DateTime
    Public Overridable Property Sexo As String
    Public Overridable Property Calcado As Integer
    Public Overridable Property Roupa As String
    Public Overridable Property CalcadoPadrao As Integer
    Public Overridable Property RoupaPadrao As String
    Public Overridable Property Kit As Integer
    Public Overridable Property IsSacolinha As String
    Public Overridable Property IsConsistente As String
    Public Overridable Property IsNecessidadeEspecial As String
    Public Overridable Property IsMoralCrista As String
    Public Overridable Property Status As Model.Status
    Public Overridable Property Familia As String
    Public Overridable Property FamiliaRepresentante As String
    Public Overridable Property FamiliaCodigo As Integer
    Public Overridable Property FamiliaRepresentanteCodigo As Integer
    Public Overridable Property DataAtualizacao As DateTime
    Public ReadOnly Property StatusCodigo As Integer
        Get
            Return Status.Codigo
        End Get
    End Property
    Public ReadOnly Property StatusNome As String
        Get
            Return Status.Descricao
        End Get
    End Property

    Public Overridable ReadOnly Property DataAtualizacaoString As String
        Get
            Return DataAtualizacao.ToShortDateString()
        End Get
    End Property

    Public Overridable ReadOnly Property DataAtualizacaoFormated As String
        Get
            Return DataAtualizacao.Day.ToString("00") + "/" + DataAtualizacao.Month.ToString("00") + "/" + DataAtualizacao.Year.ToString("0000")
        End Get
    End Property

    Public Overridable ReadOnly Property IdadeCrianca As String
        Get
            If MedidaIdade = "A" Then
                Return Idade.ToString() + " Anos"
            Else
                Return Idade.ToString() + " Meses"
            End If
        End Get
    End Property

    Public Overridable ReadOnly Property Sacolinha As String
        Get
            If IsSacolinha = "S" Then
                Return "Sim"
            Else
                Return "Não"
            End If
        End Get
    End Property

    Public Overridable ReadOnly Property Consistente As String
        Get
            If IsConsistente = "S" Then
                Return "Sim"
            Else
                Return "Não"
            End If
        End Get
    End Property
    Public Overridable ReadOnly Property DataNascimentoString As String
        Get
            Return DataNascimento.ToShortDateString()
        End Get
    End Property

    Public Overridable ReadOnly Property DataFormated As String
        Get
            Return DataNascimento.Day.ToString("00") + "/" + DataNascimento.Month.ToString("00") + "/" + DataNascimento.Year.ToString("0000")
        End Get
    End Property

End Class
