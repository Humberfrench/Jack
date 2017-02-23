using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Repository
{
    public class RepresentanteRepository   : Repository<Representante>, IRepresentanteRepository
    {
        private readonly IUnityOfWork UnitWork;
        public RepresentanteRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Representante entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Representante entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Representante entity)
        {
            UnitWork.Excluir(entity);
        }

        public Representante ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Representante> ObterTodos()
        {
           return base.GetAll();
        }

        public Familia ObterRepresentante(int familiaRepresentada)
        {
            var sql = @"SELECT	Codigo,Nome,Sacolinha,Consistente,PermiteExcedenteRepresentantes,
		                        PermiteExcedenteCriancas,Contato,Fake,PresencaJustificada,
		                        BlackListPasso1,BlackListPasso2,DataAtualizacao,DataCriacao
                          FROM	Familia
                          WHERE Codigo IN (SELECT FamiliaRepresentante
				                           FROM		Representante
				                           WHERE  FamiliaRepresentada = @familiaRepresentada)";

            var dado = Conn.Query<Familia>(sql, new { @familiaRepresentada = familiaRepresentada }).FirstOrDefault();

            return dado;
        }
    }
}
