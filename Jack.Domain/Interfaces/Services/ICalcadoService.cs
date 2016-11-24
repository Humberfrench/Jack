using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface ICalcadoService : IServiceBaseReadOnly<Calcado>
    {
        Calcado ObterCalcadoCrianca(int idade, string medidaIdade, string sexo);
        IEnumerable<Calcado> ObterPorSexo(string sexo);
    }
}