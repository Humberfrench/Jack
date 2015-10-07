Public Class Kit
    Implements ICrud(Of Model.Kit, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.Kit) As Boolean Implements ICrud(Of Model.Kit, Integer).Delete
        Dim oDados As Data.Kit = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Kit
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Kit Implements ICrud(Of Model.Kit, Integer).Find

        Dim oDados As Data.Kit = Nothing
        Dim lstRetorno As IList(Of Model.Kit) = Nothing

        Try
            oDados = New Data.Kit
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.Kit) As Boolean Implements ICrud(Of Model.Kit, Integer).Insert
        Dim oDados As Data.Kit = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Kit
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Kit) Implements ICrud(Of Model.Kit, Integer).LoadAll
        Dim oDados As Data.Kit = Nothing
        Dim lstRetorno As IList(Of Model.Kit) = Nothing

        Try
            oDados = New Data.Kit
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.Kit) As Boolean Implements ICrud(Of Model.Kit, Integer).Update
        Dim oDados As Data.Kit = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Kit
            blnRetorno = oDados.Update(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function
End Class
