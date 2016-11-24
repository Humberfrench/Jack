using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IColaboradorCriancaServiceApp : IServiceBase<ColaboradorCriancaViewModel>
    {
        ValidationResult Excluir(int id);
        ValidationResult AdicionaColaboradorCrianca(int colaborador, int crianca, int ano);
        ValidationResult AdicionaColaboradorSacola(int colaborador, int sacola, int ano);
        ValidationResult DevolveuSacola(int colaborador, int sacola, int ano);
    }
}