Imports Consumer.Data.Basic.Data
Imports System.Data

Public Class FamiliaCrianca

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="intCrianca">Criança</param>
    ''' <param name="intFamilia">Familia</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Function Insert(ByVal intFamilia As Integer, intCrianca As Integer) As Boolean
        Dim oDados As Command = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Command("CECAMKey")

            oDados.CommandText = "pr_AddCriancasFamilia"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            oDados.Parameters.Add(New Parameter("@id_crianca", DbType.Int32, intCrianca))
            oDados.Execute()
            blnRetorno = True

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function


    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="intFamilia">Familia</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Function DeleteFamilia(intFamilia As Integer) As Boolean
        Dim oDados As Command = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Command("CECAMKey")

            oDados.CommandText = "pr_DeleteAllCriancasFamilia"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            oDados.Execute()
            blnRetorno = True

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function


    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="intFamilia">Familia</param>
    ''' <param name="intCrianca">Criança</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Function DeleteCrianca(ByVal intFamilia As Integer, intCrianca As Integer) As Boolean
        Dim oDados As Command = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Command("CECAMKey")

            oDados.CommandText = "pr_DeleteCriancasFamilia"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            oDados.Parameters.Add(New Parameter("@id_crianca", DbType.Int32, intCrianca))
            oDados.Execute()
            blnRetorno = True

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function ObterCriancasByFamilia(intFamilia As Integer) As List(Of Model.Criancas)

        Dim oDados As Command = Nothing
        Dim lstDados As List(Of Model.Criancas) = Nothing
        Dim objDados As Model.Criancas = Nothing
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")
            dtDados = New DataTable

            oDados.CommandText = "pr_ObterCriancasFamilia"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            dtDados = oDados.GetDataTable


            lstDados = New List(Of Model.Criancas)

            For Each dr As DataRow In dtDados.Rows
                objDados = New Model.Criancas
                objDados.Codigo = Convert.ToInt32(dr("id_crianca"))
                objDados.Nome = dr("nm_crianca").ToString()
                objDados.Idade = Convert.ToInt32(dr("nr_idade"))
                objDados.MedidaIdade = dr("ds_medida_idade").ToString()
                objDados.DataNascimento = Convert.ToDateTime(dr("dt_nascimento"))
                objDados.Sexo = dr("ds_sexo").ToString()
                objDados.Calcado = Convert.ToInt32(dr("nr_calcado"))
                objDados.Roupa = dr("nr_roupa")
                objDados.Kit = Convert.ToInt32(dr("id_kit"))
                objDados.IsSacolinha = dr("is_sacolinha").ToString()
                objDados.IsConsistente = dr("is_consistente").ToString()
                objDados.IsMoralCrista = dr("is_moral_crista").ToString()
                objDados.StatusCodigo = Convert.ToInt32(dr("id_status"))
                objDados.StatusNome = dr("ds_status").ToString()
                objDados.Status = New Model.Status(Convert.ToInt32(dr("id_status")), dr("ds_status").ToString())
                lstDados.Add(objDados)
            Next
        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            objDados = Nothing
            dtDados = Nothing
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return lstDados

    End Function

    Public Function ObterCriancasByFamiliaWithRep(intFamilia As Integer) As List(Of Model.Criancas)

        Dim oDados As Command = Nothing
        Dim lstDados As List(Of Model.Criancas) = Nothing
        Dim objDados As Model.Criancas = Nothing
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")
            dtDados = New DataTable

            oDados.CommandText = "pr_ObterCriancasFamiliarep"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            dtDados = oDados.GetDataTable


            lstDados = New List(Of Model.Criancas)

            For Each dr As DataRow In dtDados.Rows
                objDados = New Model.Criancas
                objDados.Codigo = Convert.ToInt32(dr("id_crianca"))
                objDados.Nome = dr("nm_crianca").ToString()
                objDados.Idade = Convert.ToInt32(dr("nr_idade"))
                objDados.MedidaIdade = dr("ds_medida_idade").ToString()
                objDados.DataNascimento = Convert.ToDateTime(dr("dt_nascimento"))
                objDados.Sexo = dr("ds_sexo").ToString()
                objDados.Calcado = Convert.ToInt32(dr("nr_calcado"))
                objDados.Roupa = dr("nr_roupa")
                objDados.CalcadoPadrao = Convert.ToInt32(dr("nr_calcado_padrao"))
                objDados.RoupaPadrao = dr("nr_roupa_padrao")
                objDados.Kit = Convert.ToInt32(dr("id_kit"))
                objDados.IsSacolinha = dr("is_sacolinha").ToString()
                objDados.IsConsistente = dr("is_consistente").ToString()
                objDados.IsMoralCrista = dr("is_moral_crista").ToString()
                objDados.StatusCodigo = Convert.ToInt32(dr("id_status"))
                objDados.StatusNome = dr("ds_status").ToString()
                objDados.Status = New Model.Status(Convert.ToInt32(dr("id_status")), dr("ds_status").ToString())
                objDados.Familia = dr("nm_mae").ToString()
                lstDados.Add(objDados)
            Next
        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            objDados = Nothing
            dtDados = Nothing
            oDados.Dispose()
            oDados = Nothing
        End Try

        Return lstDados

    End Function

End Class
