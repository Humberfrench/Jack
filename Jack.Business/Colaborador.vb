Public Class Colaborador
    Implements ICrud(Of Model.Colaborador, Integer)

    Public Sub New()

    End Sub

#Region "Outros Métodos"

    Public Function ListaQuantidadeSacolasPorColaborador(intAno As Integer) As List(Of Model.Colaborador)

        Dim oDados As Data.Colaborador = Nothing
        Dim lstRetorno As IList(Of Model.Colaborador) = Nothing

        Try
            oDados = New Data.Colaborador
            lstRetorno = oDados.ListaQuantidadeSacolasPorColaborador(intAno)
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
    Public Function Delete(oTipo As Model.Colaborador) As Boolean Implements ICrud(Of Model.Colaborador, Integer).Delete
        Dim oDados As Data.Colaborador = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Colaborador
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Colaborador Implements ICrud(Of Model.Colaborador, Integer).Find

        Dim oDados As Data.Colaborador = Nothing
        Dim oRetorno As Model.Colaborador = Nothing

        Try
            oDados = New Data.Colaborador
            oRetorno = oDados.Find(Identifier)
        Catch ex As Exception
            oRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return oRetorno

    End Function

    Public Function Insert(oTipo As Model.Colaborador) As Boolean Implements ICrud(Of Model.Colaborador, Integer).Insert
        Dim oDados As Data.Colaborador = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Colaborador
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Colaborador) Implements ICrud(Of Model.Colaborador, Integer).LoadAll
        Dim oDados As Data.Colaborador = Nothing
        Dim lstRetorno As IList(Of Model.Colaborador) = Nothing

        Try
            oDados = New Data.Colaborador
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.Colaborador) As Boolean Implements ICrud(Of Model.Colaborador, Integer).Update
        Dim oDados As Data.Colaborador = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Colaborador
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
