<Serializable()> _
Public Class Presenca

#Region "Construtor"

    Public Sub New()
        Familia = 0
        Reuniao = 0
        Codigo = 0
    End Sub

#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Familia As Integer
    Public Overridable Property Reuniao As Integer

End Class
