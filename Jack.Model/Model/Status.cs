﻿using System;

namespace Jack.Model
{
    [Serializable()]
    public class Status
    {

        #region "Construtor"

        public Status()
        {
            codigo = 0;
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

    }
}
