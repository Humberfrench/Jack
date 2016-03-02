using System;
using Jack.Library.Extensions;

namespace Jack.Model.DTOs
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
            status = string.Empty;
            dataAtualizacao = DateTime.Now;
        }

        public DTOFamilia(int pCodigo, string pNome, string pIsSacolinha, string pIsConsistente, 
                          string pContato, int pNivel, int pStatusCodigo, string pStatus, 
                          DateTime pDataAtualizacao) : this()
        {
            codigo = pCodigo;
            nome = pNome;
            isSacolinha = pIsSacolinha;
            isConsistente = pIsConsistente;
            contato = pContato;
            nivel = pNivel;
            statusCodigo = pStatusCodigo;
            status = pStatus;
            dataAtualizacao = pDataAtualizacao;
        }

        #endregion

        #region Fields

        private string isSacolinha;
        private string isConsistente;
        private string contato;
        private int nivel;
        private int statusCodigo;
        private string status;
        private DateTime dataAtualizacao;
        string dataAtualizacaoString;
        string dataFormated;

        #endregion

        #region Properties

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

        public virtual string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
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
                dataAtualizacaoString = dataAtualizacao.ToShortDateString();
                dataFormated = dataAtualizacao.ToDateFormated();
            }
        }

        public virtual int StatusCodigo
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
