using System;

namespace Jack.Model
{
    [Serializable()]
    public class Status
    {

        #region "Construtor"

        public Status()
        {
            _codigo = 0;
            _descricao = string.Empty;
        }

        public Status(string strDescricao)
        {
            _codigo = 0;
            _descricao = strDescricao;
        }

        public Status(int intCodigo, string strDescricao)
        {
            _codigo = intCodigo;
            _descricao = strDescricao;
        }


        public Status(int intCodigo, string strDescricao, string strPermiteSacola, string strNivelStatus)
        {
            _codigo = intCodigo;
            _descricao = strDescricao;
            _permiteSacola = strPermiteSacola;
            _nivelStatus = strNivelStatus;
        }

        #endregion

        #region "Fields"
        private int _codigo;
        private string _descricao;
        private string _permiteSacola;
        private string _nivelStatus;
        #endregion

        public virtual int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }
        public virtual string Descricao
        {
            get
            {
                return _descricao;
            }
            set
            {
                _descricao = value;
            }
        }
        public virtual string PermiteSacola
        {
            get
            {
                return _permiteSacola;
            }
            set
            {
                _permiteSacola = value;
            }
        }
        public virtual string NivelStatus
        {
            get
            {
                return _nivelStatus;
            }
            set
            {
                _nivelStatus = value;
            }
        }


        public virtual string PermiteSacolaDesc
        {
            get
            {
                if (_permiteSacola == "S")
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
                if (_nivelStatus == "F")
                {
                    return "Família";
                }
                else if (_nivelStatus == "C")
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
