using Jack.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.Enum
{
    public enum StatusFamilia
    {
        [Descricao(Descricao = "Dados OK")]
        DadosOK = 1,

        [Descricao(Descricao = "Família Sem Criança")]
        SemDoc = 2,

        [Descricao(Descricao = "Família Sem Documentação")]
        SemRoupa = 3,

        [Descricao(Descricao = "Familia Sem Presença")]
        DifGrandeCalcado = 9,

        [Descricao(Descricao = "Familia Inconsistente")]
        DataNascimentoDesatualizada = 10,

        [Descricao(Descricao = "Inativo")]
        CriancaMaior = 12,

        [Descricao(Descricao = "Criança Maior Liberado Moral Cristã")]
        CriancaMaiorMoralCrista = 11,

        [Descricao(Descricao = "Inativo")]
        Inativo = 12,

        [Descricao(Descricao = "Cadastro Novo")]
        CadastroNovo = 14

    }
}
