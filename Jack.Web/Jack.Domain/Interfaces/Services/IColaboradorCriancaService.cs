using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IColaboradorCriancaService : IServiceBase<ColaboradorCrianca>
    {
        IEnumerable<ColaboradorCrianca> Obter(int id, int ano); 
        ValidationResult Excluir(int id);
        ValidationResult AdicionaColaboradorCrianca(int colaborador, int crianca, int ano);
        ValidationResult AdicionaColaboradorSacola(int colaborador, int sacola, int ano);
        ValidationResult AdicionarSacolas(int colaborador, string sacolas, int ano);
        ValidationResult DevolveuSacola(int colaborador, int sacola, int ano);
    }
}