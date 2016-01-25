Public Structure Idade

    Public ReadOnly Property Dias() As Integer
    Public ReadOnly Property Meses() As Integer
    Public ReadOnly Property Anos() As Integer

    Public Sub New(dataNascimento As DateTime)
        Me.New()
        If dataNascimento > DateTime.Now Then
            Return
        End If

        Dim hoje As DateTime = DateTime.Today

        Dim dias As Integer = hoje.Day - dataNascimento.Day
        If dias < 0 Then
            hoje = hoje.AddMonths(-1)
            dias += DateTime.DaysInMonth(hoje.Year, hoje.Month)
        End If

        Dim meses As Integer = hoje.Month - dataNascimento.Month
        If meses < 0 Then
            hoje = hoje.AddYears(-1)
            meses += 12
        End If

        Dim anos As Integer = hoje.Year - dataNascimento.Year

        Me.Dias = dias
        Me.Meses = meses
        Me.Anos = anos

    End Sub
End Structure