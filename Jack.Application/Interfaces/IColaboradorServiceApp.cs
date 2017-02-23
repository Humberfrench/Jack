using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IColaboradorServiceApp : IServiceBase<ColaboradorViewModel>
    {
        IEnumerable<ColaboradorViewModel> Filtrar(string nome);
        ValidationResult Gravar(ColaboradorViewModel entity);
        ValidationResult Excluir(int id);
    }
}