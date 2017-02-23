using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IColaboradorService : IServiceBase<Colaborador>
    {
        IEnumerable<Colaborador> Filtrar(string nome);
        ValidationResult Gravar(Colaborador entity);
        ValidationResult Excluir(int id);
        IEnumerable<QuantidadeSacolasColaborador> ObterQuantidadeSacolasColaborador(int ano, int nivelMaximo);
        IEnumerable<ColaboradorCrianca> ObterSacolasColaborador(int colaborador);
        
    }
}