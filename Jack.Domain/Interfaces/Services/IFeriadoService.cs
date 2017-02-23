using Jack.Domain.Entity;
using Jack.DomainValidator;
using System;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IFeriadoService : IServiceBase<Feriado>
    {
        IEnumerable<Feriado> Filtrar(string nome);
        ValidationResult Gravar(Feriado entity);
        ValidationResult Excluir(int id);
        IEnumerable<Feriado> ObterPorAnoEfetivo(int ano);
        Feriado ObterFeriado(DateTime dataReuniao);
    }
}