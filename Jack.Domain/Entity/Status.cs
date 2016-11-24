using Jack.Extensions;
using System;
using System.Collections.Generic;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Status : IEntidade
    {
 
        #region "Construtor"

        public Status() :base()
        {
            codigo = 0;
            descricao = string.Empty;
            permiteSacola = false;
            tipoStatus = string.Empty;
            familias = new List<Familia>();
            criancas = new List<Crianca>();
        }

        public Status(string strDescricao) :this()
        {
            codigo = 0;
            descricao = strDescricao;
            tipoStatus = string.Empty;
            permiteSacola = false;
            familias = new List<Familia>();
            criancas = new List<Crianca>();
        }

        public Status(int intCodigo, string strDescricao) : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            tipoStatus = string.Empty;
            permiteSacola = false;
            familias = new List<Familia>();
            criancas = new List<Crianca>();
        }

        public Status(int intCodigo, string strDescricao, bool pPermiteSacola, string strNivelStatus) : this()
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = pPermiteSacola;
            tipoStatus = strNivelStatus;
            familias = new List<Familia>();
            criancas = new List<Crianca>();
        }

        #endregion

        #region "Fields"
        private int codigo;
        private string descricao;
        private bool permiteSacola;
        private string tipoStatus;
        private IList<Familia> familias;
        private IList<Crianca> criancas;
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

        public virtual string TipoStatus
        {
            get
            {
                return tipoStatus;
            }
            set
            {
                tipoStatus = value;
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

        public virtual IList<Crianca> Criancas
        {
            get
            {
                return criancas;
            }
            set
            {
                criancas = value;
            }
        }

    }
}
