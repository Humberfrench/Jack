using System.Collections;
using System.Collections.Generic;
using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ICalcadoRepository : IRepositoryBaseReadOnly<Calcado>
    {
        IEnumerable<Calcado> ObterPorSexo(string sexo);
        int ObterPorSexoIdade(string sexo, int idade, string medidaIdade);
    }
}