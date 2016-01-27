﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class KitItem
    {

        #region "Construtor"

        public KitItem()
        {
            Codigo = 0;
            Kit = 0;
            TipoItem = 0;
            Observacao = string.Empty;
        }

        #endregion

        public virtual int Codigo { get; set; }
        public virtual int Kit { get; set; }
        public virtual string KitDescricao { get; set; }
        public virtual int TipoItem { get; set; }
        public virtual int Ordem { get; set; }
        public virtual string TipoItemDescricao { get; set; }
        public virtual string Observacao { get; set; }
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