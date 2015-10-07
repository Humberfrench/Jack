Imports Consumer.Tools

Public Class Reuniao
    Implements ICrud(Of Model.Reuniao, Integer)

    Public Function GerarDatas(intAno As Integer) As List(Of Model.Reuniao)

        Dim oReuniao As Model.Reuniao
        Dim lstTmpReuniao As List(Of Model.Reuniao)
        Dim lstReuniao As List(Of Model.Reuniao)
        Dim dateDados As Date
        Dim strSabadosConfig As String = String.Empty
        Dim aSabadosReuniao As String() = Nothing

        Try
            lstTmpReuniao = New List(Of Model.Reuniao)
            dateDados = New Date(intAno, 1, 1)
            While dateDados.Year = intAno
                oReuniao = New Model.Reuniao
                oReuniao.Ano = intAno
                oReuniao.Data = dateDados
                If dateDados.DayOfWeek = DayOfWeek.Saturday Then
                    lstTmpReuniao.Add(oReuniao)
                End If
                dateDados = dateDados.AddDays(1)
            End While

            lstReuniao = New List(Of Model.Reuniao)
            strSabadosConfig = Util.Settings.Get("SabadosReuniao")
            aSabadosReuniao = strSabadosConfig.Split(","c)

            For intMes As Integer = 1 To 12
                Dim intMesPesq As Integer = intMes
                Dim iPesq = From oDado In lstTmpReuniao
                            Where oDado.Data.Month = intMesPesq

                lstReuniao.Add(iPesq.ToList()(Convert.ToInt16(aSabadosReuniao(0)) - 1))
                lstReuniao.Add(iPesq.ToList()(Convert.ToInt16(aSabadosReuniao(1)) - 1))

            Next
        Catch ex As Exception
            lstTmpReuniao = Nothing
            Throw ex
        Finally
            oReuniao = Nothing
            dateDados = Nothing
        End Try


        Return lstReuniao

    End Function

    Public Function Load(intAno As Integer) As IList(Of Model.Reuniao)

        Dim iListDatas As IList(Of Model.Reuniao) = LoadAll()

        Dim iPesq = From oDado In iListDatas
                    Where oDado.AnoCorrente = intAno
        Return iPesq.ToList()

    End Function
    Public Function LoadByAnoCorrente(intAno As Integer) As IList(Of Model.Reuniao)

        Dim iListDatas As IList(Of Model.Reuniao) = LoadAll()

        Dim iPesq = From oDado In iListDatas
                    Where oDado.AnoCorrente = intAno
        Return iPesq.ToList()

    End Function
    Public Function AddDatas(intAno As Integer) As Boolean

        Dim lstDatas As List(Of Model.Reuniao) = Nothing
        Dim blnretorno As Boolean = False
        Dim oDados As Data.Reuniao = Nothing
        Dim dateDado As Date = Nothing
        Try
            lstDatas = GerarDatas(intAno)
            oDados = New Data.Reuniao
            For Each oDado As Model.Reuniao In lstDatas
                dateDado = oDado.Data
                oDados.Insert(oDado)
            Next
            blnretorno = True
        Catch ex As Exception
            blnretorno = False
            Throw New Exception("Erro inserindo a data: " + dateDado.ToString, ex)
        End Try
        lstDatas = Nothing
        Return blnretorno
    End Function

    Public Function Delete(oTipo As Model.Reuniao) As Boolean Implements ICrud(Of Model.Reuniao, Integer).Delete
        Dim oDados As Data.Reuniao = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Reuniao
            blnRetorno = oDados.Delete(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno

    End Function

    Public Function Find(Identifier As Integer) As Model.Reuniao Implements ICrud(Of Model.Reuniao, Integer).Find

        Dim oDados As Data.Reuniao = Nothing
        Dim lstRetorno As IList(Of Model.Reuniao) = Nothing

        Try
            oDados = New Data.Reuniao
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Insert(oTipo As Model.Reuniao) As Boolean Implements ICrud(Of Model.Reuniao, Integer).Insert
        Dim oDados As Data.Reuniao = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Reuniao
            blnRetorno = oDados.Insert(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function LoadAll() As IList(Of Model.Reuniao) Implements ICrud(Of Model.Reuniao, Integer).LoadAll
        Dim oDados As Data.Reuniao = Nothing
        Dim lstRetorno As IList(Of Model.Reuniao) = Nothing

        Try
            oDados = New Data.Reuniao
            lstRetorno = oDados.LoadAll()
        Catch ex As Exception
            lstRetorno = Nothing
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return lstRetorno

    End Function

    Public Function Update(oTipo As Model.Reuniao) As Boolean Implements ICrud(Of Model.Reuniao, Integer).Update
        Dim oDados As Data.Reuniao = Nothing
        Dim blnRetorno As Boolean = False

        Try
            oDados = New Data.Reuniao
            blnRetorno = oDados.Update(oTipo)
        Catch ex As Exception
            blnRetorno = False
            Throw ex
        Finally
            oDados = Nothing
        End Try

        Return blnRetorno
    End Function

    Public Function ObterDatasReuniaoAno(strData As DateTime, intAno As Integer) As Integer
        Dim iPesq As IEnumerable(Of Model.Reuniao) = Nothing
        Dim lstDados As List(Of Model.Reuniao) = Nothing
        Dim intRetorno As Integer = 0

        Try
            lstDados = Me.Load(intAno)
            iPesq = From oDado In lstDados Where oDado.Data = strData Select oDado

            If iPesq.ToList().Count > 0 Then
                intRetorno = iPesq.ToList()(0).Codigo
            Else
                intRetorno = 0
            End If

        Catch ex As Exception
            intRetorno = 0
            Throw ex
        Finally
            iPesq = Nothing
            lstDados = Nothing
        End Try

        Return intRetorno

    End Function

End Class
