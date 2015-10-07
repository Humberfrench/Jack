Public Class Status
    Implements ICrud(Of Model.Status, Integer)

    Public Sub New()

    End Sub

    Public Function Delete(oTipo As Model.Status) As Boolean Implements ICrud(Of Model.Status, Integer).Delete
        Dim oDados As Data.Status = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Status
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Status Implements ICrud(Of Model.Status, Integer).Find

        Dim oDados As Data.Status = Nothing
        Dim oRetorno As Model.Status = Nothing

        Try
            oDados = New Data.Status
            oRetorno = oDados.Find(Identifier)
        Catch ex As Exception
            oRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return oRetorno

    End Function

    Public Function Insert(oTipo As Model.Status) As Boolean Implements ICrud(Of Model.Status, Integer).Insert
        Dim oDados As Data.Status = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Status
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Private Function LoadAll() As IList(Of Model.Status) Implements ICrud(Of Model.Status, Integer).LoadAll
        Dim oDados As Data.Status = Nothing
        Dim lstRetorno As IList(Of Model.Status) = Nothing

        Try
            oDados = New Data.Status
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function LoadForCriancas() As IList(Of Model.Status)
        Dim lstRetorno As IList(Of Model.Status) = Nothing

        Try
            lstRetorno = (From oDado As Model.Status In LoadAll() Where oDado.NivelStatus = "T" Or oDado.NivelStatus = "C" Select oDado).ToList()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        End Try

        Return lstRetorno
    End Function

    Public Function LoadForFamilia() As IList(Of Model.Status)
        Dim lstRetorno As IList(Of Model.Status) = Nothing

        Try
            lstRetorno = (From oDado As Model.Status In LoadAll() Where oDado.NivelStatus = "T" Or oDado.NivelStatus = "F" Select oDado).ToList()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        End Try

        Return lstRetorno
    End Function

    Public Function Update(oTipo As Model.Status) As Boolean Implements ICrud(Of Model.Status, Integer).Update
        Dim oDados As Data.Status = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Status
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
