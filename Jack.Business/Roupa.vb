Public Class Roupa

    Implements ICrud(Of Model.Roupa, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.Roupa) As Boolean Implements ICrud(Of Model.Roupa, Integer).Delete
        Dim oDados As Data.Roupa = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Roupa
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Roupa Implements ICrud(Of Model.Roupa, Integer).Find

        Dim oDados As Data.Roupa = Nothing
        Dim lstRetorno As IList(Of Model.Roupa) = Nothing

        Try
            oDados = New Data.Roupa
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.Roupa) As Boolean Implements ICrud(Of Model.Roupa, Integer).Insert
        Dim oDados As Data.Roupa = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Roupa
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Roupa) Implements ICrud(Of Model.Roupa, Integer).LoadAll
        Dim oDados As Data.Roupa = Nothing
        Dim lstRetorno As IList(Of Model.Roupa) = Nothing

        Try
            oDados = New Data.Roupa
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.Roupa) As Boolean Implements ICrud(Of Model.Roupa, Integer).Update
        Dim oDados As Data.Roupa = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Roupa
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
