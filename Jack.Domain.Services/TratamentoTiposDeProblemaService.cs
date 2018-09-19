using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class TratamentoTiposDeProblemaService : ServiceBase<TratamentoTipoDeProblema>, ITratamentoTiposDeProblemaService
    {

        private readonly ITratamentoTiposDeProblemaRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public TratamentoTiposDeProblemaService(ITratamentoTiposDeProblemaRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public ValidationResult Gravar(TratamentoTipoDeProblema item)
        {
            if (item.TratamentoTipoDeProblemaId == 0)
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