using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IColaboradorServiceApp : IServiceBaseApp<ColaboradorViewModel>
    {
        IEnumerable<ColaboradorViewModel> Filtrar(string nome);
        ValidationResult Gravar(ColaboradorViewModel entity);
        ValidationResult Excluir(int id);
        IEnumerable<ColaboradorCriancaViewModel> ObterSacolasColaborador(int colaborador);
        IEnumerable<ColaboradorCriancaViewModel> ObterSacolasColaborador(int colaborador, int ano);
    }
}