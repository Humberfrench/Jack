Imports System.Data
Imports Consumer.Data.Basic.Data

Public Class Colaborador
    Inherits BaseData(Of Model.Colaborador, Integer)

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Crud"
    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Insert(ByVal oTipo As Model.Colaborador) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.Colaborador) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.Colaborador) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.Colaborador

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.Colaborador)

        Return MyBase.LoadAll

    End Function

#End Region

#Region "Outros Métodos"

    Public Function ListaQuantidadeSacolasPorColaborador(intAno As Integer) As List(Of Model.Colaborador)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Colaborador) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Colaborador = Nothing

        Try
            lstRetorno = New List(Of Model.Colaborador)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_list_qtde_sacola_colaborador"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@nr_ano", DbType.Int32, intAno))
            dtDados = oCommand.GetDataTable()
            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Colaborador()
                oRetorno.Codigo = Convert.ToInt32(dr("id_colaborador").ToString())
                oRetorno.Nome = dr("ds_nome").ToString()
                oRetorno.TotalSacolas = Convert.ToInt32(dr("tt_sacolas").ToString())
                oRetorno.QuantidadeSacolas = Convert.ToInt32(dr("qt_sacolas").ToString())
                oRetorno.PercentualSacolas = Convert.ToDouble(dr("pc_sacola").ToString())
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

#End Region
End Class
