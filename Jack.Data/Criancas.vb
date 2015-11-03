Imports System.Data
Imports Consumer.Data.Basic.Data

Public Class Criancas
    Inherits BaseData(Of Model.Criancas, Integer)

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Insert(ByVal oTipo As Model.Criancas) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.Criancas) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.Criancas) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.Criancas

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.Criancas)

        Return MyBase.LoadAll

    End Function
    Public Function ObterDados(intIdade As Integer,
                               strMedidaIdade As String,
                               strSexo As String,
                               blnIsNecessidadeEspecial As Boolean) As Model.Criancas

        Dim oDados As Command = Nothing
        Dim oCrianca As Model.Criancas
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")

            oDados.CommandText = "pr_obter_dados_gerais_crianca"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@nr_idade", DbType.Int32, intIdade))
            oDados.Parameters.Add(New Parameter("@ds_medida_idade", DbType.String, 1, strMedidaIdade))
            oDados.Parameters.Add(New Parameter("@ds_sexo", DbType.String, 1, strSexo))
            If blnIsNecessidadeEspecial Then
                oDados.Parameters.Add(New Parameter("@is_necessidade_especial", DbType.String, 1, "S"))
            End If

            dtDados = oDados.GetDataTable

            oCrianca = New Model.Criancas()
            oCrianca.Idade = intIdade
            oCrianca.MedidaIdade = strMedidaIdade
            oCrianca.Sexo = strSexo
            oCrianca.IsNecessidadeEspecial = IIf(blnIsNecessidadeEspecial, "S", "N")
            If dtDados.Rows.Count >= 1 Then
                oCrianca.Roupa = dtDados.Rows(0).Item("nr_roupa").ToString()
                oCrianca.Calcado = Convert.ToInt16(dtDados.Rows(0).Item("nr_calcado").ToString())
                oCrianca.Kit = Convert.ToInt16(dtDados.Rows(0).Item("id_kit").ToString())
            Else
                oCrianca.Roupa = "99"
                oCrianca.Calcado = 99
                oCrianca.Kit = 0
            End If

        Catch ex As Exception
            oCrianca = Nothing
            Throw ex
        Finally
            dtDados = Nothing
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return oCrianca

    End Function
    Public Function ObterDadosVestuario(intIdade As Integer,
                                        strMedidaIdade As String,
                                        strSexo As String) As Model.Criancas

        Dim oDados As Command = Nothing
        Dim oCrianca As Model.Criancas
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")

            oDados.CommandText = "pr_obter_dados_vestuario"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@nr_idade", DbType.Int32, intIdade))
            oDados.Parameters.Add(New Parameter("@ds_medida_idade", DbType.String, 1, strMedidaIdade))
            oDados.Parameters.Add(New Parameter("@ds_sexo", DbType.String, 1, strSexo))

            dtDados = oDados.GetDataTable

            oCrianca = New Model.Criancas()
            oCrianca.Roupa = intIdade
            oCrianca.Sexo = strSexo
            If dtDados.Rows.Count >= 1 Then
                oCrianca.Roupa = dtDados.Rows(0).Item("nr_roupa").ToString()
                oCrianca.Calcado = Convert.ToInt16(dtDados.Rows(0).Item("nr_calcado").ToString())
            Else
                oCrianca.Roupa = "99"
                oCrianca.Calcado = 99
            End If

        Catch ex As Exception
            oCrianca = Nothing
            Throw ex
        Finally
            dtDados = Nothing
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return oCrianca

    End Function

    Public Function ObterSacolasMae(intMae As Integer) As List(Of Model.Criancas)

        Dim oDados As Command = Nothing
        Dim objDados As Model.Criancas = Nothing
        Dim lCrianca As List(Of Model.Criancas) = Nothing
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")

            oDados.CommandText = "pr_obter_criancas_sacola"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intMae))

            dtDados = oDados.GetDataTable

            objDados = New Model.Criancas()
            lCrianca = New List(Of Model.Criancas)
            If dtDados.Rows.Count >= 1 Then
                For Each drDados As DataRow In dtDados.Rows
                    objDados = New Model.Criancas()
                    objDados.Codigo = Convert.ToInt16(drDados.Item("id_crianca").ToString())
                    objDados.Nome = drDados.Item("nm_crianca").ToString()
                    objDados.FamiliaCodigo = Convert.ToInt16(drDados.Item("id_familia").ToString())
                    objDados.Familia = drDados.Item("nm_familia").ToString()
                    objDados.FamiliaRepresentanteCodigo = Convert.ToInt16(drDados.Item("id_familia_rep").ToString())
                    objDados.FamiliaRepresentante = drDados.Item("nm_familia_rep").ToString()
                    objDados.Idade = Convert.ToInt16(drDados.Item("nr_idade").ToString())
                    objDados.MedidaIdade = drDados.Item("ds_medida_idade").ToString()
                    objDados.Roupa = drDados.Item("nr_roupa").ToString()
                    objDados.Calcado = Convert.ToInt16(drDados.Item("nr_calcado").ToString())
                    objDados.StatusCodigo = Convert.ToInt16(drDados.Item("id_Status").ToString())
                    objDados.Status = New Model.Status(Convert.ToInt32(drDados("id_status")), drDados("ds_status").ToString())
                    objDados.StatusNome = drDados.Item("ds_Status").ToString()
                    objDados.IsSacolinha = drDados.Item("is_sacolinha").ToString()
                    lCrianca.Add(objDados)
                Next
            End If

        Catch ex As Exception
            lCrianca = Nothing
            Throw ex
        Finally
            objDados = Nothing
            dtDados = Nothing
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return lCrianca

    End Function


    ''' <summary>
    ''' Atualiza os Dados das Crianças
    ''' </summary>
    ''' <param name="intCrianca">Código da Criança</param>
    ''' <param name="intCalcado">Número do Calçado</param>
    ''' <param name="strRoupa">Número da Roupa</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosCrianca(intCrianca As Integer, intCalcado As Integer, strRoupa As String) As Boolean
        Dim oCommand As Command = Nothing
        Dim oRetorno As Boolean = False
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_atualiza_vestimenta_crianca"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_crianca", DbType.Int32, intCrianca))
            oCommand.Parameters.Add(New Parameter("@nr_calcado", DbType.Int32, intCalcado))
            oCommand.Parameters.Add(New Parameter("@nr_roupa", DbType.String, 5, strRoupa))
            oCommand.ExecuteNonQuery()
            oRetorno = True
        Catch ex As Exception
            oRetorno = False
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
        End Try
        Return oRetorno

    End Function

End Class
