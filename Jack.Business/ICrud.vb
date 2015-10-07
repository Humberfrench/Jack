Public Interface ICrud(Of TClass, keyType)

    Function Insert(ByVal oTipo As TClass) As Boolean
    Function Update(ByVal oTipo As TClass) As Boolean
    Function Delete(ByVal oTipo As TClass) As Boolean
    Function Find(ByVal Identifier As keyType) As TClass
    Function LoadAll() As IList(Of TClass)

End Interface
