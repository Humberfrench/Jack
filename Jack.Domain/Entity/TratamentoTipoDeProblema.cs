using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class TratamentoTipoDeProblema : IEntidade
    {
        private int tratamentoTipoDeProblemaId;
        private TipoDeProblema tiposDeProblema;
        private Tratamento tratamento;
        public virtual int TratamentoTipoDeProblemaId
        {
            get
            {
                return tratamentoTipoDeProblemaId;
            }
            set
            {
                tratamentoTipoDeProblemaId = value;
            }
        }
        public virtual TipoDeProblema TiposDeProblema
        {
            get
            {
                return tiposDeProblema;
            }
            set
            {
                tiposDeProblema = value;
            }
        }
        public virtual Tratamento Tratamento
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