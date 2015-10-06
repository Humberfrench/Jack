<Serializable()> _
Public Class FamiliaPresenca

    Public Sub New()

        Nivel = 0
        Familia = String.Empty
        Data = New DateTime()

    End Sub


    Public Sub New(strFamilia As String, intNivel As Integer, DataReuniao As DateTime)

        Nivel = intNivel
        Familia = strFamilia
        Data = DataReuniao

    End Sub

    Public Property Familia As String
    Public Property Nivel As Integer
    Public Property Data As DateTime

    Public ReadOnly Property DataFormated As String
        Get
            Return Data.Day.ToString("00") + "/" + Data.Month.ToString("00") + "/" + Data.Year.ToString("0000")
        End Get
    End Property




End Class
