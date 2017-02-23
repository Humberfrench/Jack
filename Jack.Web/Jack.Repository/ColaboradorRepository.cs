using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.ObjectValue;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class ColaboradorRepository   : Repository<Colaborador>, IColaboradorRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ColaboradorRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Colaborador entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Colaborador entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Colaborador entity)
        {
            UnitWork.Excluir(entity);
        }

        public Colaborador ObterPorId(int id)
        {
            return GetById(id);
        }

        public IEnumerable<Colaborador> ObterTodos()
        {
           return GetAll();
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