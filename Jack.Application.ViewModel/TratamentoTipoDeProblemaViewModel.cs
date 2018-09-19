namespace Jack.Application.ViewModel
{
    public class TratamentoTipoDeProblemaViewModel
    {
        private TipoDeProblemaViewModel tipoDeProblema;
        private TratamentoViewModel tratamento;
        private int tratamentoTiposDeProblemaId;
        public virtual TipoDeProblemaViewModel TipoDeProblema
        {
            get
            {
                return tipoDeProblema;
            }
            set
            {
                tipoDeProblema = value;
            }
        }
        public virtual TratamentoViewModel Tratamento
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
        public virtual int TratamentoTipoDeProblemaId
        {
            get
            {
                return tratamentoTiposDeProblemaId;
            }
            set
            {
                tratamentoTiposDeProblemaId = value;
            }
        }
    }
}