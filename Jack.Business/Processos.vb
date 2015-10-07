Public Class Processos

    ''' <summary>
    ''' Processa os representantes da Reunião, a presença.
    ''' </summary>
    ''' <param name="strPresenca">Lista de Pessoas para registrar</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function ProcessaPresencasRepresentantesReuniao(strPresenca As String) As Boolean

        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False
        Dim intReuniao As Integer = 0
        Dim aStrPresenca As String() = strPresenca.Split(","c)

        Try
            oDados = New Data.Processos
            For intCont As Integer = 0 To (aStrPresenca.Count - 1)
                If aStrPresenca(intCont).Trim <> "" Then
                    intReuniao = aStrPresenca(intCont)
                End If
                blnRetorno = oDados.ProcessaPresencasRepresentantesReuniao(intReuniao)
            Next

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    ''' <summary>
    ''' Processa os representantes da Reunião, a presença.
    ''' </summary>
    ''' <param name="intReuniao">Pessoas para registrar</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function ProcessaPresencasRepresentantesReuniao(intReuniao As Integer) As Boolean

        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Processos
            blnRetorno = oDados.ProcessaPresencasRepresentantesReuniao(intReuniao)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function ProcesaPresenca(intAno As Integer) As Boolean
        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Processos
            blnRetorno = oDados.ProcesaPresenca(intAno)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function ProcesaGeral(intAno As Integer) As Boolean
        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Processos
            blnRetorno = oDados.ProcesaGeral(intAno)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function


    ''' <summary>
    ''' Roda processo de Atualizar Dadosa de Crianças
    ''' </summary>
    ''' <param name="intCrianca">Código da Criança</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosCrianca(intCrianca As Integer) As Boolean

        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Processos
            blnRetorno = oDados.AtualizaDadosCrianca(intCrianca)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function


    ''' <summary>
    ''' Roda processo de Atualizar Dadosa de Crianças
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosCrianca() As Boolean

        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Processos
            blnRetorno = oDados.AtualizaDadosCrianca()
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    ''' <summary>
    ''' Roda processo de Atualizar Dadosa de Mães
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosMae() As Boolean

        Dim oDados As Data.Processos = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Processos
            blnRetorno = oDados.AtualizaDadosMae()
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function
    ''' <summary>
    ''' Obter lista de crianças inconsistentes
    ''' </summary>
    ''' <returns>Objeto com a lista de Valores Tipo: List(Of Model.CriancasInconsistentes)</returns>
    ''' <remarks></remarks>
    Public Function ObterCriancasInconsistentes() As List(Of Model.CriancasInconsistentes)

        Dim oDados As Data.Processos = Nothing
        Dim lstRetorno As IList(Of Model.CriancasInconsistentes) = Nothing

        Try
            oDados = New Data.Processos
            lstRetorno = oDados.ObterCriancasInconsistentes()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    ''' <summary>
    ''' Obter Nome das mães sem crianças
    ''' </summary>
    ''' <returns>Objeto com a lista de Valores Tipo: List(Of Model.Familia)</returns>
    ''' <remarks></remarks>
    Public Function ObterFamiliasComZeroCriancas() As List(Of Model.Familia)

        Dim oDados As Data.Processos = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing

        Try
            oDados = New Data.Processos
            lstRetorno = oDados.ObterFamiliasComZeroCriancas()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    ''' <summary>
    ''' Obter Lista de Familias Inconsistentes
    ''' </summary>
    ''' <returns>Objeto com a lista de Valores Tipo: List(Of Model.Familia)</returns>
    ''' <remarks></remarks>
    Public Function ObterFamiliasInconsistentes() As List(Of Model.Familia)

        Dim oDados As Data.Processos = Nothing
        Dim lstRetorno As IList(Of Model.Familia) = Nothing

        Try
            oDados = New Data.Processos
            lstRetorno = oDados.ObterFamiliasInconsistentes()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

End Class
