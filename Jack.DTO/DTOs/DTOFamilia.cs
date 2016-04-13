using System;
using Jack.Library.Extensions;
using Jack.Model.Enum;
using System.ComponentModel.DataAnnotations;
namespace Jack.DTO
{
    public class DTOFamilia : BaseDTO2
    {
        #region "Construtor"

        public DTOFamilia() :base()
        {
            isSacolinha = string.Empty;
            isConsistente = string.Empty;
            contato = string.Empty;
            nivel = 99;
            statusCodigo = 0;
            dataAtualizacao = DateTime.Now;
        }

        public DTOFamilia(int pCodigo, string pNome, string pIsSacolinha, string pIsConsistente, 
                          string pContato, int pNivel, StatusFamilia pStatusCodigo, 
                          DateTime pDataAtualizacao) : this()
        {
            codigo = pCodigo;
            nome = pNome;
            isSacolinha = pIsSacolinha;
            isConsistente = pIsConsistente;
            contato = pContato;
            nivel = pNivel;
            statusCodigo = pStatusCodigo;
            dataAtualizacao = pDataAtualizacao;
        }

        #endregion

        #region Fields

        private string isSacolinha;
        private string isConsistente;
        private string contato;
        private int nivel;
        private StatusFamilia statusCodigo;
        private DateTime dataAtualizacao;
        string dataAtualizacaoString;
        string dataFormated;

        #endregion

        #region Properties
        [Display(Name = "Sacolionha?")]
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

        [DataType( DataType.DateTime)]
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
        public virtual StatusFamilia Status
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

        public virtual string DataAtualizacaoString
        {
            get
            {
                return dataAtualizacaoString;
            }
        }

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
