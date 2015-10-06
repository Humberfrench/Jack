Imports Consumer.Tools


Public MustInherit Class BaseData(Of TypeClass, ID)
    Inherits GenericDao(Of TypeClass, ID)
    Implements IGenericDao(Of TypeClass, ID)

    Private strClassName As String

#Region "Construtor"

    Public Sub New()
        strClassName = MyClass.GetType().ToString()
    End Sub

#End Region

#Region "Métodos do Log"

    Protected Sub Log(ByVal exData As Exception, strMethod As String)

        Erro.Tratar(exData, strMethod, strClassName)

    End Sub

#End Region

#Region "Métodos Básicos da Entidade"

    ''' <summary>
    ''' Método para inserir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Overrides Function Insert(ByVal oTipo As TypeClass) As Boolean

        Dim blnRetorno As Boolean

        Try
            blnRetorno = MyBase.Insert(oTipo)
        Catch ex As Exception
            Log(ex, "Insert")
            blnRetorno = False
            If Util.Settings("ErroAmigavel").ToLower() = "sim" Then
                Throw New Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs")
            Else
                Throw ex
            End If
        End Try

        Return blnRetorno

    End Function

    ''' <summary>
    ''' Método para atualizar o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Overrides Function Update(ByVal oTipo As TypeClass) As Boolean

        Dim blnRetorno As Boolean

        Try
            blnRetorno = MyBase.Update(oTipo)
        Catch ex As Exception
            Log(ex, "Update")
            blnRetorno = False
            If Util.Settings("ErroAmigavel").ToLower() = "sim" Then
                Throw New Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs")
            Else
                Throw ex
            End If
        End Try

        Return blnRetorno

    End Function

    ''' <summary>
    ''' Método para excluir o registro
    ''' </summary>
    ''' <param name="oTipo">Entidade com os dados Preenchidos</param>
    ''' <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    ''' <remarks></remarks>
    Public Overrides Function Delete(ByVal oTipo As TypeClass) As Boolean

        Dim blnRetorno As Boolean

        Try
            blnRetorno = MyBase.Delete(oTipo)
        Catch ex As Exception
            Log(ex, "Delete")
            blnRetorno = False
            If Util.Settings("ErroAmigavel").ToLower() = "sim" Then
                Throw New Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs")
            Else
                Throw ex
            End If
        End Try

        Return blnRetorno

    End Function

    ''' <summary>
    ''' Método para procurar um registro
    ''' </summary>
    ''' <param name="Identifier">Código para a Procura do Valor</param>
    ''' <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
    ''' <remarks></remarks>
    Public Overrides Function Find(ByVal Identifier As ID) As TypeClass

        Dim objReturn As TypeClass

        Try
            objReturn = MyBase.Find(Identifier)
        Catch ex As Exception
            Log(ex, "Find")
            objReturn = Nothing
            If Util.Settings("ErroAmigavel").ToLower() = "sim" Then
                Throw New Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs")
            Else
                Throw ex
            End If
        End Try

        Return objReturn

    End Function

    ''' <summary>
    ''' Método para carregar a lista dos registros
    ''' </summary>
    ''' <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
    ''' <remarks></remarks>
    Public Overrides Function LoadAll() As IList(Of TypeClass)

        Dim objReturn As IList(Of TypeClass)

        Try
            objReturn = MyBase.LoadAll()
        Catch ex As Exception
            Log(ex, "LoadAll")
            objReturn = Nothing
            If Util.Settings("ErroAmigavel").ToLower() = "sim" Then
                Throw New Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs")
            Else
                Throw ex
            End If
        End Try

        Return objReturn

    End Function
#End Region

#Region "Finalize"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region
End Class
