namespace Jack.Domain.Enum
{
    public enum EnumStatusFamilia : int 
     {
        DadosOk = 1,
        FamiliaSemCrianca = 2,
        FamiliaSemDocumentacao = 3,
        FamiliaBlackList = 4,
        RepresentanteExcedido = 5,
        CriancasExcedido = 6,
        CriancasERepresentanteExcedido = 7,
        FamiliaSemPresenca = 9,
        FamiliaInconsistente = 10,
        Inativo = 12,
        CadastroNovo = 14,
    }
}