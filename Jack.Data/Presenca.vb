Imports Consumer.Data.Basic.Data
Imports System.Data

Public Class Presenca
    Inherits BaseData(Of Model.Presenca, Integer)

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Insert(ByVal oTipo As Model.Presenca) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.Presenca) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.Presenca) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.Presenca

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.Presenca)

        Return MyBase.LoadAll

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Function Load(intReuniao As Integer) As IList(Of Model.Familia)

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing
        Dim dtDados As DataTable = Nothing
        Dim objDados As Model.Familia = Nothing
        Try
            lstRetorno = New List(Of Model.Familia)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_lista_maes_reuniao"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@id_reuniao", System.Data.DbType.Int32, 75, intReuniao))
            dtDados = oCommand.GetDataTable()
            For Each dr As DataRow In dtDados.Rows
                objDados = New Model.Familia()
                objDados.Codigo = Convert.ToInt32(dr("id_familia").ToString())
                objDados.Familia = dr("nm_mae").ToString()
                objDados.IsSacolinha = dr("is_sacolinha").ToString()
                objDados.IsConsistente = dr("is_consistente").ToString()
                objDados.Status = New Model.Status(Convert.ToInt32(dr("id_status")), dr("ds_status").ToString())
                lstRetorno.Add(objDados)
            Next
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oCommand.Dispose()
            objDados = Nothing
            dtDados = Nothing
        End Try
        Return lstRetorno

    End Function

    Public Function ObterPresencaPorMae(intFamilia As Integer, intAno As Integer) As List(Of Model.FamiliaPresenca)
        Dim oDados As Command = Nothing
        Dim lstDados As List(Of Model.FamiliaPresenca) = Nothing
        Dim objDados As Model.FamiliaPresenca = Nothing
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")
            dtDados = New DataTable

            oDados.CommandText = "pr_rel_resenca_reuniao_mae"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            oDados.Parameters.Add(New Parameter("@ano_corrente", DbType.Int32, intAno))
            dtDados = oDados.GetDataTable

            'fa.nm_mae, fa.nr_nivel_espera, ra.dt_reuniao

            lstDados = New List(Of Model.FamiliaPresenca)

            For Each dr As DataRow In dtDados.Rows
                objDados = New Model.FamiliaPresenca
                objDados.Familia = dr("nm_mae").ToString()
                objDados.Nivel = Convert.ToInt32(dr("nr_nivel_espera"))
                objDados.Data = Convert.ToDateTime(dr("dt_reuniao"))
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
