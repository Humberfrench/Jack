using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Colaborador
    {

        public Colaborador()
        {
            Codigo = 0;
            Nome = string.Empty;
            Telefone = string.Empty;
            Celular = string.Empty;
            EMail = string.Empty;
        }

        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Celular { get; set; }
        public virtual string CPF { get; set; }
        public virtual string EMail { get; set; }
        public virtual int AnoNotificacao { get; set; }
        public virtual int TotalSacolas { get; set; }
        public virtual int QuantidadeSacolas { get; set; }
        public virtual double PercentualSacolas { get; set; }

    }
}
