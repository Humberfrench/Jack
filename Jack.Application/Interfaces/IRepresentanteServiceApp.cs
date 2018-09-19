using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IRepresentanteServiceApp : IServiceBaseApp<RepresentanteViewModel>
    {
        ValidationResult Gravar(int familiaRepresentante, int familiaRepresentada, int tipoParentesco);
        ValidationResult Gravar(int codigo, int tipoParentesco, bool ativo);
        ValidationResult Ativar(int id);
        ValidationResult Desativar(int id);
        ValidationResult Gravar(RepresentanteViewModel representante);
        ValidationResult Excluir(int id);
        IEnumerable<FamiliaViewModel> ObterFamilias(int familia);
    }
}