<Serializable()> _
Public Class Colaborador

    Public Sub New()
        Codigo = 0
        Nome = String.Empty
        Telefone = String.Empty
        Celular = String.Empty
        EMail = String.Empty
    End Sub

    Public Overridable Property Codigo As Integer
    Public Overridable Property Nome As String
    Public Overridable Property Telefone As String
    Public Overridable Property Celular As String
    Public Overridable Property CPF As String
    Public Overridable Property EMail As String
    Public Overridable Property AnoNotificacao As Integer
    Public Overridable Property TotalSacolas As Integer
    Public Overridable Property QuantidadeSacolas As Integer
    Public Overridable Property PercentualSacolas As Double

End Class
