using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class StatusTratamentoService : ServiceBase<StatusTratamento>, IStatusTratamentoService
    {

        private readonly IStatusTratamentoRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public StatusTratamentoService(IStatusTratamentoRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<StatusTratamento> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Descricao.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(StatusTratamento item)
        {
            if (item.StatusTratamentoId == 0)
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