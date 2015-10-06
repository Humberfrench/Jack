Imports Consumer.Data.Basic.Data
Imports System.Data

Public Class Processos

#Region "Batch - Processos"

    ''' <summary>
    ''' Processa Presença de Representante na Reunião
    ''' </summary>
    ''' <param name="intReuniao">Código da Reunião</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function ProcessaPresencasRepresentantesReuniao(intReuniao As Integer) As Boolean
        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing
        Dim oRetorno As Boolean = False
        Try
            lstRetorno = New List(Of Model.Familia)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_upd_presenca_representado"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_reuniao", System.Data.DbType.Int32, 75, intReuniao))
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

    ''' <summary>
    ''' Atualiza os Dados das Crianças
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosCrianca() As Boolean
        Dim oCommand As Command = Nothing
        Dim oRetorno As Boolean = False
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_atualiza_dados_crianca"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
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

    ''' <summary>
    ''' Atualiza os Dados das Crianças
    ''' </summary>
    ''' <param name="intCrianca">Código da Criança</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosCrianca(intCrianca As Integer) As Boolean
        Dim oCommand As Command = Nothing
        Dim oRetorno As Boolean = False
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_atualiza_dados_crianca_unitario"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_crianca", DbType.Int32, intCrianca))
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
    ''' <summary>
    ''' Atualiza os Dados das Mães
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosMae() As Boolean
        Dim oCommand As Command = Nothing
        Dim oRetorno As Boolean = False
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "[pr_inativa_mae_sem_crianca]"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
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

    Public Function ProcesaPresenca(intAno As Integer) As Boolean
        Dim oCommand As Command = Nothing
        Dim oRetorno As Boolean = False
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "[pr_upd_presenca_representado_todos]"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@nr_Ano", DbType.Int32, intAno))
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

    Public Function ProcesaGeral(intAno As Integer) As Boolean
        Dim oCommand As Command = Nothing
        Dim oRetorno As Boolean = False
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "[pr_processa_sacola]"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@nr_Ano", DbType.Int32, CObj(intAno)))
            oCommand.Parameters.Add(New Parameter("@is_mostrar_resultado", DbType.String, 1, "N"))
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


    ''' <summary>
    ''' Relatório de Inconsistências de Crianças
    ''' </summary>
    ''' <returns>List(Of Model.CriancasInconsistentes) - Lista de Crianças Inconsistentes</returns>
    ''' <remarks></remarks>
    Public Function ObterCriancasInconsistentes() As List(Of Model.CriancasInconsistentes)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.CriancasInconsistentes) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.CriancasInconsistentes = Nothing

        Try
            lstRetorno = New List(Of Model.CriancasInconsistentes)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_rel_inconsist_criancas"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            dtDados = oCommand.GetDataTable()
            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.CriancasInconsistentes()
                oRetorno.Codigo = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.NomeMae = dr("nm_mae").ToString()
                oRetorno.Nome = dr("nm_crianca").ToString()
                oRetorno.DescricaoIdade = dr("Idade").ToString()
                oRetorno.DescricaoStatus = dr("ds_status").ToString()
                oRetorno.DataNascimento = Convert.ToDateTime(dr("dt_nascimento").ToString())
                oRetorno.Sexo = dr("ds_sexo").ToString()
                oRetorno.Calcado = Convert.ToInt32(dr("nr_calcado").ToString())
                oRetorno.Roupa = dr("nr_roupa").ToString()
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

    Public Function ObterFamiliasInconsistentes() As List(Of Model.Familia)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Familia = Nothing

        Try
            lstRetorno = New List(Of Model.Familia)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_rel_inconsist_familia"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            dtDados = oCommand.GetDataTable()
            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Familia()
                oRetorno.Codigo = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.Familia = dr("nm_mae").ToString()
                oRetorno.Nivel = Convert.ToInt32(dr("nr_nivel_espera").ToString())
                oRetorno.IsSacolinha = dr("is_sacolinha").ToString()
                oRetorno.IsConsistente = dr("is_consistente").ToString()
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

    Public Function ObterFamiliasComZeroCriancas() As List(Of Model.Familia)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Familia = Nothing

        Try
            lstRetorno = New List(Of Model.Familia)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_rel_familia_crianca_zero"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            dtDados = oCommand.GetDataTable()
            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Familia()
                oRetorno.Codigo = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.Familia = dr("nm_mae").ToString()
                oRetorno.Nivel = Convert.ToInt32(dr("nr_nivel_espera").ToString())
                oRetorno.IsSacolinha = dr("is_sacolinha").ToString()
                oRetorno.IsConsistente = dr("is_consistente").ToString()
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
