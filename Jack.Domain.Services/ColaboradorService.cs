using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class ColaboradorService : ServiceBase<Colaborador>, IColaboradorService
    {

        private readonly IColaboradorRepository repColaborador;
        private readonly IColaboradorCriancaRepository repColaboradorCrianca;
        private readonly ISacolaRepository repSacola;
        private readonly ValidationResult validationResult = new ValidationResult();

        public ColaboradorService(IColaboradorRepository repColaborador,
                                  IColaboradorCriancaRepository repColaboradorCrianca,
                                  ISacolaRepository repSacola)
            : base(repColaborador)
        {
            this.repColaborador = repColaborador;
            this.repColaboradorCrianca = repColaboradorCrianca;
            this.repSacola = repSacola;
        }
        public IEnumerable<Colaborador> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Colaborador item)
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

            repColaborador.Excluir(item);

            return validationResult;

        }

        public IEnumerable<QuantidadeSacolasColaborador> ObterQuantidadeSacolasColaborador(int ano, int nivelMaximo)
        {
            return repColaborador.ObterQuantidadeSacolasColaborador(ano, nivelMaximo);
        }

        public IEnumerable<ColaboradorCrianca> ObterSacolasColaborador(int colaborador)
        {
            var colaboradores = ObterPorId(colaborador);

            //conferir se é lento
            colaboradores.Criancas.ToList().ForEach(
                sac => sac.Crianca.Sacola = repSacola.ObterSacolaPorCrianca(sac.Crianca.Codigo));

            return colaboradores.Criancas;
        }
        public IEnumerable<ColaboradorCrianca> ObterSacolasColaborador(int colaborador, int ano)
        {
            var colaboradores = repColaboradorCrianca.ObterTodos().Where(cc => cc.Ano == ano && cc.Colaborador.Codigo == colaborador);

            return colaboradores;
        }

    }
}