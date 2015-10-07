Public Class Representante

    Public Sub New()

    End Sub
    Public Function ObterMaes(intFamilia As Integer) As List(Of Model.Familia)

        Dim lstDados As List(Of Model.Familia) = Nothing
        Dim objDados As Data.Representante = Nothing

        Try

            objDados = New Data.Representante
            lstDados = New List(Of Model.Familia)
            lstDados = objDados.ObterMaes(intFamilia)

        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            objDados = Nothing
        End Try

        Return lstDados

    End Function

    Public Function Add(intFamilaRepresentante As Integer, intFamilaRepresentada As Integer) As Boolean

        Dim blnReturn As Boolean = False
        Dim objDados As Data.Representante = Nothing

        Try

            objDados = New Data.Representante
            blnReturn = objDados.Add(intFamilaRepresentante, intFamilaRepresentada)

        Catch ex As Exception
            blnReturn = False
            Throw ex
        Finally
            objDados = Nothing
        End Try

        Return blnReturn
    End Function
    Public Function Del(intFamilaRepresentante As Integer, intFamilaRepresentada As Integer) As Boolean

        Dim blnReturn As Boolean = False
        Dim objDados As Data.Representante = Nothing

        Try

            objDados = New Data.Representante
            blnReturn = objDados.Del(intFamilaRepresentante, intFamilaRepresentada)

        Catch ex As Exception
            blnReturn = False
            Throw ex
        Finally
            objDados = Nothing
        End Try

        Return blnReturn
    End Function
End Class
