Imports Jack.Extensions.Basic
Public Class Calcado

    Implements ICrud(Of Model.Calcado, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.Calcado) As Boolean Implements ICrud(Of Model.Calcado, Integer).Delete
        Dim oDados As Data.Calcado = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Calcado
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Calcado Implements ICrud(Of Model.Calcado, Integer).Find

        Dim oDados As Data.Calcado = Nothing
        Dim lstRetorno As IList(Of Model.Calcado) = Nothing

        Try
            oDados = New Data.Calcado
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.Calcado) As Boolean Implements ICrud(Of Model.Calcado, Integer).Insert
        Dim oDados As Data.Calcado = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Calcado
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Calcado) Implements ICrud(Of Model.Calcado, Integer).LoadAll
        Dim oDados As Data.Calcado = Nothing
        Dim lstRetorno As IList(Of Model.Calcado) = Nothing

        Try
            oDados = New Data.Calcado
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.Calcado) As Boolean Implements ICrud(Of Model.Calcado, Integer).Update
        Dim oDados As Data.Calcado = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Calcado
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
