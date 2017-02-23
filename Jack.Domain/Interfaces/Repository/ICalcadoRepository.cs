using Jack.Domain.Entity;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ICalcadoRepository : IRepositoryBaseReadOnly<Calcado>
    {
        IEnumerable<Calcado> ObterPorSexo(string sexo);
        int ObterPorSexoIdade(string sexo, int idade, string medidaIdade);
    }
}