using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class TipoDeProblemaViewModel
    {
        public TipoDeProblemaViewModel()
        {
            tratamentoTiposDeProblema = new List<TratamentoTipoDeProblemaViewModel>();
        }
        private IList<TratamentoTipoDeProblemaViewModel> tratamentoTiposDeProblema;
        private int tiposDeProblemaId;
        private string descricao;

        public virtual int TipoDeProblemaId
        {
            get
            {
                return tiposDeProblemaId;
            }
            set
            {
                tiposDeProblemaId = value;
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
        public virtual IList<TratamentoTipoDeProblemaViewModel> TratamentoTiposDeProblema
        {
            get
            {
                return tratamentoTiposDeProblema;
            }
            set
            {
                tratamentoTiposDeProblema = value;
            }
        }
    }
}