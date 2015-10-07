Public Class Presenca

    Implements ICrud(Of Model.Presenca, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.Presenca) As Boolean Implements ICrud(Of Model.Presenca, Integer).Delete

        Dim oDados As Data.Presenca = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Presenca
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Presenca Implements ICrud(Of Model.Presenca, Integer).Find

        Dim oDados As Data.Presenca = Nothing
        Dim lstRetorno As IList(Of Model.Presenca) = Nothing

        Try
            oDados = New Data.Presenca
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.Presenca) As Boolean Implements ICrud(Of Model.Presenca, Integer).Insert

        Dim oDados As Data.Presenca = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Presenca
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function InsertLote(lstFamilia As IList(Of Model.Presenca)) As Boolean

        Dim blnRetorno As Boolean = False
        Dim intCont As Integer = 0
        Try
            For Each oDado As Model.Presenca In lstFamilia
                blnRetorno = Insert(oDado)
                If Not blnRetorno Then
                    Throw New Exception("Tentativa de Gravar Presença falhou. Antes foram gravados " + intCont.ToString + " de " + lstFamilia.Count + " registros.")
                End If
                intCont = intCont + 1
            Next
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Presenca) Implements ICrud(Of Model.Presenca, Integer).LoadAll

        Dim oDados As Data.Presenca = Nothing
        Dim lstRetorno As IList(Of Model.Presenca) = Nothing

        Try
            oDados = New Data.Presenca
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Function Load(intReuniao As Integer) As IList(Of Model.Familia)

        Dim oDados As Data.Presenca = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing

        Try
            oDados = New Data.Presenca
            lstRetorno = oDados.Load(intReuniao)
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.Presenca) As Boolean Implements ICrud(Of Model.Presenca, Integer).Update

        Dim oDados As Data.Presenca = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Presenca
            blnRetorno = oDados.Update(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function ObterPresencaPorMae(intFamilia As Integer, intAno As Integer) As List(Of Model.FamiliaPresenca)

        Dim oDados As Data.Presenca = Nothing
        Dim lstRetorno As List(Of Model.FamiliaPresenca) = Nothing

        Try
            oDados = New Data.Presenca
            lstRetorno = oDados.ObterPresencaPorMae(intFamilia, intAno)
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function
End Class
