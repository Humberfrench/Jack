using Jack.Domain.Interfaces;
using System.Collections.Generic;

namespace Jack.Domain.Entity
{
    public class StatusTratamento : IEntidade
    {
        public StatusTratamento()
        {
            tratamento = new List<Tratamento>();
        }
        private IList<Tratamento> tratamento;
        private int statusTratamentoId;
        private string descricao;

        public virtual int StatusTratamentoId
        {
            get
            {
                return statusTratamentoId;
            }
            set
            {
                statusTratamentoId = value;
            }
        }
        public virtual string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }
        public virtual IList<Tratamento> Tratamento
        {
            get
            {
                return tratamento;
            }
            set
            {
                tratamento = value;
            }
        }
    }
}