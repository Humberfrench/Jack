using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.Enum
{
    public enum StatusCrianca
    {

        DadosOK = 1,
        SemDoc = 4,
        SemRoupa = 5,
        DifGrandeCalcado = 6,
        DataNascimentoDesatualizada = 7,
        CriancaMaior = 8,
        CriancaMaiorMoralCrista = 11,
        Inativo = 12,
        DifGrandeRoupas = 13,
        CadastroNovo = 14

//        1	Dados OK
//4	Criança Sem Documentação
//5	Criança Sem No. Roupa/Calçado
//6	Diferença Grande de Calçado
//7	Dt. Nascim. desatualizada
//8	Criança Maior Não Permitido
//11	Criança Maior Liberado MCristã
//12	Inativo
//13	Diferença Grande de Roupas
//14	Cadastro Novo
    }
}
