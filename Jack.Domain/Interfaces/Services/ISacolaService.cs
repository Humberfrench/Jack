using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface ISacolaService : IServiceBase<Sacola>
    {
        IEnumerable<Sacola> ObterTodosPorNivel(int nivel, int liberado);
        IEnumerable<Familia> ObterFamiliasSacola();
        ValidationResult AddCrianca(int crianca);
        ValidationResult Liberar(int id);
        IEnumerable<Sacola> ObterSacolasLivres(int nivel = 0, int liberado = 2);
        IEnumerable<Sacola> ObterSacolasLivres(int ano, bool? liberado);
        IEnumerable<Sacola> ObterSacolasLivres(bool? liberado, int ano, int nivel = 0, int familia = 0,
                                               string sexo = "", int kit = 0);
    }
}