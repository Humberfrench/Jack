namespace Jack.Domain.Enum
{
    public enum EnumStatusCrianca : int 
     {
         DadosOk = 1,
         CriancaSemDocumentacao = 4,
         CriancaSemRoupaCalcado = 5,
         DiferencaGrandeCalcado = 6,
         DataNascimentoDesatualizada = 7,
         CriancaMaior = 8,
         CriancaMaiorLiberadaMoralCrista = 11,
         Inativo = 12,
         DiferencaGrandeRoupas = 13,
         CadastroNovo = 14,
         CriancaExcedente = 15,
         CriancaExcedenteRemovidaPelaFamiliaamilia = 16
     }
}