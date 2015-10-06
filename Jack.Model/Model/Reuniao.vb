<Serializable()> _
Public Class Reuniao

    Public Overridable Property Codigo As Integer
    Public Overridable Property Ano As Integer
    Public Overridable Property AnoCorrente As Integer
    Public Overridable Property Data As Date

    Public Overridable ReadOnly Property DataFormated As String
        Get
            Return Data.Day.ToString("00") + "/" + Data.Month.ToString("00") + "/" + Data.Year.ToString("0000")
        End Get
    End Property

End Class
