using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class PresencaService : ServiceBase<Presenca>, IPresencaService
    {

        private readonly IPresencaRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();
        private readonly IFamiliaRepository repFamilia;
        private readonly IReuniaoRepository repReuniao;

        public PresencaService(IPresencaRepository repository, 
                               IFamiliaRepository repFamilia,
                               IReuniaoRepository repReuniao)
            : base(repository)
        {
            this.repository = repository;
            this.repFamilia = repFamilia;
            this.repReuniao = repReuniao;
        }

        public IEnumerable<Presenca> ObterFamiliaPorReuniao(int reuniao)
        {
            return repository.ObterFamiliaPorReuniao(reuniao);    
        }

        public IEnumerable<Presenca> ObterFamiliaLivrePorReuniao(int reuniao)
        {
            return repository.ObterFamiliaLivrePorReuniao(reuniao);    
        }

        public ValidationResult Gravar(int reuniaoId, int familiaId)
        {
            var familia = repFamilia.ObterPorId(familiaId);
            if (familia == null)
            {
                validationResult.Add(new ValidationError("Família não encontrada"));
                return validationResult;
            }

            var reuniao = repReuniao.ObterPorId(reuniaoId);
            if (reuniao == null)
            {
                validationResult.Add(new ValidationError("Reunião não encontrada"));
                return validationResult;
            }

            var item = new Presenca
            {
                Codigo = 0,
                Familia = familia,
                Reuniao = reuniao 
            };

            Adicionar(item);

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