using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class TipoParentescoRepository   : Repository<TipoParentesco>, ITipoParentescoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public TipoParentescoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(TipoParentesco entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(TipoParentesco entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(TipoParentesco entity)
        {
            UnitWork.Excluir(entity);
        }

        public TipoParentesco ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<TipoParentesco> ObterTodos()
        {
           return base.GetAll();
        }
    }
}