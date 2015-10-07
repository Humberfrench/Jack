Public Class FamiliaCrianca

    Public Sub New()
        MyBase.new()
    End Sub

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="intCrianca">Criança</param>
    ''' <param name="intFamilia">Familia</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Function Insert(ByVal intFamilia As Integer, intCrianca As Integer) As Boolean
        Dim blnRetorno As Boolean = False
        Dim oDados As Data.FamiliaCrianca = Nothing
        Try
            oDados = New Data.FamiliaCrianca
            blnRetorno = oDados.Insert(intFamilia, intCrianca)

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function


    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="intFamilia">Familia</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Function DeleteFamilia(intFamilia As Integer) As Boolean
        Dim blnRetorno As Boolean = False
        Dim oDados As Data.FamiliaCrianca = Nothing
        Try
            oDados = New Data.FamiliaCrianca
            blnRetorno = oDados.DeleteFamilia(intFamilia)

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function


    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="intFamilia">Familia</param>
    ''' <param name="intCrianca">Criança</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Function DeleteCrianca(ByVal intFamilia As Integer, intCrianca As Integer) As Boolean
        Dim blnRetorno As Boolean = False
        Dim oDados As Data.FamiliaCrianca = Nothing
        Try
            oDados = New Data.FamiliaCrianca
            blnRetorno = oDados.DeleteCrianca(intFamilia, intCrianca)

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function ObterCriancasByFamilia(intFamilia As Integer) As List(Of Model.Criancas)

        Dim lstDados As List(Of Model.Criancas) = Nothing
        Dim oDados As Data.FamiliaCrianca = Nothing
        Try
            oDados = New Data.FamiliaCrianca
            lstDados = oDados.ObterCriancasByFamilia(intFamilia)

        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstDados

    End Function

    Public Function ObterCriancasByFamiliaWithRep(intFamilia As Integer) As List(Of Model.Criancas)

        Dim lstDados As List(Of Model.Criancas) = Nothing
        Dim oDados As Data.FamiliaCrianca = Nothing
        Try
            oDados = New Data.FamiliaCrianca
            lstDados = oDados.ObterCriancasByFamiliaWithRep(intFamilia)

        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstDados

    End Function
End Class
