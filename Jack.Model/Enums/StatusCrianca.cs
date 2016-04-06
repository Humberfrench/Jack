using Jack.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.Enum
{
    public enum StatusCrianca
    {
        [Descricao(Descricao = "Dados OK")]
        DadosOK = 1,

        [Descricao(Descricao = "Criança Sem Documentação")]
        SemDoc = 4,

        [Descricao(Descricao = "Criança Sem No. Roupa/Calçado")]
        SemRoupa = 5,

        [Descricao(Descricao = "Diferença Grande de Calçado")]
        DifGrandeCalcado = 6,

        [Descricao(Descricao = "Data Nascimento desatualizada")]
        DataNascimentoDesatualizada = 7,

        [Descricao(Descricao = "Criança Maior Não Permitido")]
        CriancaMaior = 8,

        [Descricao(Descricao = "Criança Maior Liberado Moral Cristã")]
        CriancaMaiorMoralCrista = 11,

        [Descricao(Descricao = "Inativo")]
        Inativo = 12,

        [Descricao(Descricao = "Diferença Grande de Roupas")]
        DifGrandeRoupas = 13,

        [Descricao(Descricao = "Cadastro Novo")]
        CadastroNovo = 14

    }
}
