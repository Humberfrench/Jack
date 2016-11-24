using System.Collections.Generic;
using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IPresencaRepository : IRepositoryBase<Presenca>
    {
        IEnumerable<Presenca> ObterFamiliaPorReuniao(int reuniao);
        IEnumerable<Presenca> ObterFamiliaLivrePorReuniao(int reuniao);
        Presenca Obter(int familia, int reuniao);
    }
}