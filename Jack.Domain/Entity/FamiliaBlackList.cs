using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class FamiliaBlackList : IEntidade
    {
        public FamiliaBlackList()
        {
            familia = new Familia();
            codigo = 0;
            ano = DateTime.Now.Year;
        }

        private int codigo;
        private Familia familia;
        private int ano;

        public virtual int Codigo
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

        public virtual Familia Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }
        public virtual int Ano
        {
            get
            {
                return ano;
            }
            set
            {
                ano = value;
            }
        }

    }
}
