using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class ReuniaoRepository   : Repository<Reuniao>, IReuniaoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ReuniaoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Reuniao entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Reuniao entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Reuniao entity)
        {
            UnitWork.Excluir(entity);
        }

        public Reuniao ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Reuniao> ObterTodos()
        {
           return base.GetAll();
        }
    }
}