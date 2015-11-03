Imports System.Data
Imports Consumer.Data.Basic.Data

Public Class Representante

    Public Sub New()
        MyBase.New()
    End Sub

    Public Function ObterMaes(intFamilia As Integer) As List(Of Model.Familia)

        Dim oDados As Command = Nothing
        Dim lstDados As List(Of Model.Familia) = Nothing
        Dim objDados As Model.Familia = Nothing
        Dim dtDados As DataTable = Nothing

        Try
            oDados = New Command("CECAMKey")
            dtDados = New DataTable

            oDados.CommandText = "pr_list_maes_representadas"
            oDados.CommandType = CommandType.StoredProcedure

            oDados.Parameters.Add(New Parameter("@id_familia", DbType.Int32, intFamilia))
            dtDados = oDados.GetDataTable


            lstDados = New List(Of Model.Familia)

            For Each dr As DataRow In dtDados.Rows
                objDados = New Model.Familia
                objDados.Codigo = Convert.ToInt32(dr("id_familia"))
                objDados.Familia = dr("nm_mae").ToString()
                objDados.Contato = dr("ds_contato").ToString()
                objDados.IsConsistente = dr("is_consistente").ToString()
                objDados.IsSacolinha = dr("is_sacolinha").ToString()
                objDados.Nivel = Convert.ToInt32(dr("nr_nivel_espera"))
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

    Public Function Add(intFamilaRepresentante As Integer, intFamilaRepresentada As Integer) As Boolean

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing
        Dim oRetorno As Boolean = False
        Try
            lstRetorno = New List(Of Model.Familia)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_add_representante"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@intFamilaRepresentante", System.Data.DbType.Int32, 75, intFamilaRepresentante))
            oCommand.Parameters.Add(New Parameter("@intFamilaRepresentada", System.Data.DbType.Int32, 75, intFamilaRepresentada))
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
    Public Function Del(intFamilaRepresentante As Integer, intFamilaRepresentada As Integer) As Boolean

        Dim oCommand As Command = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing
        Dim oRetorno As Boolean = False
        Try
            lstRetorno = New List(Of Model.Familia)
            oCommand = New Command("CECAMKey")
            oCommand.CommandText = "pr_del_representante"
            oCommand.CommandType = System.Data.CommandType.StoredProcedure
            oCommand.Parameters.Add(New Parameter("@intFamilaRepresentante", System.Data.DbType.Int32, 75, intFamilaRepresentante))
            oCommand.Parameters.Add(New Parameter("@intFamilaRepresentada", System.Data.DbType.Int32, 75, intFamilaRepresentada))
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
