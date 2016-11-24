using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class ColaboradorCriancaRepository   : Repository<ColaboradorCrianca>, IColaboradorCriancaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ColaboradorCriancaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(ColaboradorCrianca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(ColaboradorCrianca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(ColaboradorCrianca entity)
        {
            UnitWork.Excluir(entity);
        }

        public ColaboradorCrianca ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<ColaboradorCrianca> ObterTodos()
        {
           return base.GetAll();
        }
    }
}