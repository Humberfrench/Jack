using Jack.Domain.Interfaces;
using System.Collections.Generic;

namespace Jack.Domain.Entity
{
    public class StatusFamilia : IEntidade
    {

        #region "Construtor"

        public StatusFamilia()
        {
            codigo = 0;
            descricao = string.Empty;
            permiteSacola = false;
            familias = new List<Familia>();
        }

        public StatusFamilia(string strDescricao) : this()
        {
            codigo = 0;
            descricao = strDescricao;
            permiteSacola = false;
            familias = new List<Familia>();
        }

        public StatusFamilia(int intCodigo, string strDescricao) : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = false;
            familias = new List<Familia>();
        }

        public StatusFamilia(int intCodigo, string strDescricao, bool pPermiteSacola)
            : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = pPermiteSacola;
            familias = new List<Familia>();
        }
        public StatusFamilia(int intCodigo, string strDescricao, bool pPermiteSacola, bool pProcessaStatus)
            : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = pPermiteSacola;
            processaStatus = pProcessaStatus;
            familias = new List<Familia>();
        }
        #endregion

        #region "Fields"
        private int codigo;
        private string descricao;
        private bool permiteSacola;
        private IList<Familia> familias;
        private bool processaStatus;
        #endregion

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
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

        public virtual bool PermiteSacola
        {
            get
            {
                return permiteSacola;
            }
            set
            {
                permiteSacola = value;
            }
        }

        public virtual bool ProcessaStatus
        {
            get
            {
                return processaStatus;
            }
            set
            {
                processaStatus = value;
            }
        }
        public virtual IList<Familia> Familias
        {
            get
            {
                return familias;
            }
            set
            {
                familias = value;
            }
        }

    }
}
