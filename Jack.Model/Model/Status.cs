using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class Status : BaseModel<Status>
    {
 
        #region "Construtor"

        public Status()
        {
            descricao = string.Empty;
        }

        public Status(string strDescricao)
        {
            codigo = 0;
            descricao = strDescricao;
        }

        public Status(int intCodigo, string strDescricao)
        {
            codigo = intCodigo;
            descricao = strDescricao;
        }

        public Status(int intCodigo, string strDescricao, string strPermiteSacola, string strNivelStatus)
        {
            codigo = intCodigo;
            descricao = strDescricao;
            permiteSacola = strPermiteSacola;
            nivelStatus = strNivelStatus;
        }

        #endregion

        #region "Fields"
        private int codigo;
        private string descricao;
        private string permiteSacola;
        private string nivelStatus;
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
            }
        }


        public virtual string PermiteSacolaDesc
        {
            get
            {
                if (permiteSacola == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

        public virtual string NivelStatusDesc
        {
            get
            {
                if (nivelStatus == "F")
                {
                    return "Família";
                }
                else if (nivelStatus == "C")
                {
                    return "Criança";
                }
                else {
                    return "Todos";
                }
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
