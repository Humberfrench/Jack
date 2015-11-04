Imports System.Globalization

Public Class Criancas
    Implements ICrud(Of Model.Criancas, Integer)

    Private Function Delete(oTipo As Model.Criancas) As Boolean Implements ICrud(Of Model.Criancas, Integer).Delete

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim blnDados As Boolean = False

        Try
            oDataCrianca = New Data.Criancas
            oDataCrianca.Delete(oTipo)
            blnDados = True
        Catch ex As Exception
            blnDados = False
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return blnDados

    End Function

    Public Function Delete(oTipo As Model.Criancas, intFamilia As Integer) As Boolean

        Dim oDataFamiliaCrianca As Data.FamiliaCrianca = Nothing
        Dim blnDados As Boolean = False
        Try
            oDataFamiliaCrianca = New Data.FamiliaCrianca
            If oDataFamiliaCrianca.DeleteCrianca(intFamilia, oTipo.Codigo) Then
                blnDados = Delete(oTipo)
            Else
                Throw New Exception("Erro Excluindo Criança da Família")
            End If
        Catch ex As Exception
            blnDados = False
            Throw ex
        Finally
            oDataFamiliaCrianca = Nothing
        End Try
        Return blnDados
    End Function

    Public Function Find(Identifier As Integer) As Model.Criancas Implements ICrud(Of Model.Criancas, Integer).Find

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim objRetorno As Model.Criancas = Nothing

        Try
            oDataCrianca = New Data.Criancas
            objRetorno = oDataCrianca.Find(Identifier)
        Catch ex As Exception
            objRetorno = Nothing
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return objRetorno

    End Function

    Private Function Insert(oTipo As Model.Criancas) As Boolean Implements ICrud(Of Model.Criancas, Integer).Insert

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim blnDados As Boolean = False

        Try
            oDataCrianca = New Data.Criancas
            oDataCrianca.Insert(oTipo)
            blnDados = True
        Catch ex As Exception
            blnDados = False
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return blnDados

    End Function

    Public Function Insert(oTipo As Model.Criancas, intFamilia As Integer) As Boolean

        Dim oDataFamiliaCrianca As Data.FamiliaCrianca = Nothing
        Dim blnDados As Boolean = False
        Dim intCrianca As Integer = 0

        Try
            oDataFamiliaCrianca = New Data.FamiliaCrianca
            If Insert(oTipo) Then
                'intCrianca = ObterCriancaPorNome(oTipo.Nome)
                blnDados = oDataFamiliaCrianca.Insert(intFamilia, oTipo.Codigo)
            Else
                Throw New Exception("Erro Inclindo Criança da Família")
            End If
        Catch ex As Exception
            blnDados = False
            Throw ex
        Finally
            oDataFamiliaCrianca = Nothing
        End Try
        Return blnDados

    End Function

    Public Function LoadAll() As IList(Of Model.Criancas) Implements ICrud(Of Model.Criancas, Integer).LoadAll

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim lstDados As IList(Of Model.Criancas) = Nothing

        Try
            oDataCrianca = New Data.Criancas
            lstDados = oDataCrianca.LoadAll()
        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return lstDados

    End Function
    Public Function ObterSacolasMae(intMae As Integer) As List(Of Model.Criancas)

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim lstDados As IList(Of Model.Criancas) = Nothing

        Try
            oDataCrianca = New Data.Criancas
            lstDados = oDataCrianca.ObterSacolasMae(intMae)
        Catch ex As Exception
            lstDados = Nothing
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return lstDados

    End Function
    Public Function Update(oTipo As Model.Criancas) As Boolean Implements ICrud(Of Model.Criancas, Integer).Update

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim blnDados As Boolean = False

        Try
            oDataCrianca = New Data.Criancas
            oDataCrianca.Update(oTipo)
            blnDados = True
        Catch ex As Exception
            blnDados = False
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return blnDados

    End Function

    Public Function ObterCriancaPorNome(strName As String) As Integer

        Dim listCriancas As IList(Of Model.Criancas)
        Dim intCrianca As Integer

        Try
            listCriancas = LoadAll()

            'Dim iPesq = From oDado As Model.Criancas In listCriancas Where oDado.Nome = strName
            '            Select oDado

            'intCrianca = iPesq.ToList(0).Codigo
            'iPesq = Nothing

            intCrianca = listCriancas.Where(Function(x) x.Nome = strName).ToList()(0).Codigo


        Catch ex As Exception
            intCrianca = 0
            Throw ex
        Finally
            listCriancas = Nothing
        End Try
        Return intCrianca

    End Function

    ''' <summary>
    ''' Atualiza os Dados das Crianças
    ''' </summary>
    ''' <param name="intCrianca">Código da Criança</param>
    ''' <param name="intCalcado">Número do Calçado</param>
    ''' <param name="strRoupa">Número da Roupa</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Function AtualizaDadosCrianca(intCrianca As Integer, intCalcado As Integer, strRoupa As String) As Boolean

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim blnDados As Boolean = False

        Try
            oDataCrianca = New Data.Criancas
            oDataCrianca.AtualizaDadosCrianca(intCrianca, intCalcado, strRoupa)
            blnDados = True
        Catch ex As Exception
            blnDados = False
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return blnDados

    End Function

    Public Function ObterDados(strData As String,
                               strSexo As String,
                               blnIsNecessidadeEspecial As Boolean) As Model.Criancas

        Dim oDataCrianca As Data.Criancas = Nothing
        Dim objRetorno As Model.Criancas = Nothing
        Dim intIdade As Integer = 0
        Dim dblIdade As Double = 0
        Dim intIdadeMeses As Integer = 0
        Dim strMedidaIdade As String = String.Empty
        Dim datIdade As DateTime
        Dim datCrianca As DateTime

        Try
            'obter idade
            datIdade = New DateTime(DateAndTime.Now.Year, 12, 31)
            datCrianca = Convert.ToDateTime(strData)
            oDataCrianca = New Data.Criancas
            intIdadeMeses = DateDiff(DateInterval.Month, datCrianca, datIdade)

            If intIdadeMeses < 12 Then
                strMedidaIdade = "M"
                intIdade = intIdadeMeses
            Else
                strMedidaIdade = "A"
                dblIdade = intIdadeMeses / 12
                intIdade = Math.Truncate(dblIdade)
            End If

            objRetorno = oDataCrianca.ObterDados(intIdade, strMedidaIdade, strSexo, blnIsNecessidadeEspecial)

        Catch ex As Exception
            objRetorno = Nothing
            Throw ex
        Finally
            oDataCrianca = Nothing
        End Try
        Return objRetorno

    End Function
End Class
