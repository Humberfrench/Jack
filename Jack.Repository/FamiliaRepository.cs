using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;

namespace Jack.Repository
{
    public class FamiliaRepository : BaseRepository<Familia>, IFamiliaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public FamiliaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public IEnumerable<Familia> ObterFamiliaPresencaJustificada()
        {
            var sql = @"SELECT  Codigo, Nome, Sacolinha, Consistente, 
                                PermiteExcedenteRepresentantes, 
                                PermiteExcedenteCriancas,
                                Contato, Fake, PresencaJustificada, 
                                BlackListPasso1, BlackListPasso2, 
                                DataAtualizacao, DataCriacao 
                        FROM    Familia
                        WHERE   ((Fake = 1)  OR (PresencaJustificada = 1))";

            var result = Session.Connection.Query<Familia>(sql);

            return result;
        }

        public Nivel ObterNivel(int id)
        {
            return base.GetById(id).Nivel;
        }
    }
}