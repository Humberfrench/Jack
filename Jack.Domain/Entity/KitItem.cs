using Jack.Domain.Interfaces;
namespace Jack.Domain.Entity
{
    public class KitItem : IEntidade
    {

        #region "Construtor"

        public KitItem():base()
        {
            codigo = 0;
            tipoItem = new TipoItem();
            observacao = string.Empty;
        }

        #endregion

        private int codigo;
        private Kit kit;
        private TipoItem tipoItem;
        private int ordem;
        private string observacao;

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

        public virtual TipoItem TipoItem
        {
            get
            {
                return tipoItem;
            }
            set
            {
                tipoItem = value;
            }
        }
        public virtual int Ordem
        {
            get
            {
                return ordem;
            }
            set
            {
                ordem = value;
            }
        }

        public virtual string Observacao
        {
            get
            {
                return observacao;
            }
            set
            {
                observacao = value;
            }
        }

        public virtual Kit Kit
        {
            get
            {
                return kit;
            }
            set
            {
                kit = value;
            }
        }

    }
}
