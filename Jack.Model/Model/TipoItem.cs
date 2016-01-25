using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class TipoItem
    {

        #region "Construtor"

        public TipoItem()
        {
            Codigo = 0;
            Descricao = string.Empty;
        }

        public TipoItem(string strDescricao)
        {
            Codigo = 0;
            Descricao = strDescricao;
        }

        public TipoItem(int intCodigo, string strDescricao)
        {
            Codigo = intCodigo;
            Descricao = strDescricao;
        }

        #endregion

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string IsOpcional { get; set; }

        public virtual string Opcional
        {
            get
            {
                if (IsOpcional == "S")
                {
                    return "Opcional";
                }
                else {
                    return "Não";
                }
            }
        }

    }
}
