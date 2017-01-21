using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class ColaboradorCriancaService : ServiceBase<ColaboradorCrianca>, IColaboradorCriancaService
    {

        private readonly IColaboradorCriancaRepository repColaboradorCrianca;
        private readonly ICriancaRepository repCrianca;
        private readonly IColaboradorRepository repColaborador;
        private readonly ISacolaRepository repSacola;
        private readonly ValidationResult validationResult = new ValidationResult();

        public ColaboradorCriancaService(IColaboradorCriancaRepository repColaboradorCriancaRepository,
                                         ICriancaRepository repCrianca,
                                         IColaboradorRepository repColaborador,
                                         ISacolaRepository repSacola)
            : base(repColaboradorCriancaRepository)
        {
            this.repColaboradorCrianca = repColaboradorCriancaRepository;
            this.repCrianca = repCrianca;
            this.repColaborador = repColaborador;
            this.repSacola = repSacola;
        }

        public ValidationResult AdicionaColaboradorCrianca(int colaboradorId, int criancaId, int ano)
        {
            var sacola = repSacola.ObterSacolaPorCrianca(criancaId);
            if (sacola == null)
            {
                validationResult.Add("Criança não encontrada para esta sacola.");
                return validationResult;
            }

            var colaborador = repColaborador.ObterPorId(colaboradorId);
            if (colaborador == null)
            {
                validationResult.Add("Colaborador não encontrado");
                return validationResult;
            }

            //atualizar e liberar sacola - caso não esteja liberada
            sacola.Liberado = true;
            repSacola.Atualizar(sacola);

            var item = new ColaboradorCrianca
            {
                Codigo = 0,
                Crianca = sacola.Crianca,
                Colaborador = colaborador,
                Ano =  ano,
                DataCriacao = DateTime.Now,
                Devolvida = false
            };

            Adicionar(item);

            return validationResult;
        }

        public ValidationResult AdicionaColaboradorSacola(int colaboradorId, int sacolaId, int ano)
        {
            var sacola = repSacola.ObterPorId(sacolaId);
            if (sacola == null)
            {
                validationResult.Add("Sacola não encontrada");
                return validationResult;
            }

            var colaborador = repColaborador.ObterPorId(colaboradorId);
            if (colaborador == null)
            {
                validationResult.Add("Colaborador não encontrado");
                return validationResult;
            }

            //atualizar e liberar sacola  - caso não esteja liberada
            sacola.Liberado = true;
            repSacola.Atualizar(sacola);

            var item = new ColaboradorCrianca
            {
                Codigo = 0,
                Crianca = sacola.Crianca,
                Colaborador = colaborador,
                Ano = ano,
                DataCriacao = DateTime.Now,
                Devolvida = false
            };
            Adicionar(item);

            return validationResult;
        }

        public ValidationResult AdicionarSacolas(int colaborador, string sacolas, int ano)
        {
            var sacolasArray = sacolas.Split(',');
            var retorno = new ValidationResult();
            foreach (var sacola in sacolasArray)
            {
                int sacolaId = 0;
                if (!Int32.TryParse(sacola, out sacolaId))
                {
                    validationResult.Add(new ValidationError(String.Format("Problemas para converter o número da Sacola {0}", sacola)));
                    return validationResult;
                }

                var retAdd = AdicionaColaboradorSacola(colaborador, sacolaId, ano);
                //caso haja problemas, tentar o proximo
                if (!retorno.IsValid)
                {
                    retAdd.Erros.ToList().ForEach(e => retorno.Add(e));    
                }
            }

            return retorno;
        }

        public ValidationResult DevolveuSacola(int colaboradorId, int sacolaId, int ano)
        {
            var sacola = repSacola.ObterPorId(sacolaId);
            if (sacola == null)
            {
                validationResult.Add("Sacola não encontrada");
                return validationResult;
            }

            var colaborador = repColaborador.ObterPorId(colaboradorId);
            if (colaborador == null)
            {
                validationResult.Add("Colaborador não encontrado");
                return validationResult;
            }


            var item = ObterTodos().FirstOrDefault(cc => cc.Colaborador.Codigo == colaboradorId
                                                && cc.Crianca.Codigo == sacola.Crianca.Codigo);

            if (item == null)
            {
                validationResult.Add("Sacola não encontrada para o Colaborador ");
                return validationResult;
            }

            item.Devolvida = true;
            item.DataDevolucao = DateTime.Now;
            Atualizar(item);

            return validationResult;
        }


        public IEnumerable<ColaboradorCrianca> Obter(int id, int ano)
        {
            var colaboradorCriancas = ObterTodos().Where(cc => cc.Colaborador.Codigo == id && cc.Ano == ano).ToList() ;

            colaboradorCriancas.ForEach(cc => cc.Crianca.Sacola = repSacola.ObterSacolaPorCrianca(cc.Crianca.Codigo)); 

            return colaboradorCriancas;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repColaboradorCrianca.Excluir(item);

            return validationResult;

        }

    }
}