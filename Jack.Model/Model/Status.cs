using System;

namespace Jack.Model
{
    [Serializable()]
    public class Status
    {

        #region "Construtor"

        public Status()
        {
            Codigo = 0;
            Descricao = string.Empty;
        }

        public Status(string strDescricao)
        {
            Codigo = 0;
            Descricao = strDescricao;
        }

        public Status(int intCodigo, string strDescricao)
        {
            Codigo = intCodigo;
            Descricao = strDescricao;
        }


        public Status(int intCodigo, string strDescricao, string strPermiteSacola, string strNivelStatus)
        {
            Codigo = intCodigo;
            Descricao = strDescricao;
            PermiteSacola = strPermiteSacola;
            NivelStatus = strNivelStatus;
        }

        #endregion

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string PermiteSacola { get; set; }
        public virtual string NivelStatus { get; set; }

        public virtual string PermiteSacolaDesc
        {
            get
            {
                if (PermiteSacola == "S")
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
                if (NivelStatus == "F")
                {
                    return "Família";
                }
                else if (NivelStatus == "C")
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
