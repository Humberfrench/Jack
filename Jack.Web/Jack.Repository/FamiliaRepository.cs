using System.Collections.Generic;
using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.ObjectValue;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class FamiliaRepository   : Repository<Familia>, IFamiliaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public FamiliaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Familia entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Familia entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Familia entity)
        {
            UnitWork.Excluir(entity);
        }

        public Familia ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Familia> ObterTodos()
        {
           return base.GetAll();
        }

        public IEnumerable<Familia> ObterFamiliaPresencaJustificada()
        {
            var sql = @"SELECT  Codigo, Nome, Sacolinha, Consistente, 
                                PermiteExcedenteRepresentantes, 
                                PermiteExcedenteCriancas, Nivel,
	                            Status, Contato, Fake, PresencaJustificada, 
                                BlackListPasso1, BlackListPasso2, 
                                DataAtualizacao, DataCriacao 
                        FROM    Familia
                        WHERE   ((Fake = 1)  OR (PresencaJustificada = 1))";

            var result = Session.Connection.Query<Familia>(sql);

            return result;
        }

    }
}