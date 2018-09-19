using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class StatusTratamentoViewModel
    {
        public StatusTratamentoViewModel()
        {
            tratamento = new List<TratamentoViewModel>();
        }
        private IList<TratamentoViewModel> tratamento;
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
        public virtual IList<TratamentoViewModel> Tratamento
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