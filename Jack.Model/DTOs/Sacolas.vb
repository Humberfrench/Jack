<Serializable()> _
Public Class Sacolas

    Public Overridable Property NumeroSacola As Integer
    Public Overridable Property NumeroSacolaFamilia
    Public Overridable Property CodigoFamilia As Integer
    Public Overridable Property CodigoFamiliaRep As Integer
    Public Overridable Property CodigoCrianca As Integer
    Public Overridable Property Sexo As String
    Public Overridable Property NomeMae As String
    Public Overridable Property NomeMaeRep As String
    Public Overridable Property NomeCrianca
    Public Overridable Property Calcado As Integer
    Public Overridable Property Roupa As String
    Public Overridable Property Idade As Integer
    Public Overridable Property MedidaIdade As String
    Public Overridable Property CodigoKit As Integer
    Public Overridable Property DescricaoKit As String
    Public Overridable Property NumeroNivel As Integer
    Public Overridable Property Impresso As String
    Public Overridable Property CodigoStatus As Integer
    Public Overridable Property DescricaoStatus As String

    Public Overridable ReadOnly Property IdadeCrianca As String
        Get

            Return Idade.ToString() + " " + MedidaIdade

        End Get
    End Property

End Class
