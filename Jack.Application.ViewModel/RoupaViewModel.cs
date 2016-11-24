using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application.ViewModel
{
    public class RoupaViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Tamanho { get; set; }
        public virtual string TamanhoMaior { get; set; }
        public virtual int Idade { get; set; }
        public virtual string MedidaIdade { get; set; }

    }

}
