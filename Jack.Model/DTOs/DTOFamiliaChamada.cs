using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.DTOs
{
    public class DTOFamiliaChamada
    {
        public DTOFamiliaChamada()
        {
            codigo = 0;
            nome = string.Empty;
        }

        public DTOFamiliaChamada(int pCodigo, string pNome) :this()
        {
            codigo = pCodigo;
            nome = pNome;
        }

        private string nome;
        private int codigo;

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
