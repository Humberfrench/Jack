Public Class Roupa
    Inherits BaseData(Of Model.Roupa, Integer)

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Insert(ByVal oTipo As Model.Roupa) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.Roupa) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.Roupa) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.Roupa

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.Roupa)

        Return MyBase.LoadAll

    End Function
End Class
