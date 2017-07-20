using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class TipoItemService : ServiceBase<TipoItem>, ITipoItemService
    {

        private readonly ITipoItemRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public TipoItemService(ITipoItemRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
        public IEnumerable<TipoItem> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Descricao.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(TipoItem item)
        {
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                Atualizar(item);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repository.Excluir(item);

            return validationResult;

        }

    }
}