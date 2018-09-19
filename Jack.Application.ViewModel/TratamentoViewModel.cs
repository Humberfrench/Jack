using System;
using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class TratamentoViewModel
    {
        private int tratamentoId;
        private FamiliaViewModel familia;
        private StatusTratamentoViewModel statusTratamento;
        private string descricaoProblema;
        private string feedBackTratamento;
        private DateTime? dataInicio;
        private DateTime? dataFim;
        private DateTime dataCadastro;
        private DateTime dataAtualizacao;
        private IList<TratamentoTipoDeProblemaViewModel> tratamentoTiposDeProblema;
        public TratamentoViewModel()
        {
            tratamentoTiposDeProblema = new List<TratamentoTipoDeProblemaViewModel>();
        }
        public virtual int TratamentoId
        {
            get
            {
                return tratamentoId;
            }
            set
            {
                tratamentoId = value;
            }
        }
        public virtual FamiliaViewModel Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }
        public virtual StatusTratamentoViewModel StatusTratamento
        {
            get
            {
                return statusTratamento;
            }
            set
            {
                statusTratamento = value;
            }
        }
        public virtual string DescricaoProblema
        {
            get
            {
                return descricaoProblema;
            }
            set
            {
                descricaoProblema = value;
            }
        }
        public virtual string FeedBackTratamento
        {
            get
            {
                return feedBackTratamento;
            }
            set
            {
                feedBackTratamento = value;
            }
        }
        public virtual DateTime? DataInicio
        {
            get
            {
                return dataInicio;
            }
            set
            {
                dataInicio = value;
            }
        }
        public virtual DateTime? DataFim
        {
            get
            {
                return dataFim;
            }
            set
            {
                dataFim = value;
            }
        }
        public virtual DateTime DataCadastro
        {
            get
            {
                return dataCadastro;
            }
            set
            {
                dataCadastro = value;
            }
        }
        public virtual DateTime DataAtualizacao
        {
            get
            {
                return dataAtualizacao;
            }
            set
            {
                dataAtualizacao = value;
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