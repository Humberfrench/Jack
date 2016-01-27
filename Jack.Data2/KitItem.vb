Imports Consumer.Data.Basic.Data
Imports System.Data

Public Class KitItem
    Inherits BaseData(Of Model.KitItem, Integer)

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Insert(ByVal oTipo As Model.KitItem) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.KitItem) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.KitItem) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.KitItem

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.KitItem)

        Return MyBase.LoadAll

    End Function

    Public Function LoadKitItemByKit(intKit As Integer) As IList(Of Model.KitItem)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.KitItem) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.KitItem = Nothing
        Try
            lstRetorno = New List(Of Model.KitItem)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_get_kit_item"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_kit", System.Data.DbType.Int32, 75, intKit))
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.KitItem()
                oRetorno.Codigo = Convert.ToInt32(dr("id_kit_item").ToString())
                oRetorno.Kit = Convert.ToInt32(dr("id_kit").ToString())
                oRetorno.KitDescricao = dr("ds_kit").ToString()
                oRetorno.TipoItem = Convert.ToInt32(dr("id_tipo_item").ToString())
                oRetorno.TipoItemDescricao = dr("ds_tipo_item").ToString()
                oRetorno.Observacao = dr("ds_observacao").ToString()
                oRetorno.Ordem = Convert.ToInt32(dr("nr_ordem").ToString())
                oRetorno.IsOpcional = dr("is_opcional").ToString()
                lstRetorno.Add(oRetorno)
            Next

        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function
End Class
