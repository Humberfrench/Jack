using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{

    public class TipoItem : IEntidade
    {

        #region "Construtor"

        public TipoItem()
        {
            codigo = 0;
            descricao = string.Empty;
            opcional = false;
        }

        public TipoItem(string strDescricao)
        {
            codigo = 0;
            descricao = strDescricao;
            opcional = false;
        }

        public TipoItem(int intCodigo, string strDescricao)
        {
            codigo = intCodigo;
            descricao = strDescricao;
            opcional = false;
        }

        public TipoItem(int intCodigo, string strDescricao, bool strIsOpcional)
        {
            codigo = intCodigo;
            descricao = strDescricao;
            opcional = strIsOpcional;
        }

        #endregion

        private int codigo;
        private bool opcional;
        private string descricao;

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

        public virtual bool Opcional
        {
            get
            {
                return opcional;
            }
            set
            {
                opcional = value;
            }
        }

    }
}
