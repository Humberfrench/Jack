using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class KitRepository   : Repository<Kit>, IKitRepository
    {
        private readonly IUnityOfWork UnitWork;
        public KitRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Kit entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Kit entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Kit entity)
        {
            UnitWork.Excluir(entity);
        }

        public Kit ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Kit> ObterTodos()
        {
           return base.GetAll();
        }

        public Kit ObterKitPorIdade(int idade, string sexo, bool necessidadeEspecial)
        {
            return GetAll().FirstOrDefault(k => k.IdadeMinima <= idade
                                             && k.IdadeMaxima >= idade
                                             && k.Sexo == sexo
                                             && k.NecessidadeEspecial == necessidadeEspecial);            
        }
    }
}