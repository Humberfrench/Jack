Public Class Sacolas

    Public Function ProcessaSacolas(intAno As Integer) As List(Of Model.Sacolas)

        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Try

            oDados = New Data.Sacolas
            lstSacolas = oDados.ProcessaSacolas(intAno)

        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolas

    End Function

    Public Sub GravarLogSacolas(strListSacolasIn As String)

        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Dim intSacola As Integer = 0
        Dim aStrSacolas As String()
        Try

            oDados = New Data.Sacolas
            aStrSacolas = strListSacolasIn.Split(","c)
            For Each strSacola As String In aStrSacolas
                intSacola = CInt(strSacola)
                oDados.GravarLogSacolas(intSacola)
            Next

        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

    End Sub

    Public Function ObterSacolas(intKit As Integer, intNivel As Integer, isPrinted As String) As List(Of Model.Sacolas)
        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Try

            oDados = New Data.Sacolas
            lstSacolas = oDados.ObterSacolas(intKit, intNivel, isPrinted)

        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolas

    End Function

    Public Function ObterSacolasLivres(intKit As Integer, intNivel As Integer, isPrinted As String) As List(Of Model.Sacolas)
        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Try

            oDados = New Data.Sacolas
            lstSacolas = oDados.ObterSacolasLivres(intKit, intNivel, isPrinted)

        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolas

    End Function

    Public Function ObterSacolas() As List(Of Model.Sacolas)
        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Try

            oDados = New Data.Sacolas
            lstSacolas = oDados.ObterSacolas()

        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolas

    End Function
    Public Function ObterSacolas(strListSacolasIn As String) As List(Of Model.Sacolas)

        Dim lstSacolasOut As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing

        Try
            oDados = New Data.Sacolas

            lstSacolasOut = oDados.ObterSacolas(strListSacolasIn)

        Catch ex As Exception
            lstSacolasOut = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolasOut

    End Function

    Public Function ObterKitSacolas(intKit As Integer) As List(Of Model.KitSacola)

        Dim lstSacolasOut As List(Of Model.KitSacola) = Nothing
        Dim oDados As Data.Sacolas = Nothing

        Try
            oDados = New Data.Sacolas

            lstSacolasOut = oDados.ObterKitSacolas(intKit)

        Catch ex As Exception
            lstSacolasOut = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolasOut

    End Function

    Public Function ObterSacolas(intKit As Integer, intNivel As Integer) As List(Of Model.Sacolas)
        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Dim iPesq As IOrderedEnumerable(Of Model.Sacolas)

        Try

            oDados = New Data.Sacolas
            lstSacolas = oDados.ObterSacolas()

            If intKit > 0 And intNivel > 0 Then
                iPesq = From oDado As Model.Sacolas In lstSacolas
                        Where oDado.CodigoKit = intKit And oDado.NumeroNivel = intNivel
                        Order By oDado.NumeroSacola

                lstSacolas = iPesq.ToList()
            ElseIf intKit > 0 And intNivel = 0 Then
                iPesq = From oDado As Model.Sacolas In lstSacolas
                        Where oDado.CodigoKit = intKit
                        Order By oDado.NumeroSacola

                lstSacolas = iPesq.ToList()
            ElseIf intKit = 0 And intNivel > 0 Then
                iPesq = From oDado As Model.Sacolas In lstSacolas
                        Where oDado.NumeroNivel = intNivel
                        Order By oDado.NumeroSacola

                lstSacolas = iPesq.ToList()
            End If

        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolas

    End Function

    Public Function ObterSacolas(intSacolaFamilia As Integer) As List(Of Model.Sacolas)
        Dim lstSacolas As List(Of Model.Sacolas) = Nothing
        Dim oDados As Data.Sacolas = Nothing
        Dim iPesq As IOrderedEnumerable(Of Model.Sacolas)

        Try

            oDados = New Data.Sacolas
            lstSacolas = oDados.ObterSacolas()

            iPesq = From oDado As Model.Sacolas In lstSacolas
                    Where oDado.NumeroSacolaFamilia = intSacolaFamilia
                    Order By oDado.NumeroSacola

            lstSacolas = iPesq.ToList()
            
        Catch ex As Exception
            lstSacolas = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstSacolas

    End Function


    Public Function AddSacolaCrianca(intCrianca As Integer) As Boolean

        Dim oDados As Data.Sacolas = Nothing
        Dim blnRetorno As Boolean = False

        Try

            oDados = New Data.Sacolas()
            blnRetorno = oDados.AddSacolaCrianca(intCrianca)

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function AddSacolaColaboradorCrianca(intCrianca As Integer, intColaborador As Integer, intAno As Integer, isDevolvida As Boolean) As Boolean

        Dim oDados As Data.Sacolas = Nothing
        Dim blnRetorno As Boolean = False

        Try

            oDados = New Data.Sacolas()
            blnRetorno = oDados.AddSacolaColaboradorCrianca(intCrianca, intColaborador, intAno, isDevolvida)

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function


    Public Function AddSacolaColaboradorSacola(intSacola As Integer, intColaborador As Integer, intAno As Integer, isDevolvida As Boolean) As Boolean

        Dim oDados As Data.Sacolas = Nothing
        Dim blnRetorno As Boolean = False

        Try

            oDados = New Data.Sacolas()
            blnRetorno = oDados.AddSacolaColaboradorSacola(intSacola, intColaborador, intAno, isDevolvida)

        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

End Class

