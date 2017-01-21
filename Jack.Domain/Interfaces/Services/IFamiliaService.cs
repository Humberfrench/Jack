using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IFamiliaService : IServiceBase<Familia>
    {
        IEnumerable<Familia> Filtrar(string nome);
        ValidationResult Gravar(Familia entity);
        ValidationResult Gravar(Familia entity, int reuniao);
        ValidationResult Excluir(int id);
        void AtualizarFamilias();
        Familia AtualizarFamilia(Familia familia, bool gravar = true);
        ValidationResult AtualizarFamilia(int id, bool gravar = true);
        void AtualizaNivel(ref Familia familia);
        ValidationResult AtualizarPresencas(Familia familia);
    }
}