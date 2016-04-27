using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Jack.Library.Extensions;

namespace Jack.DTO
{
    public class DTOFamilia : BaseDTO2
    {
        #region "Construtor"
        public DTOFamilia()
            : base()
        {
            isSacolinha = string.Empty;
            isConsistente = string.Empty;
            contato = string.Empty;
            nivel = 99;
            statusCodigo = 0;
            statusDescricao = string.Empty;
            dataAtualizacao = DateTime.Now;
        }
        public DTOFamilia(int pCodigo, string pNome, string pIsSacolinha, string pIsConsistente,
        string pContato, int pNivel, int pStatusCodigo, string pstatusDescricao,
        DateTime pDataAtualizacao)
            : this()
        {
            codigo = pCodigo;
            nome = pNome;
            isSacolinha = pIsSacolinha;
            isConsistente = pIsConsistente;
            contato = pContato;
            nivel = pNivel;
            statusCodigo = pStatusCodigo;
            statusDescricao = pstatusDescricao;
            dataAtualizacao = pDataAtualizacao;
        }
        #endregion
        #region Fields
        private string isSacolinha;
        private string isConsistente;
        private string contato;
        private int nivel;
        private int statusCodigo;
        private string statusDescricao;
        private DateTime dataAtualizacao;
        string dataAtualizacaoString;
        string dataFormated;
        #endregion

        #region Properties

        [Display(Name = "Sacolinha?")]
        [MaxLength(1)]
        public virtual string IsSacolinha
        {
            get
            {
                return isSacolinha;
            }
            set
            {
                isSacolinha = value;
            }
        }

        [Display(Name = "Consistente?")]
        [MaxLength(1)]
        public virtual string IsConsistente
        {
            get
            {
                return isConsistente;
            }
            set
            {
                isConsistente = value;
            }
        }

        [Display(Name = "Contato:")]
        [MaxLength(50)]
        public virtual string Contato
        {
            get
            {
                return contato;
            }
            set
            {
                contato = value;
            }
        }

        [Display(Name = "Nível:")]
        public virtual int Nivel
        {
            get
            {
                return nivel;
            }
            set
            {
                nivel = value;
            }
        }

        [DataType(DataType.DateTime)]
        public virtual DateTime DataAtualizacao
        {
            get
            {
                return dataAtualizacao;
            }
            set
            {
                dataAtualizacao = value;
                dataAtualizacaoString = dataAtualizacao.ToShortDateString();
                dataFormated = dataAtualizacao.ToDateFormated();
            }
        }

        [Range(1, 15)]
        [Display(Name = "Status:")]
        [Required(ErrorMessage = "Preencher o Campo Status.")]
        public virtual int Status
        {
            get
            {
                return statusCodigo;
            }
            set
            {
                statusCodigo = value;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string StatusDescricao
        {
            get
            {
                return statusDescricao;
            }
            set
            {
                statusDescricao = value;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataAtualizacaoString
        {
            get
            {
                return dataAtualizacaoString;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataFormated
        {
            get
            {
                return dataFormated;
            }
        }
        #endregion
    }
}