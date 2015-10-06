Public Class ProcessaPresenca

    Public Overridable Property CodigoFamilia As Integer
    Public Overridable Property NomedaMae As String
    Public Overridable Property NumeroReunioes As Integer
    Public Overridable Property TotalReunioes As Integer
    Public Overridable Property PercentualReunioes As Double
    Public Overridable Property IsSacolinha As String
    Public Overridable ReadOnly Property Nivel As String
        Get
            Return "Nivel " + NumeroNivel.ToString()
        End Get
    End Property
    Public Overridable Property NumeroNivel As Integer

End Class
