using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class PresencaJustificadaService : ServiceBase<PresencaJustificada>, IPresencaJustificadaService
    {

        private readonly IPresencaJustificadaRepository repository;
        private readonly IPresencaRepository repPresenca;
        private readonly IFamiliaRepository repFamilia;
        private readonly IReuniaoRepository repReuniao;
        private readonly ValidationResult validationResult = new ValidationResult();

        public PresencaJustificadaService(IPresencaJustificadaRepository repository,
                                          IPresencaRepository repPresenca,
                                          IFamiliaRepository repFamilia, 
                                          IReuniaoRepository repReuniao)
            : base(repository)
        {
            this.repository = repository;
            this.repPresenca = repPresenca;
            this.repFamilia = repFamilia;
            this.repReuniao = repReuniao;
        }

        public ValidationResult Gravar(PresencaJustificada item)
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


        public ValidationResult Gravar(int familiaId)
        {
            var familia = repFamilia.ObterPorId(familiaId);
            if (familia == null)
            {
                validationResult.Add(new ValidationError("Família não encontrada"));
                return validationResult;
            }
            var familiaPresenca = new PresencaJustificada
            {
                Ativo = true,
                Codigo = 0,
                Familia = familia
            };

            return Gravar(familiaPresenca);
        }

        public ValidationResult ProcessaPresenca(int reuniaoId)
        {
            var familias = ObterTodos().Where(fp => fp.Ativo)
                                       .Select(item => new
            {
                item.Familia
            }).ToList();

            if (familias.Count == 0)
            {
                validationResult.Add("Não há familias a ser processadas");
                return validationResult;
            }

            
            var reuniao = repReuniao.ObterPorId(reuniaoId);
            if (reuniao == null)
            {
                validationResult.Add(new ValidationError("Reunião não encontrada"));
                return validationResult;
            }
            foreach (var familia in familias)
            {
                var presensaExistente = repPresenca.Obter(familia.Familia.Codigo, reuniaoId);
                if (presensaExistente == null)
                {
                    var presenca = new Presenca
                    {
                        Codigo = 0,
                        Familia = familia.Familia,
                        Reuniao = reuniao
                    };
                    repPresenca.Adicionar(presenca);
                }
            }

            return validationResult;
        }

        public ValidationResult ProcessaPresencaNoAno(int ano)
        {
            var familias = ObterTodos().Where(fp => fp.Ativo)
                                       .Select(item => new
                                       {
                                           item.Familia
                                       }).ToList();

            if (familias.Count == 0)
            {
                validationResult.Add("Não há familias a ser processadas");
                return validationResult;
            }
            var reunioes = repReuniao.ObterTodos().Where(r => r.AnoCorrente == ano).ToList();
            if (reunioes.Count == 0)
            {
                validationResult.Add(new ValidationError("Não há reuniões a ser processadas"));
                return validationResult;
            }

            foreach (var reuniao in reunioes)
            {
                foreach (var familia in familias)
                {
                    var presensaExistente = repPresenca.Obter(familia.Familia.Codigo, reuniao.Codigo);
                    if (presensaExistente == null)
                    {
                        var presenca = new Presenca
                        {
                            Codigo = 0,
                            Familia = familia.Familia,
                            Reuniao = reuniao
                        };
                        repPresenca.Adicionar(presenca);
                    }
                }
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