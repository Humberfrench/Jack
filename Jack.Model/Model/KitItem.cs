using System;
using Jack.Library.Extensions;
namespace Jack.Model
{
    [Serializable()]
    public class KitItem: BaseModel<KitItem>
    {

        #region "Construtor"

        public KitItem():base()
        {
            Codigo = 0;
            kit = new Kit();
            TipoItem = new TipoItem();
            Observacao = string.Empty;
        }

        #endregion

        private Kit kit;
        private TipoItem tipoItem;
        private int ordem;
        private string observacao;
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
