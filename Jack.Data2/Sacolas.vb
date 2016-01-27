Imports Consumer.Data.Basic.Data
Imports System.Data

Public Class Sacolas

    ''' <summary>
    ''' Processa as Sacolas
    ''' </summary>
    ''' <param name="intAno"></param>
    ''' <returns>Lista de Pessoas</returns>
    ''' <remarks>Este é um processo Simples e Poderá ser usado para consistir as presenças e Sacolas</remarks>
    Public Function ProcessaSacolas(intAno As Integer) As List(Of Model.Sacolas)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Sacolas) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Sacolas = Nothing
        Try
            lstRetorno = New List(Of Model.Sacolas)

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_gerar_sacolinhas"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@nr_ano", System.Data.DbType.Int32, 75, intAno))
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Sacolas()
                oRetorno.NumeroSacola = Convert.ToInt32(dr("id_sacolinha").ToString())
                oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr("nr_sacola_familia").ToString())
                oRetorno.CodigoFamilia = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr("id_familia_rep").ToString())
                oRetorno.CodigoCrianca = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.NomeMae = dr("nm_mae").ToString()
                oRetorno.NomeMaeRep = dr("nm_mae_rep").ToString()
                oRetorno.NomeCrianca = dr("nm_crianca").ToString()
                oRetorno.Idade = Convert.ToInt32(dr("nr_idade").ToString())
                oRetorno.MedidaIdade = dr("ds_medida_idade").ToString()
                oRetorno.NumeroNivel = Convert.ToInt32(dr("nr_nivel").ToString())
                oRetorno.CodigoKit = Convert.ToInt32(dr("id_kit").ToString())
                oRetorno.CodigoStatus = Convert.ToInt32(dr("id_status").ToString())
                oRetorno.DescricaoKit = dr("ds_kit").ToString()
                oRetorno.DescricaoStatus = dr("ds_status").ToString()
                oRetorno.Sexo = dr("ds_sexo").ToString()
                oRetorno.Impresso = dr("is_printed").ToString()
                lstRetorno.Add(oRetorno)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Function ObterSacolas(intKit As Integer, intNivel As Integer, isPrinted As String) As List(Of Model.Sacolas)


        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Sacolas) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Sacolas = Nothing
        Try
            lstRetorno = New List(Of Model.Sacolas)

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_print_sacolas"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            '[pr_print_sacolas] (@ds_sexo varchar(1), @id_kit int, @nr_nivel int, @is_printed varchar(1))

            oCommand.Parameters.Add(New Parameter("@id_kit", System.Data.DbType.Int32, intKit))
            oCommand.Parameters.Add(New Parameter("@nr_nivel", System.Data.DbType.Int32, intNivel))
            oCommand.Parameters.Add(New Parameter("@is_printed", System.Data.DbType.String, 1, isPrinted))
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Sacolas()
                oRetorno.NumeroSacola = Convert.ToInt32(dr("id_sacolinha").ToString())
                oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr("nr_sacola_familia").ToString())
                oRetorno.CodigoFamilia = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr("id_familia_rep").ToString())
                oRetorno.CodigoCrianca = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.NomeMae = dr("nm_mae").ToString()
                oRetorno.NomeMaeRep = dr("nm_mae_rep").ToString()
                oRetorno.NomeCrianca = dr("nm_crianca").ToString()
                oRetorno.Idade = Convert.ToInt32(dr("nr_idade").ToString())
                oRetorno.MedidaIdade = dr("ds_medida_idade").ToString()
                oRetorno.NumeroNivel = Convert.ToInt32(dr("nr_nivel").ToString())
                oRetorno.CodigoKit = Convert.ToInt32(dr("id_kit").ToString())
                oRetorno.CodigoStatus = Convert.ToInt32(dr("id_status").ToString())
                oRetorno.DescricaoKit = dr("ds_kit").ToString()
                oRetorno.DescricaoStatus = dr("ds_status").ToString()
                oRetorno.Sexo = dr("ds_sexo").ToString()
                oRetorno.Impresso = dr("is_printed").ToString()
                lstRetorno.Add(oRetorno)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Function ObterSacolasLivres(intKit As Integer, intNivel As Integer, isPrinted As String) As List(Of Model.Sacolas)


        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Sacolas) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Sacolas = Nothing
        Try
            lstRetorno = New List(Of Model.Sacolas)

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_print_sacolas_livres"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            '[pr_print_sacolas] (@ds_sexo varchar(1), @id_kit int, @nr_nivel int, @is_printed varchar(1))

            oCommand.Parameters.Add(New Parameter("@id_kit", System.Data.DbType.Int32, intKit))
            oCommand.Parameters.Add(New Parameter("@nr_nivel", System.Data.DbType.Int32, intNivel))
            oCommand.Parameters.Add(New Parameter("@is_printed", System.Data.DbType.String, 1, isPrinted))
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Sacolas()
                oRetorno.NumeroSacola = Convert.ToInt32(dr("id_sacolinha").ToString())
                oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr("nr_sacola_familia").ToString())
                oRetorno.CodigoFamilia = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr("id_familia_rep").ToString())
                oRetorno.CodigoCrianca = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.NomeMae = dr("nm_mae").ToString()
                oRetorno.NomeMaeRep = dr("nm_mae_rep").ToString()
                oRetorno.NomeCrianca = dr("nm_crianca").ToString()
                oRetorno.Idade = Convert.ToInt32(dr("nr_idade").ToString())
                oRetorno.MedidaIdade = dr("ds_medida_idade").ToString()
                oRetorno.NumeroNivel = Convert.ToInt32(dr("nr_nivel").ToString())
                oRetorno.CodigoKit = Convert.ToInt32(dr("id_kit").ToString())
                oRetorno.CodigoStatus = Convert.ToInt32(dr("id_status").ToString())
                oRetorno.DescricaoKit = dr("ds_kit").ToString()
                oRetorno.DescricaoStatus = dr("ds_status").ToString()
                oRetorno.Sexo = dr("ds_sexo").ToString()
                oRetorno.Impresso = dr("is_printed").ToString()
                lstRetorno.Add(oRetorno)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Function ObterSacolas() As List(Of Model.Sacolas)


        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Sacolas) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Sacolas = Nothing
        Try
            lstRetorno = New List(Of Model.Sacolas)

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_print_sacolas_todas"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Sacolas()
                oRetorno.NumeroSacola = Convert.ToInt32(dr("id_sacolinha").ToString())
                oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr("nr_sacola_familia").ToString())
                oRetorno.CodigoFamilia = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr("id_familia_rep").ToString())
                oRetorno.CodigoCrianca = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.NomeMae = dr("nm_mae").ToString()
                oRetorno.NomeMaeRep = dr("nm_mae_rep").ToString()
                oRetorno.NomeCrianca = dr("nm_crianca").ToString()
                oRetorno.Idade = Convert.ToInt32(dr("nr_idade").ToString())
                oRetorno.MedidaIdade = dr("ds_medida_idade").ToString()
                oRetorno.NumeroNivel = Convert.ToInt32(dr("nr_nivel").ToString())
                oRetorno.CodigoKit = Convert.ToInt32(dr("id_kit").ToString())
                oRetorno.CodigoStatus = Convert.ToInt32(dr("id_status").ToString())
                oRetorno.DescricaoKit = dr("ds_kit").ToString()
                oRetorno.DescricaoStatus = dr("ds_status").ToString()
                oRetorno.Sexo = dr("ds_sexo").ToString()
                oRetorno.Impresso = dr("is_printed").ToString()
                lstRetorno.Add(oRetorno)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Function ObterSacolas(strListSacolasIn As String) As List(Of Model.Sacolas)


        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Sacolas) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.Sacolas = Nothing
        Try
            lstRetorno = New List(Of Model.Sacolas)

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_print_sacolas_execute"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@list_sacolas", System.Data.DbType.String, strListSacolasIn))
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.Sacolas()
                oRetorno.NumeroSacola = Convert.ToInt32(dr("id_sacolinha").ToString())
                oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr("nr_sacola_familia").ToString())
                oRetorno.CodigoFamilia = Convert.ToInt32(dr("id_familia").ToString())
                oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr("id_familia_rep").ToString())
                oRetorno.CodigoCrianca = Convert.ToInt32(dr("id_crianca").ToString())
                oRetorno.Idade = Convert.ToInt32(dr("nr_idade").ToString())
                oRetorno.MedidaIdade = dr("ds_medida_idade").ToString()
                oRetorno.NomeCrianca = dr("nm_crianca").ToString()
                oRetorno.NomeMae = dr("nm_mae").ToString()
                oRetorno.NomeMaeRep = dr("nm_mae_rep").ToString()
                oRetorno.NumeroNivel = Convert.ToInt32(dr("nr_nivel").ToString())
                oRetorno.CodigoKit = Convert.ToInt32(dr("id_kit").ToString())
                oRetorno.CodigoStatus = Convert.ToInt32(dr("id_status").ToString())
                oRetorno.DescricaoKit = dr("ds_kit").ToString()
                oRetorno.DescricaoStatus = dr("ds_status").ToString()
                oRetorno.Sexo = dr("ds_sexo").ToString()
                oRetorno.Impresso = dr("is_printed").ToString()
                oRetorno.Calcado = dr("nr_calcado").ToString()
                oRetorno.Roupa = dr("nr_roupa").ToString()
                lstRetorno.Add(oRetorno)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Function ObterKitSacolas(intKit As Integer) As List(Of Model.KitSacola)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.KitSacola) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim oRetorno As Model.KitSacola = Nothing
        Try
            lstRetorno = New List(Of Model.KitSacola)

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_mostrar_itens_kit"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_kit", System.Data.DbType.Int16, intKit))
            dtDados = oCommand.GetDataTable()

            For Each dr As DataRow In dtDados.Rows
                oRetorno = New Model.KitSacola()
                oRetorno.Ordem = Convert.ToInt32(dr("nr_ordem").ToString())
                oRetorno.MsgOpcional = dr("msg_opcional").ToString()
                oRetorno.KitItem = dr("ds_tipo_item").ToString()
                oRetorno.NomeKit = dr("ds_kit").ToString()
                oRetorno.Sexo = dr("ds_sexo").ToString()
                lstRetorno.Add(oRetorno)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
            oRetorno = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Sub GravarLogSacolas(intSacola As Integer)

        Dim oCommand As Command = Nothing
        Try

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_update_print"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_sacola", System.Data.DbType.Int16, intSacola))
            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
        End Try

    End Sub

    Public Function AddSacolaCrianca(intCrianca As Integer) As Boolean

        Dim oCommand As Command = Nothing
        Dim blnRetorno As Boolean = False

        Try

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_add_crianca_sacola"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_crianca", System.Data.DbType.Int16, intCrianca))
            oCommand.ExecuteNonQuery()
            blnRetorno = True

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
        End Try
        Return blnRetorno

    End Function

    Public Function AddSacolaColaboradorCrianca(intCrianca As Integer, intColaborador As Integer, intAno As Integer, isDevolvida As Boolean) As Boolean

        Dim oCommand As Command = Nothing
        Dim blnRetorno As Boolean = False

        Try

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_add_sacola_colaborador_crianca"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_crianca", System.Data.DbType.Int16, intCrianca))
            oCommand.Parameters.Add(New Parameter("@id_colaborador", System.Data.DbType.Int16, intColaborador))
            oCommand.Parameters.Add(New Parameter("@int_ano", System.Data.DbType.Int16, intAno))
            oCommand.Parameters.Add(New Parameter("@is_devolvida", System.Data.DbType.String, 1, isDevolvida))
            oCommand.ExecuteNonQuery()
            blnRetorno = True

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
        End Try
        Return blnRetorno

    End Function


    Public Function AddSacolaColaboradorSacola(intSacola As Integer, intColaborador As Integer, intAno As Integer, isDevolvida As Boolean) As Boolean

        Dim oCommand As Command = Nothing
        Dim blnRetorno As Boolean = False

        Try

            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_add_sacola_colaborador_sacola"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_sacola", System.Data.DbType.Int16, intSacola))
            oCommand.Parameters.Add(New Parameter("@id_colaborador", System.Data.DbType.Int16, intColaborador))
            oCommand.Parameters.Add(New Parameter("@int_ano", System.Data.DbType.Int16, intAno))
            oCommand.Parameters.Add(New Parameter("@is_devolvida", System.Data.DbType.String, 1, isDevolvida))
            oCommand.ExecuteNonQuery()
            blnRetorno = True

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
        End Try
        Return blnRetorno

    End Function

End Class
