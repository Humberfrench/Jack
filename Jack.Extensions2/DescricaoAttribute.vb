
Public Class DescricaoAttribute
    Inherits Attribute
    Private _descricao As String
    Private _valorReal As String
    Private _id As Integer


    Public Sub New()
    End Sub

    Public Sub New(descricao As String)
        Me.Descricao = descricao
    End Sub

    Public Sub New(descricao As String, valorReal As String)
        Me.Descricao = descricao
        Me.ValorReal = valorReal
    End Sub
    Public Sub New(id As Integer, descricao As String, valorReal As String)
        Me.Id = id
        Me.Descricao = descricao
        Me.ValorReal = valorReal
    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set
            _id = Value
        End Set
    End Property
    Public Property Descricao() As String
        Get
            Return _descricao
        End Get
        Set
            _descricao = Value
        End Set
    End Property

    Public Property ValorReal() As String
        Get
            Return _valorReal
        End Get
        Set
            _valorReal = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _descricao
    End Function
End Class
