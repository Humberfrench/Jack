using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model
{
    [Serializable()]
    public class Roupa
    {


        public Roupa()
        {
            Codigo = 0;
            Tamanho = string.Empty;
            Idade = 0;
            MedidaIdade = string.Empty;

        }

        public virtual int Codigo { get; set; }
        public virtual string Tamanho { get; set; }
        public virtual int Idade { get; set; }
        public virtual string MedidaIdade { get; set; }

        public virtual string IdadeString
        {
            get
            {
                if (MedidaIdade == "M")
                {
                    return Idade.ToString() + " meses";
                }
                else {
                    return Idade.ToString() + " anos";
                }
            }
        }

    }

}
