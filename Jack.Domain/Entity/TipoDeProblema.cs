using Jack.Domain.Interfaces;
using System.Collections.Generic;

namespace Jack.Domain.Entity
{
    public class TipoDeProblema : IEntidade
    {
        public TipoDeProblema()
        {
            tratamentoTipoDeProblema = new List<TratamentoTipoDeProblema>();
        }
        private IList<TratamentoTipoDeProblema> tratamentoTipoDeProblema;
        private int tipoDeProblemaId;
        private string descricao;

        public virtual int TipoDeProblemaId
        {
            get
            {
                return tipoDeProblemaId;
            }
            set
            {
                tipoDeProblemaId = value;
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
        public virtual IList<TratamentoTipoDeProblema> TratamentoTipoDeProblema
        {
            get
            {
                return tratamentoTipoDeProblema;
            }
            set
            {
                tratamentoTipoDeProblema = value;
            }
        }

    }
}