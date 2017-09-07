using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class SacolaHistoricoService : ServiceBase<SacolaHistorico>, ISacolaHistoricoService
    {

        private readonly ISacolaHistoricoRepository repSacolaHistorico;
        private readonly ValidationResult validationResult = new ValidationResult();

        public SacolaHistoricoService(ISacolaHistoricoRepository repSacolaHistorico)
            : base(repSacolaHistorico)
        {
            this.repSacolaHistorico = repSacolaHistorico;
        }
        public ValidationResult Gravar(SacolaHistorico item)
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

            repSacolaHistorico.Excluir(item);

            return validationResult;

        }

    }
}