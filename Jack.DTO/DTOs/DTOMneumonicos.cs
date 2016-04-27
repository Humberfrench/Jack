using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Jack.Library.Extensions;

namespace Jack.DTO
{
    public class DTOMneumonicos
    {
        public DTOMneumonicos()
        {
            valor = string.Empty;
        }
        public DTOMneumonicos(string pValor)
        {
            valor = pValor;
        }
        private string valor;

        [Description("Mneumonico")]
        public virtual string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
    }
}