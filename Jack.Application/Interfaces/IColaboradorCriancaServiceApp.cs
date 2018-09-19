using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IColaboradorCriancaServiceApp : IServiceBaseApp<ColaboradorCriancaViewModel>
    {
        IEnumerable<ColaboradorCriancaViewModel> Obter(int id, int ano);
        ValidationResult Excluir(int id);
        ValidationResult AdicionaColaboradorCrianca(int colaborador, int crianca, int ano);
        ValidationResult AdicionaColaboradorSacola(int colaborador, int sacola, int ano);
        ValidationResult AdicionarSacolas(int colaborador, string sacolas, int ano);
        ValidationResult DevolveuSacola(int colaborador, int sacola, int ano);
        ColaboradorViewModel ObterColaborador(int crianca, int ano);
    }
}