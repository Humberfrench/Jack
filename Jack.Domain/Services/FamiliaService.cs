using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using Jack.Extensions;

namespace Jack.Domain.Services
{
    public class FamiliaService : ServiceBase<Familia>, IFamiliaService
    {

        private readonly IFamiliaRepository repFamilia;
        private readonly INivelRepository repNivel;
        private readonly IStatusFamiliaRepository repStatus;
        private readonly IReuniaoRepository repReuniao;
        private readonly ValidationResult validationResult = new ValidationResult();

        public FamiliaService(IFamiliaRepository repFamilia,
                              INivelRepository repNivel,
                              IStatusFamiliaRepository repStatus,
                              IReuniaoRepository repReuniao)
            : base(repFamilia)
        {
            this.repFamilia = repFamilia;
            this.repNivel = repNivel;
            this.repStatus = repStatus;
            this.repReuniao = repReuniao;
        }
        public IEnumerable<Familia> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Familia item)
        {
            if (item.Codigo == 0)
            {
                item.DataCriacao = DateTime.Now;
                item.DataAtualizacao = DateTime.Now;
                Adicionar(item);
            }
            else
            {
                var familia = ObterPorId(item.Codigo);
                if (item.DataCriacao.Year == 1)
                {
                    item.DataCriacao = DateTime.Now;    
                }
                item.DataAtualizacao = DateTime.Now;
                item.Criancas = familia.Criancas;
                item.Representantes = familia.Representantes;
                item.Sacolas = familia.Sacolas;
                item.Presencas = familia.Presencas;
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

            repFamilia.Excluir(item);

            return validationResult;

        }
        #region Validações

        public void AtualizarFamilias()
        {
            var familias = ObterTodos().ToList();
            foreach (var familiaItem in familias)
            {
                AtualizarFamilia(familiaItem, true);
            }
        }

        public Familia AtualizarFamilia(Familia familia, bool gravar = true)
        {
            // sem crianças
            if (!familia.TemCriancas())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemCrianca);
                if (gravar) 
                { 
                    Gravar(familia);
                }
                return familia;
            }

            // com crianças, mas todas maiores ou inelegíveis
            if (familia.TemCriancasMaiores())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemCrianca);
                if (gravar)
                {
                    Gravar(familia);
                }
                return familia;
            }

            //sem presença
            if (familia.FamiliaSemPresenca())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemPresenca);
                if (gravar)
                {
                    Gravar(familia);
                }
                return familia;
            }

            //sem presença
            if (familia.TemDocumentacaoTodasCriancas())
            {
                AtualizarFamiliaNivel99(ref familia, EnumStatusFamilia.FamiliaSemDocumentacao);
                if (gravar)
                {
                    Gravar(familia);
                }
                return familia;
            }

            AtualizaNivel(ref familia);

            return familia;
        }

        public void AtualizaNivel(ref Familia familia,bool gravar = true)
        {    
            var ano = DateTime.Now.Year;

            var reunioesFeitas = ObterQuantidadeReunioesAno(ano);
            var qtdePresencas = ObterQuantidadePresencas(familia.Presencas, ano);
            var percPresenca = (qtdePresencas / reunioesFeitas) * 100;

            familia.Nivel = repNivel.ObterNivelPorFaixaPresencial(percPresenca); ;

            if (gravar)
            {
                Gravar(familia);
            }
            
        }

        private float ObterQuantidadeReunioesAno(int ano)
        {
            var reunioes = repReuniao.ObterTodos()
                                     .Where(r => r.AnoCorrente == ano
                                               && r.Data <= DateTime.Now)
                                     .ToList().Count;

            return reunioes;

        }

        private float ObterQuantidadePresencas(IList<Presenca> presencas, int ano)
        {
            return presencas.Where(p => p.Reuniao.AnoCorrente == ano).ToList().Count;
        }

        private void AtualizarFamiliaNivel99(ref Familia familia, EnumStatusFamilia status)
        {
            familia.Nivel = repNivel.ObterPorId(99);
            familia.Status = repStatus.ObterPorId(status.Int());
            familia.Consistente = false;
            familia.Sacolinha = false;
            familia.DataAtualizacao = DateTime.Now;
        }

        #endregion

    }
}