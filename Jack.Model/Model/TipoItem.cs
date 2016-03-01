using Jack.Library.Extensions;
using System;

namespace Jack.Model
{
    [Serializable()]
    public class TipoItem:BaseModel<TipoItem>
    {

        #region "Construtor"

        public TipoItem() : base()
        {
            Codigo = 0;
            descricao = string.Empty;
            isOpcional= string.Empty;
            opcional = string.Empty;
        }

        public TipoItem(string strDescricao)
        {
            Codigo = 0;
            Descricao = strDescricao;
            isOpcional = string.Empty;
            opcional = string.Empty;
        }

        public TipoItem(int intCodigo, string strDescricao)
        {
            Codigo = intCodigo;
            Descricao = strDescricao;
            isOpcional = string.Empty;
            opcional = string.Empty;
        }

        public TipoItem(int intCodigo, string strDescricao, string strIsOpcional)
        {
            Codigo = intCodigo;
            Descricao = strDescricao;
            isOpcional = strIsOpcional;
            opcional = strIsOpcional.ToSimNao();
        }

        #endregion

        private string isOpcional;
        private string opcional;
        private string descricao;

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

        public virtual string IsOpcional
        {
            get
            {
                return isOpcional;
            }
            set
            {
                opcional = IsOpcional.ToSimNao();
                isOpcional = value;
            }
        }

        public virtual string Opcional
        {
            get
            {
                return opcional;
            }
        }

    }
}
