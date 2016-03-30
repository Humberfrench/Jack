using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.DTO
{
    public abstract class BaseDTO2
    {
        public BaseDTO2()
        {
            codigo = 0;
            nome = string.Empty;
        }
        public BaseDTO2(int pCodigo, string pDescricao)
        {
            codigo = pCodigo;
            nome = pDescricao;
        }

        protected int codigo;
        protected string nome;

        public int Codigo
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
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }

        }
    }
}
