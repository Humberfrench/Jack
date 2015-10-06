<Serializable()> _
Public Class FamiliaCrianca

#Region "Construtor"

    Public Sub New()
        Crianca = 0
        Familia = 0
    End Sub


    Public Sub New(intCrianca As Integer, intFamilia As Integer)
        Crianca = intCrianca
        Familia = intFamilia
    End Sub

#End Region

    Public Overridable Property Crianca As Integer
    Public Overridable Property Familia As Integer

End Class