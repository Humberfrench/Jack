using Jack.Library.Extensions;
using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class Status : BaseModel<Status>
    {
 
        #region "Construtor"

        public Status() :base()
        {
            descricao = string.Empty;
        }

        public Status(string strDescricao) :this()
        {
            descricao = strDescricao;
        }

        public Status(int intCodigo, string strDescricao) : this()
        {
            Codigo = intCodigo;
            descricao = strDescricao;
        }

        public Status(int intCodigo, string strDescricao, string strPermiteSacola, string strNivelStatus) : this()
        {
            Codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = strPermiteSacola;
            nivelStatus = strNivelStatus;
        }

        #endregion

        #region "Fields"
        private string descricao;
        private string permiteSacola;
        private string nivelStatus;
        private string permiteSacolaDesc;
        private string nivelStatusDesc;
        private IList<Familia> familias;
        private IList<Criancas> criancas;
        #endregion

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

        public virtual string PermiteSacola
        {
            get
            {
                return permiteSacola;
            }
            set
            {
                permiteSacola = value;
                permiteSacolaDesc = permiteSacola.ToSimNao();
            }
        }

        public virtual string NivelStatus
        {
            get
            {
                return nivelStatus;
            }
            set
            {
                nivelStatus = value;
                nivelStatusDesc.ToNivel();
            }
        }


        public virtual string PermiteSacolaDesc
        {
            get
            {
                return permiteSacolaDesc;
            }
        }

        public virtual string NivelStatusDesc
        {
            get
            {
                return nivelStatusDesc;
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

        public virtual IList<Criancas> Criancas
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
