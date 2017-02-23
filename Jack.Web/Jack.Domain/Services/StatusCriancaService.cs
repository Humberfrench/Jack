using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class StatusCriancaService : ServiceBase<StatusCrianca>, IStatusCriancaService
    {

        private readonly IStatusCriancaRepository repStatus;
        private readonly ValidationResult validationResult = new ValidationResult();

        public StatusCriancaService(IStatusCriancaRepository repStatus)
            : base(repStatus)
        {
            this.repStatus = repStatus;
        }
        public IEnumerable<StatusCrianca> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Descricao.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(StatusCrianca item)
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

            repStatus.Excluir(item);

            return validationResult;

        }

    }
}