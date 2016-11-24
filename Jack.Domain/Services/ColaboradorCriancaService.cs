using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class ColaboradorCriancaService : ServiceBase<ColaboradorCrianca>, IColaboradorCriancaService
    {

        private readonly IColaboradorCriancaRepository repository;
        private readonly ICriancaRepository repCrianca;
        private readonly IColaboradorRepository repColaborador;
        private readonly ISacolaRepository repSacola;
        private readonly ValidationResult validationResult = new ValidationResult();

        public ColaboradorCriancaService(IColaboradorCriancaRepository repository,
                                         ICriancaRepository repCrianca,
                                         IColaboradorRepository repColaborador,
                                         ISacolaRepository repSacola)
            : base(repository)
        {
            this.repository = repository;
            this.repCrianca = repCrianca;
            this.repColaborador = repColaborador;
            this.repSacola = repSacola;
        }

        public ValidationResult AdicionaColaboradorCrianca(int colaboradorId, int criancaId, int ano)
        {
            var crianca = repCrianca.ObterPorId(criancaId);
            if (crianca == null)
            {
                validationResult.Add("Criança não encontrada");
                return validationResult;
            }

            var colaborador = repColaborador.ObterPorId(colaboradorId);
            if (colaborador == null)
            {
                validationResult.Add("Colaborador não encontrado");
                return validationResult;
            }

            var item = new ColaboradorCrianca
            {
                Codigo = 0,
                Crianca = crianca,
                Colaborador = colaborador,
                Ano =  ano,
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

            var item = new ColaboradorCrianca
            {
                Codigo = 0,
                Crianca = sacola.Crianca,
                Colaborador = colaborador,
                Ano = ano,
                Devolvida = false
            };
            Adicionar(item);

            return validationResult;
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


            Atualizar(item);

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