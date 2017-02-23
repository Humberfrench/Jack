using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using Jack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class PresencaService : ServiceBase<Presenca>, IPresencaService
    {

        private readonly IPresencaRepository repPresenca;
        private readonly ValidationResult validationResult = new ValidationResult();
        private readonly IFamiliaRepository repFamilia;
        private readonly IRepresentanteRepository repRepresentante;
        private readonly IReuniaoRepository repReuniao;
        private readonly IParametroRepository repParametros;

        public PresencaService(IPresencaRepository repPresenca, 
                               IFamiliaRepository repFamilia,
                               IRepresentanteRepository repRepresentante,
                               IReuniaoRepository repReuniao, 
                               IParametroRepository repParametros)
            : base(repPresenca)
        {
            this.repPresenca = repPresenca;
            this.repFamilia = repFamilia;
            this.repRepresentante = repRepresentante;
            this.repReuniao = repReuniao;
            this.repParametros = repParametros;
        }

        public IEnumerable<Presenca> ObterFamiliaPorReuniao(int reuniao)
        {
            return repPresenca.ObterFamiliaPorReuniao(reuniao);    
        }

        public IEnumerable<Presenca> ObterFamiliaLivrePorReuniao(int reuniao)
        {
            return repPresenca.ObterFamiliaLivrePorReuniao(reuniao);    
        }
        public ValidationResult Gravar(Reuniao reuniao, Familia familia)
        {

            var presenca = repPresenca.ObterDadoPresencaExistente(familia.Codigo, reuniao.Codigo);
            if (presenca != null)
            {
                validationResult.AddWarning("Presença já cadastrada");
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

        public ValidationResult Gravar(int reuniaoId, int familiaId)
        {
            var familia = repFamilia.ObterPorId(familiaId);
            if (familia == null)
            {
                validationResult.Add(string.Format("Família Código {0} não encontrada", familiaId));
                return validationResult;
            }

            var reuniao = repReuniao.ObterPorId(reuniaoId);
            if (reuniao == null)
            {
                validationResult.Add(string.Format("Reunião Código {0} não encontrada", reuniaoId));
                return validationResult;
            }

            var presenca = repPresenca.ObterDadoPresencaExistente(familiaId, reuniaoId);
            if (presenca != null)
            {
                validationResult.AddWarning(string.Format("Presença da Família {0} na Reunião de {1} não encontrada", familia.Nome, reuniao.Data.ToDateFormated()));
                validationResult.AddWarning("Presença já cadastrada");
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

            repPresenca.Excluir(item);

            return validationResult;

        }

        public List<Stats> ObterDadosPresenca(int familiaId)
        {
            var anoInicio = 2014;
            var anoFinal = DateTime.Now.Year;
            if (DateTime.Now.Month > 7)
            {
                anoFinal = DateTime.Now.Year + 1;
            }
            var familia = repFamilia.ObterPorId(familiaId);
            var retorno = new List<Stats>();
            if (familia == null)
            {
                return retorno;
            }


            for (int ano = anoInicio; ano <= anoFinal; ano++)
            {
                retorno.Add(new Stats
                {
                   Item = ano.ToString(),
                   Valor = familia.Presencas.Where(p => p.Reuniao.AnoCorrente == ano).ToList().Count
                });                  
            }
            return retorno;
        }

        public IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao)
        {
            return repPresenca.ObterFamiliasDisponiveis(reuniao);
        }

        public IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao, string letra)
        {
            return repPresenca.ObterFamiliasDisponiveis(reuniao, letra);
        }

        public ValidationResult ProcessarPresencaGarantida()
        {
            var familias = repFamilia.ObterFamiliaPresencaJustificada().ToList();
            var parametro = repParametros.Obter();
            var reunioes = repReuniao.ObterTodosAteHoje(parametro.AnoCorrente, DateTime.Now).ToList();
            foreach (var reuniao in reunioes)
            {
                foreach (var familia in familias)
                {
                    var retValidator = Gravar(reuniao, familia);
                    retValidator.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
           }

            return validationResult;
        }

        public ValidationResult ProcessarPresencaRepresentantes()
        {
            var familiasRepresentante = repRepresentante.ObterTodos(); ;
            var parametro = repParametros.Obter();
             
            foreach (var familia in familiasRepresentante)
            {

                var reunioes = repPresenca.ObterTodosPorFamilia(familia.FamiliaRepresentante.Codigo);
                foreach (var reuniao in reunioes)
                {
                    var retValidator = Gravar(reuniao, familia.FamiliaRepresentada.Codigo);
                    retValidator.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
            }
            
            return validationResult;
        }
    }
}