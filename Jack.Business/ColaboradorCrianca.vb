Public Class ColaboradorCrianca
    Implements ICrud(Of Model.ColaboradorCrianca, Integer)

    Public Sub New()

    End Sub

#Region "Outros Métodos"

    Public Function ObterCriancasPorColaborador(intColaborador As Integer, intAno As Integer) As List(Of Model.ColaboradorCrianca)
        Dim oDados As Data.ColaboradorCrianca = Nothing
        Dim lstRetorno As IList(Of Model.ColaboradorCrianca) = Nothing

        Try
            oDados = New Data.ColaboradorCrianca
            lstRetorno = oDados.ObterCriancasPorColaborador(intColaborador, intAno)
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

#End Region

#Region "Crud"
    Public Function Delete(oTipo As Model.ColaboradorCrianca) As Boolean Implements ICrud(Of Model.ColaboradorCrianca, Integer).Delete
        Dim oDados As Data.ColaboradorCrianca = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.ColaboradorCrianca
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.ColaboradorCrianca Implements ICrud(Of Model.ColaboradorCrianca, Integer).Find

        Dim oDados As Data.ColaboradorCrianca = Nothing
        Dim lstRetorno As IList(Of Model.ColaboradorCrianca) = Nothing

        Try
            oDados = New Data.ColaboradorCrianca
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.ColaboradorCrianca) As Boolean Implements ICrud(Of Model.ColaboradorCrianca, Integer).Insert
        Dim oDados As Data.ColaboradorCrianca = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.ColaboradorCrianca
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.ColaboradorCrianca) Implements ICrud(Of Model.ColaboradorCrianca, Integer).LoadAll
        Dim oDados As Data.ColaboradorCrianca = Nothing
        Dim lstRetorno As IList(Of Model.ColaboradorCrianca) = Nothing

        Try
            oDados = New Data.ColaboradorCrianca
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.ColaboradorCrianca) As Boolean Implements ICrud(Of Model.ColaboradorCrianca, Integer).Update
        Dim oDados As Data.ColaboradorCrianca = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.ColaboradorCrianca
            blnRetorno = oDados.Update(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function
#End Region

End Class
