<Serializable()> _
Public Class Kit

#Region "Construtor"

    Public Sub New()
        Codigo = 0
        Descricao = String.Empty
        IdadeMinima = 0
        IdadeMaxima = 0
        Sexo = String.Empty
        IsNecessidadeEspecial = String.Empty
    End Sub


#End Region

    Public Overridable Property Codigo As Integer
    Public Overridable Property Descricao As String
    Public Overridable Property IdadeMinima As Integer
    Public Overridable Property IdadeMaxima As Integer
    Public Overridable Property Sexo As String
    Public Overridable Property IsNecessidadeEspecial As String

    Public Overridable ReadOnly Property IdadeMinimaDesc As String
        Get
            Return IdadeMinima.ToString() + " Anos"
        End Get
    End Property
    Public Overridable ReadOnly Property IdadeMaximaDesc As String
        Get
            Return IdadeMaxima.ToString() + " Anos"
        End Get
    End Property
    Public Overridable ReadOnly Property SexoDesc As String
        Get
            If Sexo = "F" Then
                Return "Feminino"
            Else
                Return "Masculino"
            End If
        End Get
    End Property

End Class
