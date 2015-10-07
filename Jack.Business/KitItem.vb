Public Class KitItem
    Implements ICrud(Of Model.KitItem, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.KitItem) As Boolean Implements ICrud(Of Model.KitItem, Integer).Delete
        Dim oDados As Data.KitItem = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.KitItem
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.KitItem Implements ICrud(Of Model.KitItem, Integer).Find

        Dim oDados As Data.KitItem = Nothing
        Dim lstRetorno As IList(Of Model.KitItem) = Nothing

        Try
            oDados = New Data.KitItem
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.KitItem) As Boolean Implements ICrud(Of Model.KitItem, Integer).Insert
        Dim oDados As Data.KitItem = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.KitItem
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.KitItem) Implements ICrud(Of Model.KitItem, Integer).LoadAll
        Dim oDados As Data.KitItem = Nothing
        Dim lstRetorno As IList(Of Model.KitItem) = Nothing

        Try
            oDados = New Data.KitItem
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.KitItem) As Boolean Implements ICrud(Of Model.KitItem, Integer).Update
        Dim oDados As Data.KitItem = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.KitItem
            blnRetorno = oDados.Update(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadKitItemByKit(intKit As Integer) As IList(Of Model.KitItem)
        Dim oDados As Data.KitItem = Nothing
        Dim lstRetorno As IList(Of Model.KitItem) = Nothing

        Try
            oDados = New Data.KitItem
            lstRetorno = oDados.LoadKitItemByKit(intKit)
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

End Class
