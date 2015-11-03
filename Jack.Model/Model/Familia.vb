<Serializable()> _
Public Class Familia

#Region "Construtor"

    Public Sub New()
        Codigo = 0
        Familia = String.Empty
    End Sub

#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Familia As String
    Public Overridable Property IsSacolinha As String
    Public Overridable Property IsConsistente As String
    Public Overridable Property Contato As String
    Public Overridable Property Nivel As Integer
    Public Overridable Property Status As Model.Status
    Public Overridable Property StatusCodigo As Integer
    Public Overridable Property StatusNome As String
    Public Overridable Property DataAtualizacao As DateTime

    Public Overridable ReadOnly Property DataAtualizacaoString As String
        Get
            Return DataAtualizacao.ToShortDateString()
        End Get
    End Property

    Public Overridable ReadOnly Property DataFormated As String
        Get
            Return DataAtualizacao.Day.ToString("00") + "/" + DataAtualizacao.Month.ToString("00") + "/" + DataAtualizacao.Year.ToString("0000")
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

End Class
