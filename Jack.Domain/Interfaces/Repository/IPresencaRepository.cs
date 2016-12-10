using System.Collections.Generic;
using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IPresencaRepository : IRepositoryBase<Presenca>
    {
        IEnumerable<Presenca> ObterFamiliaPorReuniao(int reuniao);
        IEnumerable<Presenca> ObterFamiliaLivrePorReuniao(int reuniao);
        int? ObterDadoPresencaExistente(int familia, int reuniao);
        IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao);
        IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao, string letra);
    }
}