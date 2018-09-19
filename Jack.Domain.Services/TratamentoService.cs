using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class TratamentoService : ServiceBase<Tratamento>, ITratamentoService
    {

        private readonly ITratamentoRepository repTratamento;
        private readonly ValidationResult validationResult;

        public TratamentoService(ITratamentoRepository repTratamento)
            : base(repTratamento)
        {
            this.repTratamento = repTratamento;
            validationResult = new ValidationResult();
        }


        public IEnumerable<Tratamento> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Familia.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Tratamento item)
        {
            if (item.TratamentoId == 0)
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

            repTratamento.Excluir(item);

            return validationResult;

        }

        public IEnumerable<Tratamento> ObterTodos(int familiaId)
        {
            return repTratamento.ObterTodos().Where(f => f.Familia.Codigo == familiaId);
        }
    }
}