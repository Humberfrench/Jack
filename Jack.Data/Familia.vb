Imports System.Data
Imports Consumer.Data.Basic.Data
Public Class Familia
    Inherits BaseData(Of Model.Familia, Integer)

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Insert(ByVal oTipo As Model.Familia) As Boolean

        Return MyBase.Insert(oTipo)

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Update(ByVal oTipo As Model.Familia) As Boolean

        Return MyBase.Update(oTipo)

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Overrides Function Delete(ByVal oTipo As Model.Familia) As Boolean

        Return MyBase.Delete(oTipo)

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Overrides Function Find(ByVal Identifier As Integer) As Model.Familia

        Return MyBase.Find(Identifier)

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Overrides Function LoadAll() As IList(Of Model.Familia)

        Return MyBase.LoadAll

    End Function

    'Overrides Function LoadAll2() As IList(Of Model.Familia)

    '    Dim oCriteria = oSession.CreateCriteria("Familia", "F").CreateAlias("F.Status", "S")




    'End Function

    Public Function GravarLote(oFamilia As Model.Familia) As String
        Dim oCommand As Command = Nothing
        Dim strRetorno As String = String.Empty
        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_add_familia_lote"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@nm_mae", System.Data.DbType.String, 75, oFamilia.Familia))
            oCommand.Parameters.Add(New Parameter("@is_sacolinha", System.Data.DbType.String, 1, oFamilia.IsSacolinha))
            oCommand.Parameters.Add(New Parameter("@is_consistente", System.Data.DbType.String, 1, oFamilia.IsConsistente))
            strRetorno = oCommand.Execute().ToString()
        Catch ex As Exception
            Throw ex
        Finally
            oCommand.Dispose()
            oCommand = Nothing
        End Try
        Return strRetorno
    End Function

    Public Function ObterChamada(intReuniao As Integer) As List(Of Model.Familia)

        Dim oCommand As Command = Nothing
        Dim lstDados As List(Of Model.Familia) = Nothing
        Dim objDados As Model.Familia = Nothing
        Dim dtDados As DataTable = Nothing

        Try
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_chamada_nomes"
            oCommand.Parameters.Add(New Parameter("@id_reuniao", DbType.Int16, intReuniao)
                                     )
            oCommand.CommandType = System.Data.CommandType.StoredProcedure

            dtDados = oCommand.GetDataTable()

            lstDados = New List(Of Model.Familia)

            For Each dr As DataRow In dtDados.Rows
                objDados = New Model.Familia
                objDados.Codigo = Convert.ToInt32(dr("id_familia"))
                objDados.NomeFamilia = dr("nm_mae").ToString()
                lstDados.Add(objDados)
            Next

        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            dtDados = Nothing
            objDados = Nothing
            oCommand.Dispose()
            oCommand = Nothing
        End Try

        Return lstDados

    End Function

End Class
