Public Class Familia
    Implements ICrud(Of Model.Familia, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.Familia) As Boolean Implements ICrud(Of Model.Familia, Integer).Delete
        Dim oDados As Data.Familia = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Familia
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Familia Implements ICrud(Of Model.Familia, Integer).Find

        Dim oDados As Data.Familia = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing

        Try
            oDados = New Data.Familia
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.Familia) As Boolean Implements ICrud(Of Model.Familia, Integer).Insert
        Dim oDados As Data.Familia = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Familia
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Familia) Implements ICrud(Of Model.Familia, Integer).LoadAll
        Dim oDados As Data.Familia = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing

        Try
            oDados = New Data.Familia
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function ObterChamada(intReuniao As Integer) As List(Of Model.Familia)
        Dim oDados As Data.Familia = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing

        Try
            oDados = New Data.Familia
            lstRetorno = oDados.ObterChamada(intReuniao)
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function



    Public Function Update(oTipo As Model.Familia) As Boolean Implements ICrud(Of Model.Familia, Integer).Update
        Dim oDados As Data.Familia = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Familia
            blnRetorno = oDados.Update(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function GravarLote(lstNomeMaes As List(Of String)) As List(Of Model.FamiliaLote)

        Dim lstLote As List(Of Model.FamiliaLote) = Nothing
        Dim oDados As Data.Familia = Nothing
        Dim strRetorno As String = String.Empty
        Dim oFamilia As Model.Familia = Nothing
        Dim oFamiliaLote As Model.FamiliaLote = Nothing

        Try
            oDados = New Data.Familia()
            lstLote = New List(Of Model.FamiliaLote)

            For Each strMae As String In lstNomeMaes
                oFamilia = New Model.Familia()
                oFamiliaLote = New Model.FamiliaLote()

                oFamilia.Codigo = 0
                oFamilia.Familia = strMae
                oFamilia.IsConsistente = "N"
                oFamilia.IsSacolinha = "N"
                strRetorno = oDados.GravarLote(oFamilia)

                oFamiliaLote.Nome = strMae
                oFamiliaLote.Status = strRetorno
                lstLote.Add(oFamiliaLote)
            Next

        Catch ex As Exception
            Throw ex
        Finally
            oDados = Nothing
            strRetorno = String.Empty
            oFamilia = Nothing
            oFamiliaLote = Nothing
        End Try

        Return lstLote

    End Function

End Class
