using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class StatusFamiliaService : ServiceBase<StatusFamilia>, IStatusFamiliaService
    {

        private readonly IStatusFamiliaRepository repStatus;
        private readonly ValidationResult validationResult = new ValidationResult();

        public StatusFamiliaService(IStatusFamiliaRepository repStatus)
            : base(repStatus)
        {
            this.repStatus = repStatus;
        }
        public IEnumerable<StatusFamilia> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Descricao.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(StatusFamilia item)
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