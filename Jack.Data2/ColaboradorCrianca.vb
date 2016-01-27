Imports Consumer.Data.Basic.Data
Imports System.Data

Public Class ColaboradorCrianca
    Inherits BaseData(Of Model.ColaboradorCrianca, Integer)

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
    Overrides Function Insert(ByVal oTipo As Model.ColaboradorCrianca) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.ColaboradorCrianca) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.ColaboradorCrianca) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.ColaboradorCrianca

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.ColaboradorCrianca)

        Return MyBase.LoadAll

    End Function

#End Region

#Region "Outros"

    ''' <summary>
    ''' Lista Todas as Crianças que tem sacolinhas na mão de um colaborador
    ''' </summary>
    ''' <param name="intColaborador">Código do Colaborador</param>
    ''' <returns>List(Of Model.ColaboradorCrianca) - Lista de Criancas por Colaborador </returns>
    ''' <remarks></remarks>
    Public Function ObterCriancasPorColaborador(intColaborador As Integer, intAno As Integer) As List(Of Model.ColaboradorCrianca)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.ColaboradorCrianca) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.ColaboradorCrianca = Nothing

        Try
            lstRetorno = New List(Of Model.ColaboradorCrianca)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_list_sacola_colaborador"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_colaborador", DbType.Int32, intColaborador))
            oCommand.Parameters.Add(New Parameter("@nr_ano", DbType.Int32, intAno))
            dtDados = oCommand.GetDataTable()
            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.ColaboradorCrianca()
                oRetorno.Codigo = Convert.ToInt32(dr("id_colaborador_crianca").ToString())
                oRetorno.Colaborador = intColaborador
                oRetorno.Crianca = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.NomeCrianca = dr("nm_crianca").ToString()
                oRetorno.NomeColaborador = dr("ds_nome").ToString()
                oRetorno.IsDevolvida = dr("is_devolvida").ToString()
                oRetorno.NumeroSacola = dr("id_sacolinha").ToString()
                oRetorno.NumeroIdade = Convert.ToInt32(dr("nr_idade").ToString())
                oRetorno.MedidaIdade = dr("ds_medida_idade").ToString()
                oRetorno.Roupa = dr("nr_roupa").ToString()
                oRetorno.Calcado = Convert.ToInt32(dr("nr_calcado").ToString())
                oRetorno.Ano = Convert.ToInt32(dr("nr_ano").ToString())
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
