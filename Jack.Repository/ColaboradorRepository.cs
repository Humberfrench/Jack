using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.ObjectValue;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;
using System.Data;

namespace Jack.Repository
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ColaboradorRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public IEnumerable<QuantidadeSacolasColaborador> ObterQuantidadeSacolasColaborador(int ano, int nivelMaximo)
        {
            var sql = "ObterQuantidadeSacolasColaborador ";

            var parameters = new DynamicParameters();
            parameters.Add("@ano", ano, DbType.Int32);
            parameters.Add("@nivelMaximo", nivelMaximo, DbType.Int32);

            return Conn.Query<QuantidadeSacolasColaborador>(sql, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}