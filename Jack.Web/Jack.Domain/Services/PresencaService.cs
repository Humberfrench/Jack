using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class PresencaService : ServiceBase<Presenca>, IPresencaService
    {

        private readonly IPresencaRepository repPresenca;
        private readonly ValidationResult validationResult = new ValidationResult();
        private readonly IFamiliaRepository repFamilia;
        private readonly IReuniaoRepository repReuniao;
        private readonly IParametroRepository repParametros;

        public PresencaService(IPresencaRepository repPresenca, 
                               IFamiliaRepository repFamilia,
                               IReuniaoRepository repReuniao, 
                               IParametroRepository repParametros)
            : base(repPresenca)
        {
            this.repPresenca = repPresenca;
            this.repFamilia = repFamilia;
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
                validationResult.Add(new ValidationError("Família não encontrada"));
                return validationResult;
            }

            var reuniao = repReuniao.ObterPorId(reuniaoId);
            if (reuniao == null)
            {
                validationResult.Add(new ValidationError("Reunião não encontrada"));
                return validationResult;
            }

            var presenca = repPresenca.ObterDadoPresencaExistente(familiaId, reuniaoId);
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
                    Gravar(reuniao, familia);
                }
            }

            return validationResult;
        }
    }
}