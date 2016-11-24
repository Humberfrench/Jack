using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class FeriadoService : ServiceBase<Feriado>, IFeriadoService
    {

        private readonly IFeriadoRepository repFeriado;
        private readonly ValidationResult validationResult = new ValidationResult();

        public FeriadoService(IFeriadoRepository repository)
            : base(repository)
        {
            this.repFeriado = repository;
        }
        public IEnumerable<Feriado> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Feriado item)
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

            repFeriado.Excluir(item);

            return validationResult;

        }

        public IEnumerable<Feriado> ObterPorAnoEfetivo(int ano)
        {
            return repFeriado.ObterPorAnoEfetivo(ano);
        }

        public Feriado ObterFeriado(int ano, DateTime dataReuniao)
        {
            return repFeriado.ObterFeriado(ano, dataReuniao);
        }
    }
}