using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.DTOs
{
    public abstract class BaseDTO
    {
        public BaseDTO()
        {
            codigo = 0;
            descricao = string.Empty;
        }
        public BaseDTO(int pCodigo, string pDescricao)
        {
            codigo = pCodigo;
            descricao = pDescricao;
        }

        protected int codigo;
        protected string descricao;

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
        public string Descricao
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
    }
}
