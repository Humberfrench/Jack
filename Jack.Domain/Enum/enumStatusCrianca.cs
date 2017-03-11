namespace Jack.Domain.Enum
{
    public enum EnumStatusCrianca : int
    {
        DadosOk = 1,
        CriancaSemRoupa = 2,
        CriancaSemCalcado = 3,
        CriancaSemDocumentacao = 4,
        CriancaSemRoupaCalcado = 5,
        DiferencaGrandeCalcado = 6,
        DataNascimentoDesatualizada = 7,
        CriancaMaior = 8,
        DiferencaGrandeCalcadoRoupas = 9,
        CriancaMaiorNaoLiberadaMoralCrista = 10,
        CriancaMaiorLiberadaMoralCrista = 11,
        Inativo = 12,
        DiferencaGrandeRoupas = 13,
        CadastroNovo = 14,
        CriancaExcedente = 15,
        CriancaExcedenteRemovidaPelaFamilia = 16
    }
}