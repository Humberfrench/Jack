using System.Collections.Generic;
using Jack.Domain.Interfaces;
using Jack.Repository.UnityOfWork;
namespace Jack.Repository
{
    public class BaseRepository<TClass> : Repository<TClass> where TClass : IEntidade
    {
        private readonly IUnityOfWork UnitWork;
        public BaseRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(TClass entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(TClass entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(TClass entity)
        {
            UnitWork.Excluir(entity);
        }

        public TClass ObterPorId(int id)
        {
            return GetById(id);
        }

        public IEnumerable<TClass> ObterTodos()
        {
           return GetAll();
        }

        public void Truncate(string table)
        {
            //pr_truncate_table
        }
    }
}