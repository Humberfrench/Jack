using Jack.Domain.Entity;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ICalcadoService : IServiceBaseReadOnly<Calcado>
    {
        Calcado ObterCalcadoCrianca(int idade, string medidaIdade, string sexo);
        IEnumerable<Calcado> ObterPorSexo(string sexo);
    }
}