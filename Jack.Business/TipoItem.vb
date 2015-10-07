Public Class TipoItem
    Implements ICrud(Of Model.TipoItem, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.TipoItem) As Boolean Implements ICrud(Of Model.TipoItem, Integer).Delete
        Dim oDados As Data.TipoItem = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.TipoItem
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.TipoItem Implements ICrud(Of Model.TipoItem, Integer).Find

        Dim oDados As Data.TipoItem = Nothing
        Dim lstRetorno As IList(Of Model.TipoItem) = Nothing

        Try
            oDados = New Data.TipoItem
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.TipoItem) As Boolean Implements ICrud(Of Model.TipoItem, Integer).Insert
        Dim oDados As Data.TipoItem = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.TipoItem
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.TipoItem) Implements ICrud(Of Model.TipoItem, Integer).LoadAll
        Dim oDados As Data.TipoItem = Nothing
        Dim lstRetorno As IList(Of Model.TipoItem) = Nothing

        Try
            oDados = New Data.TipoItem
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.TipoItem) As Boolean Implements ICrud(Of Model.TipoItem, Integer).Update
        Dim oDados As Data.TipoItem = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.TipoItem
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
