using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class SacolaRepository : Repository<Sacola>, ISacolaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public SacolaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }
        public void Adicionar(Sacola entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Sacola entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Sacola entity)
        {
            UnitWork.Excluir(entity);
        }


        public Sacola ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Sacola> ObterTodos()
        {
           return base.GetAll();
        }

        public Sacola ObterSacolaPorCrianca(int crianca)
        {
            var sacola = ObterTodos().FirstOrDefault(sac => sac.Crianca.Codigo == crianca);
            return sacola;
        }
    }
}